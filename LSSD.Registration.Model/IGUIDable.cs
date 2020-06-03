using System;
using System.Collections.Generic;
using System.Text;

namespace LSSD.Registration.Model
{
    public interface IGUIDable
    {
        Guid Id { get; set; }
    }
}
