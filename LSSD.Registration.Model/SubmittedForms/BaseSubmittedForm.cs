using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.SubmittedForms
{
    public abstract class BaseSubmittedForm
    {
        public bool IsProcessed { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeleted { get; set; }
        public bool NotificationSent { get; set; }
        public string RejectedReason { get; set; }
        public string ReceivedFromIP { get; set; }
        public DateTime DateReceivedUTC { get; set; } = DateTime.UtcNow;
        public DateTime DateProcessedUTC { get; set; }
        public string ProcessedBy { get; set; }
        public List<string> Notes { get; set; }

        public BaseSubmittedForm(string IPAddress)
        {
            this.ReceivedFromIP = IPAddress;
        }
    }
}
