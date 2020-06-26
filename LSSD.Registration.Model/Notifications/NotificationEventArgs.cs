using System;
using System.Collections;
using System.Collections.Generic;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.Model
{
    public class NotificationEventArgs : EventArgs
    {
        public INotifiable NotificationContext { get;set; }
        public IEnumerable<SelectedSchool> SchoolsToNotify { get; private set; }

        public NotificationEventArgs(INotifiable Context)
        {
            this.NotificationContext = Context;
            this.SchoolsToNotify = Context.GetNotifySchools();
        }
    }
}