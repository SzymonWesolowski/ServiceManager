using System;
using System.Collections.Generic;

namespace ServiceManager.Domain.Model
{
    public class Device
    {
        public Device(string deviceType, int parkPlaces, string parkPlacesNumbers, string deviceSerialNumber,
            DateTime productionYear, Guid estateId, Guid deviceId, DateTime lastInspectionDate)
        {
            DeviceType = deviceType;
            ParkPlaces = parkPlaces;
            ParkPlacesNumbers = parkPlacesNumbers;
            DeviceSerialNumber = deviceSerialNumber;
            ProductionYear = productionYear;
            EstateId = estateId;
            DeviceId = deviceId;
            LastInspectionDate = lastInspectionDate;
        }

        public string DeviceType { get; }
        public int ParkPlaces { get; }
        public string ParkPlacesNumbers { get; }
        public string DeviceSerialNumber { get; }
        public DateTime ProductionYear { get; }
        public Guid EstateId { get; }
        public Guid DeviceId { get; }
        public DateTime LastInspectionDate { get; }
    }
}