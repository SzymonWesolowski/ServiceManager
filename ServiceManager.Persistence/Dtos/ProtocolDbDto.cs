using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceManager.Domain.Model
{
    public abstract class ProtocolDbDto
    {


        [Key]
        public Guid ProtocolId { get; set; }
        public Guid ServicemanId { get; set; }
        public DateTime ProtocolDate { get; set; }
        public Guid EstateId { get; set; }
        public string DeviceSerialNumber { get; set; }
        public bool IsPositive { get; set; }
        public string Recommendations { get; set; }
        public List<string> PartsToBeReplaced { get; set; }

    }


}
