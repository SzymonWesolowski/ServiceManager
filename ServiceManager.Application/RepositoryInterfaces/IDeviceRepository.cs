using System;
using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IDeviceRepository
    {
        void AddDevice(Device device);
        List<Device> GetDevices(Guid estateId);
        void ModifyDevice(Device device);
        void DeleteDevice(Device device);
        Device GetDevice(string deviceId);
    }
}