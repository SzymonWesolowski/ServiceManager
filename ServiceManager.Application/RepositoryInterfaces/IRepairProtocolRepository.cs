using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IRepairProtocolRepository
    {
        void Add(RepairProtocol repairProtocol);
        List<RepairProtocol> GetProtocolList(Guid deviceId);
        void ModifyProtocol(RepairProtocol protocol);
        void DeleteProtocol(Guid protocolId);
        RepairProtocol GetProtocol(Guid protocolId);
    }
}
