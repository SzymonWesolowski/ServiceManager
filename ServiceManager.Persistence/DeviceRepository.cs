﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class DeviceRepository : IDeviceRepository
    {
        public void AddDevice(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDbDto = ModelToDto(device);
                context.Devices.Add(deviceDbDto);
                context.SaveChanges();
            }
        }

        public List<Device> GetDevices(Estate estate)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDtoList = context.Devices.ToList();
                var deviceList = new List<Device>();
                foreach (var deviceDbDto in deviceDtoList)
                {
                    deviceList.Add(DtoToModel(deviceDbDto));
                }

                return deviceList;
            }
        }

        public void ModifyDevice(Device oldDevice, Device newDevice)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDbDto =
                    context.Devices.FirstOrDefault(d => d.DeviceId == oldDevice.DeviceId.ToString());
                context.Entry(deviceDbDto).CurrentValues.SetValues(ModelToDto(newDevice));
                context.SaveChanges();
            }
        }

        public void DeleteDevice(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDto = context.Devices.SingleOrDefault(d => d.DeviceId == device.DeviceId.ToString());
                context.Devices.Attach(deviceDto);
                context.Devices.Remove(deviceDto);
                context.SaveChanges();
            }
        }

        private DeviceDbDto ModelToDto(Device device)
        {
            var deviceDto = new DeviceDbDto();
            deviceDto.DeviceSerialNumber = device.DeviceSerialNumber;
            deviceDto.DeviceType = device.DeviceType;
            deviceDto.EstateId = device.EstateId.ToString();
            deviceDto.ParkPlaces = device.ParkPlaces;
            deviceDto.ParkPlacesNumbers = device.ParkPlacesNumbers;
            deviceDto.ProductionYear = device.ProductionYear.ToString();
            deviceDto.DeviceId = device.DeviceId.ToString();
            return deviceDto;
        }

        private Device DtoToModel(DeviceDbDto deviceDbDto)
        {
            var device = new Device(deviceDbDto.DeviceType, deviceDbDto.ParkPlaces, deviceDbDto.ParkPlacesNumbers,
                deviceDbDto.DeviceSerialNumber, DateTime.Parse(deviceDbDto.ProductionYear),Guid.Parse(deviceDbDto.EstateId),
                Guid.Parse(deviceDbDto.DeviceId));
            return device;
        }
    }
}