using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RenovationProtocol : Protocol
    {
        public RenovationProtocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, string partsToBeReplaced, string deviceSerialNumber, Guid protocolId,
            string partsReplaced) : base(estateId, servicemanId, protocolDate, isPositive, recommendations, partsToBeReplaced, deviceSerialNumber, protocolId)
        {
            PartsReplaced = partsReplaced;
        }

        public string PartsReplaced { get; }

    }
}