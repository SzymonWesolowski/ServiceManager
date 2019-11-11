using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class RenovationProtocol : Protocol
    {
        public RenovationProtocol(Estate estate, Device device, Serviceman serviceman, DateTime protocolDate,
            bool isPositive, string recommendations, List<string> partsToBeReplaced, List<string> partsReplaced) : base(estate, device, serviceman,
            protocolDate, isPositive, recommendations, partsToBeReplaced)
        {
            PartsReplaced = partsReplaced;
        }
        public List<string> PartsReplaced { get; }
       
    }
}