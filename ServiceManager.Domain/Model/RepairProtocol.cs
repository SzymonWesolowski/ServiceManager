using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RepairProtocol : Protocol
    {
        public RepairProtocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, List<string> partsToBeReplaced, string deviceSerialNumber, string causeOfFailure,
            string repairDescription) : base(estateId, servicemanId, protocolDate, isPositive, recommendations,
            partsToBeReplaced, deviceSerialNumber)
        {
            CauseOfFailure = causeOfFailure;
            RepairDescription = repairDescription;
        }

        public string CauseOfFailure { get; }
        public string RepairDescription { get; }
    }
}