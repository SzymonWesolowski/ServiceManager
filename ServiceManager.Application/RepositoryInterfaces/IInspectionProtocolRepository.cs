using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IInspectionProtocolRepository
    {
        void Add(InspectionProtocol protocol);
        List<InspectionProtocol> GetProtocolList(Guid deviceId);
        void ModifyProtocol(InspectionProtocol Protocol);
        void DeleteProtocol(Guid protocolId);
        InspectionProtocol GetProtocol(Guid protocolId);
    }
}
