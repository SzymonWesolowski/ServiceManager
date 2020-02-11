using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IRenovationProtocolRepository
    {
        void Add(RenovationProtocol protocol);
        List<RenovationProtocol> GetProtocolList(Guid deviceId);
        void ModifyProtocol(RenovationProtocol protocol);
        void DeleteProtocol(Guid protocolId);
        RenovationProtocol GetProtocol(Guid protocolId);
    }
}
