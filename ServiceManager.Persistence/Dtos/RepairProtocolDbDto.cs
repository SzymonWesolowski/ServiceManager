using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RepairProtocolDbDto : ProtocolDbDto
    {

        public string CauseOfFailure { get; set; }
        public string RepairDescription { get; set; }
    }
}