using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IRepairProtocolRepository
    {
        void Add(RepairProtocol repairProtocol);
        List<RepairProtocol> GetProtocolList(Device device);
        void ModifyProtocol(RepairProtocol oldProtocol, RepairProtocol newProtocol);
        void DeleteProtocol(RepairProtocol protocol);

    }
}
