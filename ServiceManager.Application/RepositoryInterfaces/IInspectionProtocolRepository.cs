using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IInspectionProtocolRepository
    {
        void Add(InspectionProtocol protocol);
        List<InspectionProtocol> GetProtocolList(Device device);
        void ModifyProtocol(InspectionProtocol oldProtocol, InspectionProtocol newProtocol);
        void DeleteProtocol(InspectionProtocol protocol);
    }
}
