using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ServiceManager.Domain
{
    public class Protocol
    {
        public Protocol(string servicemanName, DateTime protocolDate, City city, DeviceType device, string address, string serialNumber, bool isPositive, string recommendations, List<string> partsToBeReplaced, ProtocolKind protocolKind)
        {
            ServicemanName = servicemanName;
            ProtocolDate = protocolDate;
            City = city;
            Device = device;
            Address = address;
            SerialNumber = serialNumber;
            IsPositive = isPositive;
            Recommendations = recommendations;
            PartsToBeReplaced = partsToBeReplaced;
            ProtocolKind = protocolKind;
        }

        public ProtocolKind ProtocolKind { get; } 
        public string ServicemanName { get; }
        public DateTime ProtocolDate { get; }
        public City City { get; }
        public DeviceType Device { get; }
        public string Address { get; }
        public string SerialNumber { get; }
        public bool IsPositive { get; }
        public string Recommendations { get; }
        public List<string> PartsToBeReplaced { get; }

        public void GenerateProtocol(IProtocolGenerator generator)
        {
            generator.GenerateProtocol(this);
        }

    }

    public interface IProtocolGenerator
    {
        void GenerateProtocol(Protocol protocol);

    }
}
