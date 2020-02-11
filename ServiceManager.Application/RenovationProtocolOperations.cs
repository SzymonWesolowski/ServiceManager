using System;
using System.Collections.Generic;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IRenovationProtocolOperations
    {
        List<RenovationProtocol> GetRenovationProtocolList(Guid deviceId);
        void DeleteRenovationProtocol(Guid protocolId);
        void AddRenovationProtocol(RenovationProtocol renovationProtocol);
        void ModifyRenovationProtocol(RenovationProtocol renovationProtocol);
        RenovationProtocol GetRenovationProtocol(Guid protocolId);
    }

    public class RenovationProtocolOperations : IRenovationProtocolOperations
    {
        private readonly IRenovationProtocolRepository _renovationProtocolRepository;

        public RenovationProtocolOperations(IRenovationProtocolRepository renovationProtocolRepository)
        {
            _renovationProtocolRepository = renovationProtocolRepository;
        }

        public List<RenovationProtocol> GetRenovationProtocolList(Guid deviceId)
        {
            return _renovationProtocolRepository.GetProtocolList(deviceId);
        }

        public void DeleteRenovationProtocol(Guid protocolId)
        {
            _renovationProtocolRepository.DeleteProtocol(protocolId);
        }

        public void AddRenovationProtocol(RenovationProtocol renovationProtocol)
        {
            _renovationProtocolRepository.Add(renovationProtocol);
        }

        public void ModifyRenovationProtocol(RenovationProtocol renovationProtocol)
        {
            _renovationProtocolRepository.ModifyProtocol(renovationProtocol);
        }

        public RenovationProtocol GetRenovationProtocol(Guid protocolId)
        {
            return _renovationProtocolRepository.GetProtocol(protocolId);
        }
    }
}
