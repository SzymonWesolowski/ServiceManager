using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RepairProtocol : Protocol
    {
        public RepairProtocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, string partsToBeReplaced, string deviceSerialNumber, Guid protocolId,
            string causeOfFailure, string repairDescription) : base(
            estateId, servicemanId, protocolDate, isPositive, recommendations, partsToBeReplaced, deviceSerialNumber,
            protocolId)
        {
            CauseOfFailure = causeOfFailure;
            RepairDescription = repairDescription;
        }

        public string CauseOfFailure { get; }
        public string RepairDescription { get; }

    }
}