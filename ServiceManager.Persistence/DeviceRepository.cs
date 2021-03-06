﻿using System;
using System.Collections.Generic;
using System.Linq;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class DeviceRepository : IDeviceRepository
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

        public List<Device> GetDevices(Guid estateId)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDtoList = context.Devices.Where(d => d.EstateId == estateId.ToString());
                var deviceList = new List<Device>();
                foreach (var deviceDbDto in deviceDtoList)
                {
                    deviceList.Add(DtoToModel(deviceDbDto));
                }

                return deviceList;
            }
        }

        public void ModifyDevice(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDbDto =
                    context.Devices.Single(d => d.DeviceId == device.DeviceId.ToString());
                context.Entry(deviceDbDto).CurrentValues.SetValues(ModelToDto(device));
                context.SaveChanges();
            }
        }

        public void DeleteDevice(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDto = context.Devices.Single(d => d.DeviceId == device.DeviceId.ToString());
                context.Devices.Attach(deviceDto);
                context.Devices.Remove(deviceDto);
                context.SaveChanges();
            }
        }

        public Device GetDevice(Guid deviceId)
        {
            using (var context = new ServiceManagerContext())
            {
                var deviceDto = context.Devices.Single(d => d.DeviceId == deviceId.ToString());
                return DtoToModel(deviceDto);
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
            deviceDto.ProductionYear = device.ProductionYear.ToString("d");
            deviceDto.DeviceId = device.DeviceId.ToString();
            deviceDto.LastInspectionDate = device.LastInspectionDate.ToString("d");
            return deviceDto;
        }

        private Device DtoToModel(DeviceDbDto deviceDbDto)
        {
            var device = new Device(deviceDbDto.DeviceType, deviceDbDto.ParkPlaces, deviceDbDto.ParkPlacesNumbers,
                deviceDbDto.DeviceSerialNumber, DateTime.Parse(deviceDbDto.ProductionYear),Guid.Parse(deviceDbDto.EstateId),
                Guid.Parse(deviceDbDto.DeviceId), DateTime.Parse(deviceDbDto.LastInspectionDate));
            return device;
        }
    }
}