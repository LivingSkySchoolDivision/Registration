using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LSSD.Registration.Model
{
    public class StVitalExtraRequirements
    {
        [Required]
        public bool AcknowledgesPolicy { get; set; }
        public bool ChildIsCatholic { get; set; }
        public bool CommitToBaptize { get; set; }
        public bool ShareInfoWithParish { get; set; }
        public bool AcknowledgeFailureState { get; set; }
    }
}
