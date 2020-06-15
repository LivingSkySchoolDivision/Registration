using System;
using System.Linq;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using LSSD.Registration.FormGenerators;
using System.Collections.Generic;
using LSSD.Registration.Model.SubmittedForms;
using LSSD.Registration.Forms;
using System.Threading.Tasks;
using LSSD.Registration.Data;
using LSSD.Registration.Model;
using System.Net.Mail;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace LSSD.Registration.EmailRunner
{
    class Program
    {
        /*
            This entire EmailRunner project is TEMPORARY and also HORRIBLE.
            At the moment, I don't have time to write a proper one.
            I will slap together a thing that works for what needs to work by the deadline,
            and I'll write a proper one to replace it.
        */

        private const int _sleepMinutes = 15;
        private static TimeZoneInfo _timeZone = TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time");

        private static void ConsoleWrite(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm K") + ": " + message);
        }

        private static string SanitizeFilename(string input) {
            return Regex.Replace(input, "[^A-Za-z0-9-]", ""); 
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

            string dbConnectionString = configuration.GetConnectionString("InternalDatabase") ?? string.Empty;
            ConsoleWrite($"Email server: {smtpConfig["hostname"]}");

            // Check for empty configuration settings (all of them)

            // Start main program loop
            while (true)
            {
                List<string> PreKFormsThatHaveBeenNotified = new List<string>();

                // Make a dictionary of school DANs to email addresses
                Dictionary<string, string> schoolEmailsByDAN = new Dictionary<string, string>();

                MongoDbConnection mongoDatabase = new MongoDbConnection(dbConnectionString);
                MongoRepository<School> schoolRepo = new MongoRepository<School>(mongoDatabase);

                foreach(School school in schoolRepo.GetAll()) {
                    if (!schoolEmailsByDAN.ContainsKey(school.DAN)) {
                        if (!string.IsNullOrEmpty(school.EmailAddress)) {
                            schoolEmailsByDAN.Add(school.DAN, school.EmailAddress);
                        }
                    }
                }

                // PreK Forms                
                
                MongoRepository<SubmittedPreKApplicationForm> preKRepo = new MongoRepository<SubmittedPreKApplicationForm>(mongoDatabase);
                List<SubmittedPreKApplicationForm> submittedPreKForms = preKRepo.GetAll().Where(x => x.NotificationSent == false).ToList();

                ConsoleWrite($"Found {submittedPreKForms.Count} Pre-K forms.");

                ConsoleWrite($"Email server: {smtpConfig["hostname"]}");
                if (submittedPreKForms.Count > 0) {
                    using (FormFactory factory = new FormFactory()) 
                    {
                        using (SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
                        {
                            Port = 587,
                            UseDefaultCredentials = false,
                            EnableSsl = true,                            
                            Credentials = new NetworkCredential(smtpConfig["username"], smtpConfig["password"])
                        })
                        {
                            // smtpConfig["fromaddress"], smtpConfig["replytoaddress"]

                            ConsoleWrite("Handling Pre-K forms...");
                            foreach(SubmittedPreKApplicationForm form in submittedPreKForms) {
                                ConsoleWrite($"> {form.Id.ToString()}");

                                // Make a list of everyone who should be notified for this form
                                List<string> formNotifications = new List<string>();

                                if (form.Form.SchoolPreferences.FirstChoice != null) {
                                    if (schoolEmailsByDAN.ContainsKey(form.Form.SchoolPreferences.FirstChoice.DAN)) {
                                        formNotifications.Add(schoolEmailsByDAN[form.Form.SchoolPreferences.FirstChoice.DAN]);
                                    }
                                }

                                if (form.Form.SchoolPreferences.SecondChoice != null) {
                                    if (schoolEmailsByDAN.ContainsKey(form.Form.SchoolPreferences.SecondChoice.DAN)) {
                                        formNotifications.Add(schoolEmailsByDAN[form.Form.SchoolPreferences.SecondChoice.DAN]);
                                    }
                                }

                                if (form.Form.SchoolPreferences.ThirdChoice != null) {
                                    if (schoolEmailsByDAN.ContainsKey(form.Form.SchoolPreferences.ThirdChoice.DAN)) {
                                        formNotifications.Add(schoolEmailsByDAN[form.Form.SchoolPreferences.ThirdChoice.DAN]);
                                    }
                                }

                                ConsoleWrite("This form should be sent to: " + string.Join(",", formNotifications));
                                
                                ConsoleWrite(">> Generating file...");
                                string filename = factory.GenerateForm(form, _timeZone);
                                ConsoleWrite($">> Done: {filename}");

                                // SmtpClient doesn't dispose of Attachments on it's own
                                DateTime submittedTime = TimeZoneInfo.ConvertTimeFromUtc(form.DateReceivedUTC, _timeZone);
                                string attachmentFilename = $"PREK-{SanitizeFilename(form.Form.Student.LegalLastName.ToUpper())}-{SanitizeFilename(form.Form.Student.LegalFirstName.ToUpper())}.docx";
                                using (Attachment fileAttachment = new Attachment(filename) { Name = attachmentFilename }) {
                                    ConsoleWrite(">> Creating an email notification");
                                    MailMessage msg = new MailMessage();
                                    
                                    msg.To.Add("mark.strendin@lskysd.ca");
                                    msg.Body = @"
                                    <html>
                                    <body>
                                    <h3>Pre-K Application for " + form.Form.Student.LegalFirstName + " " + form.Form.Student.LegalLastName + @"</h3>
                                    <p>Attached is a pre-kindergarten application for " + form.Form.Student.LegalFirstName + " " + form.Form.Student.LegalLastName + @", 
                                    submitted " + submittedTime.ToLongDateString() + " at " + submittedTime.ToShortTimeString() + @"</p> 
                                    <p>If you have trouble opening this file, please create a Help Desk Ticket at https://helpdesk.lskysd.ca.</p>
                                    <p>The attached file may contain private personal information - please consider this when forwarding this email message.</p>
                                    </body>
                                    </html>";                                
                                    msg.Subject = $"Pre-K Application for {form.Form.Student.LegalFirstName} {form.Form.Student.LegalLastName}";   
                                    msg.Attachments.Add(fileAttachment);                             
                                    msg.From = new MailAddress(smtpConfig["username"], "LSSD Registration Site");
                                    msg.ReplyToList.Add(new MailAddress(smtpConfig["username"], "LSSD Registration Site"));
                                    msg.IsBodyHtml = true;
                                    //smtpClient.Send(msg);
                                }
                            }
                        }                     
                    }                   
                }               

                // Sleep
                ConsoleWrite($"Sleeping for {_sleepMinutes} minutes...");
                Task.Delay(_sleepMinutes * 60 * 1000).Wait();
            }


        }
    }
}
