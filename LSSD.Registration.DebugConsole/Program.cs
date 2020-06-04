using LSSD.Registration.Data;
using LSSD.Registration.Model;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

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

            string dbConnectionString = configuration.GetConnectionString("InternalDatabase") ?? string.Empty;

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                Console.WriteLine("ConnectionString can't be empty");
            } else
            {
                Console.WriteLine("Loading schools.json");

                List<School> loadedSchools = new List<School>();

                using (StreamReader file = File.OpenText("schools.json"))
                {
                    loadedSchools = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(file.ReadToEnd());
                }
                Console.WriteLine($"{loadedSchools.Count} schools");
                foreach(School school in loadedSchools)
                {
                    Console.WriteLine(school.Name);
                }

                MongoDbConnection dbCon = new MongoDbConnection(dbConnectionString);
                MongoRepository<School> schoolRepo = new MongoRepository<School>(dbCon);

                schoolRepo.Insert(loadedSchools);

                /*
                // Insert a school
                Console.WriteLine("Inserting new school...");
                

                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(newSchool));
                //schoolRepo.Insert(newSchool);


                Console.WriteLine("All schools: ");
                foreach(School school in schoolRepo.GetAll())
                {
                    Console.WriteLine(school.Name);
                }
                Console.WriteLine("Done!");
                //*/

            }
        }
    }
}
