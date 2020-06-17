namespace LSSD.Registration.NotificationHandlers.EmailNotificationHandler
{
    interface IEmailNotification
    {
        public string AttachmentFilename { get; }
        public string Body { get; }
        public string Subject { get; }
        public string FriendlyAttachmentName { get; }
    }
}