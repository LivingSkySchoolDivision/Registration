using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public interface INotifiable
    {
        IEnumerable<SelectedSchool> GetNotifySchools();
        bool NotificationSent { get;set; }
    }
}
