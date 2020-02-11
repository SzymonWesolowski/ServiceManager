using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace ServiceManager.Application
{
    public interface IInspectionProtocolOperations
    {
        List<InspectionProtocol> GetInspectionProtocolList(string deviceSerialNumber);
        void DeleteInspectionProtocol(Guid protocolId);
        void AddInspectionProtocol(InspectionProtocol inspectionProtocol);
        void ModifyInspectionProtocol(InspectionProtocol inspectionProtocol);
        InspectionProtocol GetInspectionProtocol(Guid protocolId);
    }

    public class InspectionProtocolOperations : IInspectionProtocolOperations
    {
        private readonly IInspectionProtocolRepository _inspectionProtocolRepository;

        public InspectionProtocolOperations(IInspectionProtocolRepository inspectionProtocolRepository)
        {
            _inspectionProtocolRepository = inspectionProtocolRepository;
        }

        public List<InspectionProtocol> GetInspectionProtocolList(string deviceSerialNumber)
        {
            return _inspectionProtocolRepository.GetProtocolList(deviceSerialNumber);
        }

        public void DeleteInspectionProtocol(Guid protocolId)
        {
            _inspectionProtocolRepository.DeleteProtocol(protocolId);
        }

        public void AddInspectionProtocol(InspectionProtocol inspectionProtocol)
        {
            _inspectionProtocolRepository.Add(inspectionProtocol);
        }

        public void ModifyInspectionProtocol(InspectionProtocol inspectionProtocol)
        {
            _inspectionProtocolRepository.ModifyProtocol(inspectionProtocol);
        }

        public InspectionProtocol GetInspectionProtocol(Guid protocolId)
        {
            return _inspectionProtocolRepository.GetProtocol(protocolId);
        }
    }
}