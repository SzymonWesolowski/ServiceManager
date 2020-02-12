using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceManager.Domain.Model
{
    public abstract class ProtocolDbDto
    {


        [Key]
        public string ProtocolId { get; set; }
        public string ServicemanId { get; set; }
        public string ProtocolDate { get; set; }
        public string EstateId { get; set; }
        public string DeviceSerialNumber { get; set; }
        public bool IsPositive { get; set; }
        public string Recommendations { get; set; }
        public string PartsToBeReplaced { get; set; }
        public string DeviceId { get; set; }

    }


}
