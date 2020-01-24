﻿using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RenovationProtocol : Protocol
    {
        public RenovationProtocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, List<string> partsToBeReplaced, string deviceSerialNumber,
            List<string> partsReplaced) : base(estateId,
            servicemanId, protocolDate, isPositive, recommendations, partsToBeReplaced, deviceSerialNumber)
        {
            PartsReplaced = partsReplaced;
        }

        public List<string> PartsReplaced { get; }
    }
}