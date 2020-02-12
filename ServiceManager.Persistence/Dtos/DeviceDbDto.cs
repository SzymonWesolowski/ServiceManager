using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServiceManager.Domain.Model
{
    public class DeviceDbDto
    {
        [Key]
        public  string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public int ParkPlaces { get; set; }
        public string ParkPlacesNumbers { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string ProductionYear { get; set; }
        public string EstateId { get; set; }
    }
}