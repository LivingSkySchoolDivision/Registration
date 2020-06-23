
using System;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.Notifier
{
    class NotificationHandler
    {
        public event EventHandler<NotificationEventArgs> NewNotification;
        public event EventHandler FlushNotifications;


        public void AddNotification<T>(T form) where T : INotifiable 
        {
            triggerNewNotification(new NotificationEventArgs(form));
        }

        public void RegisterHandler(INotificationHandler handler) {
            this.NewNotification += handler.Enqueue;
            this.FlushNotifications += handler.Flush;
        }

        public void Flush() 
        {
            triggerFlush(new EventArgs());
        }

        protected void triggerNewNotification(NotificationEventArgs e) 
        {
            NewNotification?.Invoke(this, e);
        }

        protected void triggerFlush(EventArgs e) 
        {
            FlushNotifications?.Invoke(this, e);
        }
    }
}