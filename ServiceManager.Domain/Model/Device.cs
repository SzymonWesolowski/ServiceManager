using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Device
    {
        public Device(string deviceType, int parkPlaces, List<string> parkPlacesNumbers, string deviceSerialNumber,
            DateTime productionYear, Guid estateId, Guid deviceId)
        {
            DeviceType = deviceType;
            ParkPlaces = parkPlaces;
            ParkPlacesNumbers = parkPlacesNumbers;
            DeviceSerialNumber = deviceSerialNumber;
            ProductionYear = productionYear;
            EstateId = estateId;
            DeviceId = deviceId;
        }

        public string DeviceType { get; }
        public int ParkPlaces { get; }
        public List<string> ParkPlacesNumbers { get; }
        public string DeviceSerialNumber { get; }
        public DateTime ProductionYear { get; }
        public Guid EstateId { get; }
        public Guid DeviceId { get; }
    }
}