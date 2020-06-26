namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    public class SMTPConnectionDetails 
    {
        public string Host { get;set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReplyToAddress { get; set; }
        public string FromAddress { get; set; }

    }
}