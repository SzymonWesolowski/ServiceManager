﻿using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RepairProtocol : Protocol
    {
        public RepairProtocol(Estate estate, Device device, Serviceman serviceman, DateTime protocolDate,
            bool isPositive, string recommendations, List<string> partsToBeReplaced, string causeOfFailure, string repairDescription) : base(estate, device, serviceman,
            protocolDate, isPositive, recommendations, partsToBeReplaced)
        {
            CauseOfFailure = causeOfFailure;
            RepairDescription = repairDescription;
        }
        public string CauseOfFailure { get; }
        public string RepairDescription { get; }
    }
}