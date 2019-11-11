using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Domain.Model
{
    public class Device
    {
        public Device(DeviceTypeEnum deviceType, int parkPlaces, List<string> parkPlacesNumbers, string deviceSerialNumber, DateTime productionYear, Estate estate)
        {
            DeviceType = deviceType;
            ParkPlaces = parkPlaces;
            ParkPlacesNumbers = parkPlacesNumbers;
            DeviceSerialNumber = deviceSerialNumber;
            ProductionYear = productionYear;
            Estate = estate;
        }

        public DeviceTypeEnum DeviceType { get; }
        public int ParkPlaces { get; }
        public List<string> ParkPlacesNumbers { get; }
        public string DeviceSerialNumber { get; }
        public DateTime ProductionYear { get; }
        public Estate Estate { get; }

    }
}
