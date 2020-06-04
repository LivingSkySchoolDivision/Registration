using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model.Forms
{
    public class WorkflowTracking
    {
        public bool IsProcessed { get; set; }
        public bool IsRejected { get; set; }
        public string RejectedReason { get; set; }
        public DateTime DateProcessedUTC { get; set; }
        public string ProcessedBy { get; set; }
        public string SubmittedFromIP { get; set; }      
        public DateTime DateCUMERequestedUTC { get; set; }
        public DateTime DateCUMEReceivedUTC { get; set; }
        public List<string> Notes { get; set; }
    }
}
