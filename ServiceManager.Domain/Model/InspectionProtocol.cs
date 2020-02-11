using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class InspectionProtocol : Protocol
    {
        public InspectionProtocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, string partsToBeReplaced, string deviceSerialNumber, Guid protocolId, Guid deviceId)
            : base(estateId, servicemanId, protocolDate, isPositive, recommendations, partsToBeReplaced,
                deviceSerialNumber, protocolId, deviceId)
        {
        }
    }
}