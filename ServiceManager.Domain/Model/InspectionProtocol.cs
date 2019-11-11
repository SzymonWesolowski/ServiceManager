using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class InspectionProtocol : Protocol
    {
        public InspectionProtocol(Estate estate, Device device, Serviceman serviceman, DateTime protocolDate,
            bool isPositive, string recommendations, List<string> partsToBeReplaced, string causeOfFailure, string repairDescription) : base(estate, device, serviceman,
            protocolDate, isPositive, recommendations, partsToBeReplaced)
        {

        }

    }
}