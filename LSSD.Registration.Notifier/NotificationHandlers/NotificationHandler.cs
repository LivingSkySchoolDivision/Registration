
using System;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.Notifier
{
    class NotificationHandler
    {
        public event EventHandler<NotificationEventArgs> NewNotification;

        protected void handleNewNotification(NotificationEventArgs e) 
        {
            NewNotification?.Invoke(this, e);
        }

        public void Notify<T>(T form) where T : INotifiable 
        {
            handleNewNotification(new NotificationEventArgs(form));
        }
    }
}