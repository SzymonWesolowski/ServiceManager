using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceManager.Application
{
    public interface IInspectionProtocolOperations
    {
        List<InspectionProtocol> GetInspectionProtocolList(Guid deviceId);
        void DeleteInspectionProtocol(Guid protocolId);
        void AddInspectionProtocol(InspectionProtocol inspectionProtocol);
        void ModifyInspectionProtocol(InspectionProtocol inspectionProtocol);
        InspectionProtocol GetInspectionProtocol(Guid protocolId);
    }

    public class InspectionProtocolOperations : IInspectionProtocolOperations
    {
        private readonly IInspectionProtocolRepository _inspectionProtocolRepository;
        private readonly IDeviceRepository _deviceRepository;

        public InspectionProtocolOperations(IInspectionProtocolRepository inspectionProtocolRepository,
            IDeviceRepository deviceRepository)
        {
            _inspectionProtocolRepository = inspectionProtocolRepository;
            _deviceRepository = deviceRepository;
        }

        public List<InspectionProtocol> GetInspectionProtocolList(Guid deviceId)
        {
            return _inspectionProtocolRepository.GetProtocolList(deviceId);
        }

        public void DeleteInspectionProtocol(Guid protocolId)
        {
            var protocol = _inspectionProtocolRepository.GetProtocol(protocolId);
            var device = _deviceRepository.GetDevice(protocol.DeviceId);
            if (device.LastInspectionDate == protocol.ProtocolDate)
            {
                var protocolList = _inspectionProtocolRepository.GetProtocolList(device.DeviceId);
                var latestProtocol = protocolList.Aggregate((p1, p2) => p1.ProtocolDate > p2.ProtocolDate ? p1 : p2);
                var updatedDevice = UpdateLastInspectionDate(device, latestProtocol);
                _deviceRepository.ModifyDevice(updatedDevice);
            }

            _inspectionProtocolRepository.DeleteProtocol(protocolId);
        }

        public void AddInspectionProtocol(InspectionProtocol inspectionProtocol)
        {
            _inspectionProtocolRepository.Add(inspectionProtocol);
            var device = _deviceRepository.GetDevice(inspectionProtocol.DeviceId);
            var updatedDevice = UpdateLastInspectionDate(device, inspectionProtocol);
            _deviceRepository.ModifyDevice(updatedDevice);
        }

        public void ModifyInspectionProtocol(InspectionProtocol inspectionProtocol)
        {
            var oldProtocol = _inspectionProtocolRepository.GetProtocol(inspectionProtocol.ProtocolId);
            var device = _deviceRepository.GetDevice(inspectionProtocol.DeviceId);
            _inspectionProtocolRepository.ModifyProtocol(inspectionProtocol);

            if (oldProtocol.ProtocolDate != device.LastInspectionDate ||
                oldProtocol.ProtocolDate == inspectionProtocol.ProtocolDate) return;
            var updatedDevice = UpdateLastInspectionDate(device, inspectionProtocol);
            _deviceRepository.ModifyDevice(updatedDevice);
        }

        public InspectionProtocol GetInspectionProtocol(Guid protocolId)
        {
            return _inspectionProtocolRepository.GetProtocol(protocolId);
        }

        private Device UpdateLastInspectionDate(Device device, Protocol inspectionProtocol)
        {
            return new Device(device.DeviceType, device.ParkPlaces, device.ParkPlacesNumbers,
                device.DeviceSerialNumber, device.ProductionYear, device.EstateId, device.DeviceId,
                inspectionProtocol.ProtocolDate);
        }
    }
}