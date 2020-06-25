using LSSD.Registration.Data;
using LSSD.Registration.FormGenerators;
using LSSD.Registration.Forms;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.WriteLine("  1. Enter database connection string manually");
                Console.WriteLine("  2. Attempt to retrieve database connection info from Azure Key Vault");
                Console.WriteLine("  3. Import school JSON file");
                Console.WriteLine("  4. List schools");
                Console.WriteLine("  5. List general registrations");
                Console.WriteLine("  6. List prek applications");
                Console.WriteLine("  7. Create a test PreK application document");
                Console.WriteLine("  8. Create a test General registration document");
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
                    case "4":
                        recordExplore<School>();
                        break;
                    case "5":
                        recordExplore<SubmittedGeneralRegistrationForm>();
                        break;
                    case "6":
                        recordExplore<SubmittedPreKApplicationForm>();
                        break;
                    case "7":
                        createTestPreKDocument();
                        break;
                    case "8":
                        createTestGeneralDocument();
                        break;
                }
            }
        }


        private static void manualConnectionString()
        {
            Console.Write("Please enter a connection string: ");
            dbConnectionString = Console.ReadLine();
        } 
        
        private static void createTestPreKDocument()
        {
            TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time");

            using (FormFactory formFactory = new FormFactory()) 
            {
                string filename = formFactory.GenerateForm(new SubmittedPreKApplicationForm(Examples.PreK), timezone);

                if (!string.IsNullOrEmpty(filename)) {
                    Console.WriteLine("Form created: " + filename);
                } else {
                    Console.WriteLine("Something went wrong, and the form could not be created.");
                }
                Console.WriteLine("Press any key to continue (will delete all forms created)...");
                Console.ReadKey();
            }
        } 

         private static void createTestGeneralDocument()
        {
            TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time");

            using (FormFactory formFactory = new FormFactory()) 
            {
                string filename = formFactory.GenerateForm(new SubmittedGeneralRegistrationForm(Examples.General), timezone);

                if (!string.IsNullOrEmpty(filename)) {
                    Console.WriteLine("Form created: " + filename);
                } else {
                    Console.WriteLine("Something went wrong, and the form could not be created.");
                }
                Console.WriteLine("Press any key to continue (will delete all forms created)...");
                Console.ReadKey();
            }
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

        private static void recordExplore<T>() where T: IGUIDable
        {
            if (string.IsNullOrEmpty(dbConnectionString))
            {
                Console.WriteLine("> ERROR: You need to specify a connection string first.");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("> Connecting to database...");
                MongoDbConnection dbConnection = new MongoDbConnection(dbConnectionString);
                MongoRepository<T> repository = new MongoRepository<T>(dbConnection);

                Console.WriteLine($"Exploring {typeof(T).Name} objects");
                long objCount = repository.Count();
                Console.WriteLine($"Total count: {objCount}");

                Console.Write("Dump to console [yN]?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    foreach(T obj in repository.GetAll())
                    {
                        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions() { WriteIndented = true }));
                    }

                    Console.WriteLine("\n\nPress any key to continue...");
                    Console.ReadKey();
                } 

                Console.Write("Dump to json files? [yN]?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("Name of new directory where json files will be stored (if exists it will be deleted)");
                    Console.Write($"Directory name: [{typeof(T).Name}]: ");
                    string dirname = Console.ReadLine();
                    if (string.IsNullOrEmpty(dirname)) {
                        dirname = typeof(T).Name;
                    }
                    Console.WriteLine($"Creating folder {dirname}");
                    
                    if (Directory.Exists(dirname))
                    {
                        Directory.Delete(dirname, true);
                    }

                    if (!Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(dirname);
                    } 

                    Console.WriteLine("Dumping objects...");

                    foreach(T obj in repository.GetAll())
                    {
                        using (StreamWriter fileStream = File.CreateText(Path.Combine(dirname, $"{obj.Id}.json")))
                        {
                            Newtonsoft.Json.JsonSerializer serializer= new Newtonsoft.Json.JsonSerializer();    
                            serializer.Formatting = Formatting.Indented;                        
                            serializer.Serialize(fileStream, obj, typeof(T));
                        }
                    }

                    Console.WriteLine("Done!");

                    Console.WriteLine("\n\nPress any key to go back to main menu...");
                    Console.ReadKey();
                } 

            }
        }

    }
}
