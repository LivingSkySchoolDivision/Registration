using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public interface ISubmittedForm
    {
        Guid Id { get; set; }
        public DateTime DateReceivedUTC { get; set; }
    }
}
