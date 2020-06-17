using System;
using LSSD.Registration.Model;

namespace LSSD.Registration
{
    public interface INotificationHandler
    {
        void Enqueue(object sender, NotificationEventArgs e);
        void Flush(object sender, EventArgs e);
        
    }
}