using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public abstract class Protocol
    {
        protected Protocol(Guid estateId, Guid servicemanId, DateTime protocolDate, bool isPositive,
            string recommendations, string partsToBeReplaced, string deviceSerialNumber, Guid protocolId, Guid deviceId)
        {
            EstateId = estateId;
            ServicemanId = servicemanId;
            ProtocolDate = protocolDate;
            IsPositive = isPositive;
            Recommendations = recommendations;
            PartsToBeReplaced = partsToBeReplaced;
            DeviceSerialNumber = deviceSerialNumber;
            ProtocolId = protocolId;
            DeviceId = deviceId;
        }


        public Guid ServicemanId { get; }
        public DateTime ProtocolDate { get; }
        public Guid EstateId { get; }
        public string DeviceSerialNumber { get; }
        public bool IsPositive { get; }
        public string Recommendations { get; }
        public string PartsToBeReplaced { get; }
        public Guid ProtocolId { get; }
        public Guid DeviceId { get; }

    }


}
