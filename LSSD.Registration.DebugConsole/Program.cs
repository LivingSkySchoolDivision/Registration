using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
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
                Console.WriteLine("  3. Wipe and re-import school JSON file");
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
                Console.WriteLine("ERROR: Couldn't find a connection string!");
                Thread.Sleep(5000);
            } else
            {
                Console.WriteLine("> Setting connection string...");
                dbConnectionString = connstr;
            }
        }

        private static void schoolReimport()
        {

        }

    }
}
