using System;
using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    internal interface IDeviceOperations
    {
        void AddDevice(string deviceType, int parkPlaces, List<string> parkPlacesNumbers, string deviceSerialNumber,
            DateTime productionYear, Estate estate);

        void AddDeviceList(List<Device> devices);
        List<Device> GetDeviceList(Estate estate);
        void RemoveDevice(Device device);
        void RemoveDeviceList(List<Device> devices);
    }

    class DeviceOperations : IDeviceOperations
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceOperations(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public void AddDevice(string deviceType, int parkPlaces, List<string> parkPlacesNumbers,
            string deviceSerialNumber,
            DateTime productionYear, Estate estate)
        {
            var device = new Device(deviceType, parkPlaces, parkPlacesNumbers, deviceSerialNumber, productionYear,
                estate);
            _deviceRepository.AddDevice(device);
        }

        public void AddDeviceList(List<Device> devices)
        {
            foreach (var device in devices)
            {
                _deviceRepository.AddDevice(device);
            }
        }

        public List<Device> GetDeviceList(Estate estate)
        {
            return _deviceRepository.GetDevices(estate);
        }

        public void RemoveDevice(Device device)
        {
            _deviceRepository.DeleteDevice(device);
        }

        public void RemoveDeviceList(List<Device> devices)
        {
            foreach (var device in devices)
            {
                _deviceRepository.DeleteDevice(device);
            }
        }
    }
}