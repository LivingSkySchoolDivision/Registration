using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Data;
using LSSD.Registration.Forms;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.NotificationHandlers.EmailNotificationHandler;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace LSSD.Registration.Notifier
{
    class Program
    {
        private const int _sleepMinutes = 15;

        private static void ConsoleWrite(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm K") + ": " + message);
        }

        static void Main(string[] args)
        {
            // Load configuration
            IConfiguration configuration = new ConfigurationBuilder()
                   .AddEnvironmentVariables()
                   .Build();
            
            string keyvault_endpoint = configuration["KEYVAULT_ENDPOINT"];
            if (!string.IsNullOrEmpty(keyvault_endpoint))
            {
                ConsoleWrite("Loading configuration from Azure Key Vault: " + keyvault_endpoint);
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(
                                new KeyVaultClient.AuthenticationCallback(
                                    azureServiceTokenProvider.KeyVaultTokenCallback));

                configuration = new ConfigurationBuilder()
                    .AddConfiguration(configuration)
                    .AddAzureKeyVault(keyvault_endpoint, keyVaultClient, new DefaultKeyVaultSecretManager())
                    .Build();
            }
            
            IConfigurationSection smtpConfig = configuration.GetSection("SMTP");
            IConfigurationSection generalConfig = configuration.GetSection("Settings");
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(generalConfig["TimeZone"]);
            string dbConnectionString = configuration.GetConnectionString("InternalDatabase") ?? string.Empty;
            MongoDbConnection mongoDatabase = new MongoDbConnection(dbConnectionString);

            ConsoleWrite($"Time zone for forms: {timeZone}");
            ConsoleWrite($"Email server: {smtpConfig["hostname"]}");

            
            // TODO: Make sure we have all the configuration parts that we need

            MongoRepository<School> schoolRepo = new MongoRepository<School>(mongoDatabase);

            SMTPConnectionDetails smtpInfo = new SMTPConnectionDetails() 
            {
                Host = smtpConfig["hostname"],
                Port = int.Parse(smtpConfig["port"]),
                Username = smtpConfig["username"],
                Password = smtpConfig["password"],
                ReplyToAddress = smtpConfig["replytoaddress"],
                FromAddress = smtpConfig["fromaddress"]               
            };


            // Register notification handlers            
            NotificationHandler notifications = new NotificationHandler();
            EmailNotificationHandler emailHandler = new EmailNotificationHandler(smtpInfo, timeZone, schoolRepo.GetAll());
            notifications.RegisterHandler(emailHandler);

            // Start main loop
            while (true) 
            {
                // Connect to the DB and check for new submitted forms
                handleBatch<SubmittedPreKApplicationForm>(mongoDatabase, notifications);
                handleBatch<SubmittedGeneralRegistrationForm>(mongoDatabase, notifications);

                List<INotifiable> foundForms = new List<INotifiable>();

                // If we find any, trigger some notifications

                // Mark the ones we've found as being seen
                foreach(INotifiable form in foundForms) {
                    form.NotificationSent = true;
                }
                
                // Flush notification handlers
                notifications.Flush();

                // Mark notifications as sent (if a handler indicated such)                
                foreach(T form in foundForms.Where(f => f.NotificationSent == true)) {
                    ConsoleWrite($"> Marking {form.Id} as notified.");
                    repo.Update(form);

                    // Maybe sort them into their base types and make new repositores for them??

                    
                }


                // Sleep
                ConsoleWrite($"Sleeping for {_sleepMinutes} minutes...");
                Task.Delay(_sleepMinutes * 60 * 1000).Wait();
            }
        }

        private static void handleBatch<T>(MongoDbConnection dbConnection, NotificationHandler notificationHandler) where T : IGUIDable, INotifiable
        {
            MongoRepository<T> repo = new MongoRepository<T>(dbConnection);

            // Find new objects
            List<T> foundForms = repo.Find(x => x.NotificationSent == false).ToList();
            
            // The event handler should mark the form as notified=true
            // Don't try to do that here
            foreach(T form in foundForms) {
                ConsoleWrite($"Triggering notifications for {form.Id} ({form.GetType().Name})");
                notificationHandler.Notify(form);                
            }

            
            
        }

    }
}
