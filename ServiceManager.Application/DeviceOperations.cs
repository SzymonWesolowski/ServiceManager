using System;
using System.Collections.Generic;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IDeviceOperations
    {
        void AddDevice(Device device);

        void AddDeviceList(List<Device> devices);
        List<Device> GetDeviceList(Guid estateId);
        void RemoveDevice(Device device);
        void RemoveDeviceList(List<Device> devices);
        Device GetDevice(string deviceId);
        void ModifyDevice(Device device);
    }

    public class DeviceOperations : IDeviceOperations
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceOperations(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public void AddDevice(Device device)
        {
            _deviceRepository.AddDevice(device);
        }

        public void AddDeviceList(List<Device> devices)
        {
            foreach (var device in devices)
            {
                _deviceRepository.AddDevice(device);
            }
        }

        public List<Device> GetDeviceList(Guid estateId)
        {
            return _deviceRepository.GetDevices(estateId);
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

        public Device GetDevice(string deviceId)
        {
            return _deviceRepository.GetDevice(deviceId);
        }

        public void ModifyDevice(Device device)
        {
            _deviceRepository.ModifyDevice(device);
        }
    }
}