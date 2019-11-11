using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RepairProtocol : Protocol
    {
        public RepairProtocol(string servicemanName, DateTime protocolDate, CityEnum city, DeviceTypeEnum device,
            string address, string serialNumber, bool isPositive, string recommendations,
            List<string> partsToBeReplaced) : base(servicemanName, protocolDate, city,
            device, address, serialNumber, isPositive, recommendations, partsToBeReplaced)
        {
        }





    }
}