using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IRenovationProtocolRepository
    {
        void Add(RenovationProtocol protocol);
        List<RenovationProtocol> GetProtocolList(Device device);
        void ModifyProtocol(RenovationProtocol oldProtocol, RenovationProtocol newProtocol);
        void DeleteProtocol(RenovationProtocol protocol);
    }
}
