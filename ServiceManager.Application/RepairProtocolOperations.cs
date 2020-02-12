using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IRepairProtocolOperations
    {
        List<RepairProtocol> GetRepairProtocolList(Guid deviceId);
        void DeleteRepairProtocol(Guid protocolId);
        void AddRepairProtocol(RepairProtocol repairProtocol);
        void ModifyRepairProtocol(RepairProtocol repairProtocol);
        RepairProtocol GetRepairProtocol(Guid protocolId);
    }

    public class RepairProtocolOperations : IRepairProtocolOperations
    {
        private readonly IRepairProtocolRepository _repairProtocolRepository;

        public RepairProtocolOperations(IRepairProtocolRepository repairProtocolRepository)
        {
            _repairProtocolRepository = repairProtocolRepository;
        }

        public List<RepairProtocol> GetRepairProtocolList(Guid deviceId)
        {
            return _repairProtocolRepository.GetProtocolList(deviceId);
        }

        public void DeleteRepairProtocol(Guid protocolId)
        {
            _repairProtocolRepository.DeleteProtocol(protocolId);
        }

        public void AddRepairProtocol(RepairProtocol repairProtocol)
        {
            _repairProtocolRepository.Add(repairProtocol);
        }

        public void ModifyRepairProtocol(RepairProtocol repairProtocol)
        {
            _repairProtocolRepository.ModifyProtocol(repairProtocol);
        }

        public RepairProtocol GetRepairProtocol(Guid protocolId)
        {
            return _repairProtocolRepository.GetProtocol(protocolId);
        }
    }
}
