using LSSD.Registration.Data;
using LSSD.Registration.Model;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace LSSD.Registration.DebugConsole
{
    class Program
    {
        static string menuSelection = string.Empty;
        static string dbConnectionString = string.Empty;

        static IConfiguration configuration = new ConfigurationBuilder()
                   .AddJsonFile($"appsettings.json", true, true)
                   .AddEnvironmentVariables()
                   .Build();

        static string azkvEndpoint = configuration["KEYVAULT_ENDPOINT"];

        static void Main(string[] args)
        {


            while (menuSelection != "q")
            {
                Console.Clear();
                Console.WriteLine("LSSD Online Registration Debug Console");
                Console.WriteLine("\n");
                Console.WriteLine(" Azure Key Vault endpoint is: " + (string.IsNullOrEmpty(azkvEndpoint) ? "(Empty)" : azkvEndpoint));
                Console.WriteLine(" DB Connection string is: " + (string.IsNullOrEmpty(dbConnectionString) ? "(Empty)" : $"LOADED ({dbConnectionString.Length} characters)"));
                Console.WriteLine("\n");
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("  1. Enter database connection string manually (for this console)");
                Console.WriteLine("  2. Attempt to retrieve connection string from Azure Key Vault");
                Console.WriteLine("  3. Import school JSON file");
                Console.WriteLine("  q. Quit");

                Console.Write("Please make a selection: ");
                menuSelection = Console.ReadLine();

                switch(menuSelection)
                {
                    case "1":
                        manualConnectionString();
                        break;
                    case "2":
                        keyVaultConnectionString();
                        break;
                    case "3":
                        schoolReimport();
                        break;
                }
            }
        }


        private static void manualConnectionString()
        {
            Console.Write("Please enter a connection string: ");
            dbConnectionString = Console.ReadLine();
        } 


        private static void keyVaultConnectionString()
        {
            string input = string.Empty;

            Console.Write("AZKV Endpoint [" + (string.IsNullOrEmpty(azkvEndpoint) ? "(empty)" : azkvEndpoint) + "]: ");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(azkvEndpoint))
            {
                input = azkvEndpoint;
            }

            if (!string.IsNullOrEmpty(input))
            {
                azkvEndpoint = input;
            }

            try
            {
                Console.WriteLine("> Connecting to Azure Key Vault...");
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                    azureServiceTokenProvider.KeyVaultTokenCallback));
                Console.WriteLine("> Retrieving secrets...");
                IConfiguration conf = new ConfigurationBuilder()
                    .AddAzureKeyVault(azkvEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager())
                    .Build();


                string connstr = conf.GetConnectionString("InternalDatabase");

                if (string.IsNullOrEmpty(connstr))
                {
                    Console.WriteLine("> ERROR: Couldn't find a connection string!");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("> Setting connection string...");
                    dbConnectionString = connstr;
                }
            } catch(Exception ex)
            {
                Console.WriteLine("> ERROR: " + ex.Message);
                Console.WriteLine("(Press any key to continue...)");
                Console.ReadKey();
            }
        }

        private static void schoolReimport()
        {
            bool wipe = false;
            string filename = string.Empty;

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                Console.WriteLine("> ERROR: You need to specify a connection string first.");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("> Connecting to database...");
                MongoDbConnection dbConnection = new MongoDbConnection(dbConnectionString);
                MongoRepository<School> schoolRepository = new MongoRepository<School>(dbConnection);

                Console.Write("Enter filename to import (must be a JSON file): ");
                filename = Console.ReadLine();

                if (!string.IsNullOrEmpty(filename))
                {
                    Console.WriteLine($"> Attempting to load {filename}");
                    // Verify that the file exists
                    if (File.Exists(filename))
                    {
                        // Attempt to load the file
                        try
                        {
                            using (StreamReader importFile = new StreamReader(filename))
                            {
                            
                                // Attempt to deserialize the file
                                List<School> importedSchools = new List<School>();
                                importedSchools = System.Text.Json.JsonSerializer.Deserialize<List<School>>(importFile.ReadToEnd());

                                Console.WriteLine($"> Loaded {importedSchools.Count} School objects from file");

                                Console.WriteLine("Dump JSON to console window [yN]?: ");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(importedSchools, new JsonSerializerOptions() { WriteIndented = true }));
                                }

                                Console.Write("\nWipe existing school data [Yn]: ");
                                wipe = !(Console.ReadLine().ToLower() == "n");

                                Console.WriteLine("Perform the import [yN]?: ");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    Console.WriteLine("> Performing import...");
                                    // Perform the import
                                    if (wipe)
                                    {
                                        Console.WriteLine("> Wiping existing data...");
                                        schoolRepository.DeleteAll();
                                    }

                                    Console.WriteLine("> Importing...");
                                    schoolRepository.Insert(importedSchools);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("> ERROR: " + ex.Message);
                            Console.WriteLine("(Press any key to continue...)");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("> ERROR: File not found");
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    Console.WriteLine("> ERROR: Filename empty");
                    Thread.Sleep(3000);
                }
            }
        }

    }
}
