using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    internal interface IDeviceRepository
    {
        void AddDevice(Device device);
        List<Device> GetDevices(Estate estate);
        void ModifyDevice(Device oldDevice, Device newDevice);
        void DeleteDevice(Device device);
    }
}