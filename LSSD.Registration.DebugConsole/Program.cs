using LSSD.Registration.Data;
using LSSD.Registration.Model;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LSSD.Registration.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .Build();

            string keyvault_endpoint = configuration["KEYVAULT_ENDPOINT"];
            if (!string.IsNullOrEmpty(keyvault_endpoint))
            {
                Console.WriteLine("Loading configuration from Azure Key Vault: " + keyvault_endpoint);
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                    azureServiceTokenProvider.KeyVaultTokenCallback));

                configuration = new ConfigurationBuilder()
                    .AddConfiguration(configuration)
                    .AddAzureKeyVault(keyvault_endpoint, keyVaultClient, new DefaultKeyVaultSecretManager())
                    .Build();
            }

            string dbConnectionString = configuration.GetConnectionString("PublicAPI") ?? string.Empty;

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                Console.WriteLine("ConnectionString can't be empty");
            } else
            {

                // Attempt to list schools
                MongoDbConnection dbCon = new MongoDbConnection(dbConnectionString);
                MongoRepository<School> schoolRepo = new MongoRepository<School>(dbCon);

                // Insert a school
                Console.WriteLine("Inserting new school...");
                School newSchool = new School()
                {
                    Name = "Spiritwood High School",
                    PhoneNumber = "3068832282",
                    Communities = new List<string>() { "Spiritwood" },
                    WebsiteURL = "https://shs.lskysd.ca/",
                    Facebook = "Spiritwood-High-School-225340694468912",
                    EmailAddress = "shs@lskysd.ca",
                    MailingAddress = new Address()
                    {
                        Line1 = "",
                        PostalCode = "",
                        City = "",
                        Province = "SK",
                        Country = "Canada"
                    },
                    PhysicalAddress = new Address()
                    {
                        Line1 = "216 4th Street West",
                        PostalCode = "S0J 2M0",
                        City = "Spiritwood",
                        Province = "SK",
                        Country = "Canada"
                    },
                    DAN = "6410713",
                    HasGrade7 = true,
                    HasGrade8 = true,
                    HasGrade9 = true,
                    HasGrade10 = true,
                    HasGrade11 = true,
                    HasGrade12 = true
                };

                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(newSchool));
                //schoolRepo.Insert(newSchool);


                Console.WriteLine("All schools: ");
                foreach(School school in schoolRepo.GetAll())
                {
                    Console.WriteLine(school.Name);
                }
                Console.WriteLine("Done!");

            }
        }
    }
}
