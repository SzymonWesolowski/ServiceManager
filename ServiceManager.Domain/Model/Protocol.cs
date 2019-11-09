using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public abstract class Protocol
    {
        protected Protocol(string servicemanName, DateTime protocolDate, City city, DeviceType device, string address, string serialNumber, bool isPositive, string recommendations, List<string> partsToBeReplaced)
        {
            ServicemanName = servicemanName;
            ProtocolDate = protocolDate;
            City = city;
            Device = device;
            Address = address;
            SerialNumber = serialNumber;
            IsPositive = isPositive;
            Recommendations = recommendations;
            PartsToBeReplaced = partsToBeReplaced;
        }

        public string ServicemanName { get; }
        public DateTime ProtocolDate { get; }
        public City City { get; }
        public DeviceType Device { get; }
        public string Address { get; }
        public string SerialNumber { get; }
        public bool IsPositive { get; }
        public string Recommendations { get; }
        public List<string> PartsToBeReplaced { get; }

    }


}
