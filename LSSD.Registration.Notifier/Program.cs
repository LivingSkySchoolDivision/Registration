using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Data;
using LSSD.Registration.Forms;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.NotificationHandlers.EmailNotificationHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace LSSD.Registration.Notifier
{
    class Program
    {
        private const int _sleepMinutes = 15;
        private const int _daysToKeepNotifiedFormsInDB = 90;

        private static void ConsoleWrite(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm K") + ": " + message);
        }

        static void Main(string[] args)
        {            
            
            // Load configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>()
                .Build();

            
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(configuration["Settings:TimeZone"]);

            string dbConnectionString = configuration.GetConnectionString("InternalDatabase") ?? string.Empty;
            MongoDbConnection mongoDatabase = new MongoDbConnection(dbConnectionString);

            ConsoleWrite($"Time zone for forms: {timeZone}");
            
            IConfigurationSection smtpConfig = configuration.GetSection("SMTP");
            SMTPConnectionDetails smtpInfo = new SMTPConnectionDetails()
            {
                Host = smtpConfig["hostname"],
                Port = int.Parse(smtpConfig["port"]),
                Username = smtpConfig["username"],
                Password = smtpConfig["password"],
                ReplyToAddress = smtpConfig["replytoaddress"],
                FromAddress = smtpConfig["fromaddress"]
            };

            // Start main loop
            while (true)
            {
                ConsoleWrite($"Checking for notifications to send...");
                ConsoleWrite($"> Loading schools...");
                MongoRepository<School> schoolRepo = new MongoRepository<School>(mongoDatabase);
                ConsoleWrite($"> Setting up notification handlers...");
                NotificationHandler notifications = new NotificationHandler();

                // Register notification handlers          
                notifications.RegisterHandler(new EmailNotificationHandler(smtpInfo, timeZone, schoolRepo.GetAll()));

                ConsoleWrite($"> Checking for notifications...");
                // Connect to the DB and check for new submitted forms
                handleBatch<SubmittedPreKApplicationForm>(mongoDatabase, notifications);
                handleBatch<SubmittedGeneralRegistrationForm>(mongoDatabase, notifications);


                ConsoleWrite("Finding old applications to purge..");
                purgeOldForms<SubmittedPreKApplicationForm>(mongoDatabase, _daysToKeepNotifiedFormsInDB);
                purgeOldForms<SubmittedGeneralRegistrationForm>(mongoDatabase, _daysToKeepNotifiedFormsInDB);



                // Sleep
                ConsoleWrite($"Sleeping for {_sleepMinutes} minutes...");
                Task.Delay(_sleepMinutes * 60 * 1000).Wait();
            }
        }

        private static void purgeOldForms<T>(MongoDbConnection dbConnection, int daysToKeep) where T : IGUIDable, INotifiable, ISubmittedForm
        {
            ConsoleWrite($">> Checking for {typeof(T)}...");
            MongoRepository<T> repo = new MongoRepository<T>(dbConnection);
            
            List<T> foundForms = repo.Find(x => x.NotificationSent == true && x.DateReceivedUTC < DateTime.UtcNow.AddDays(daysToKeep * -1)).ToList();
            foreach(T form in foundForms)
            {
                IGUIDable f = (IGUIDable)form;
                ConsoleWrite("Removing " + f.Id + " submitted " + form.DateReceivedUTC + " (UTC)");
                repo.Delete(form);
            }
        }

        private static void handleBatch<T>(MongoDbConnection dbConnection, NotificationHandler notificationHandler) where T : IGUIDable, INotifiable
        {

            ConsoleWrite($">> Checking for {typeof(T)}...");
            MongoRepository<T> repo = new MongoRepository<T>(dbConnection);

            // Find new objects
            List<T> foundForms = repo.Find(x => x.NotificationSent == false).ToList();
            
            foreach(T form in foundForms) {
                ConsoleWrite($">> Enqueuing notifications for {form.Id} ({form.GetType().Name})");
                notificationHandler.AddNotification(form);                
            } 

            // Send all notifications that we queued
            notificationHandler.Flush();

            // Mark objects that suceeded as complete
            foreach(T form in foundForms.Where(f => f.NotificationSent == true)) {
                ConsoleWrite($">> Marking {form.Id} as notified ({form.GetType().Name})");
                repo.Update(form);
            } 


        }


    }
}
