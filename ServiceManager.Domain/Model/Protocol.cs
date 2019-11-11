using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public abstract class Protocol
    {
        protected Protocol(Estate estate, Device device, Serviceman serviceman, DateTime protocolDate, bool isPositive, string recommendations, List<string> partsToBeReplaced)
        {
            Estate = estate;
            Device = device;
            Serviceman = serviceman;
            ProtocolDate = protocolDate;
            IsPositive = isPositive;
            Recommendations = recommendations;
            PartsToBeReplaced = partsToBeReplaced;
        }


        public Serviceman Serviceman { get; }
        public DateTime ProtocolDate { get; }
        public Estate Estate { get; }
        public Device Device { get; }
        public bool IsPositive { get; }
        public string Recommendations { get; }
        public List<string> PartsToBeReplaced { get; }

    }


}
