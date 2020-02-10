using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class RenovationProtocolRepository : IRenovationProtocolRepository
    {
        public void Add(RenovationProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.RenovationProtocols.Add(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public List<RenovationProtocol> GetProtocolList(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.RenovationProtocols
                    .Where(p => p.DeviceSerialNumber == device.DeviceSerialNumber).ToList();
                var protocolList = new List<RenovationProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(RenovationProtocol oldProtocol, RenovationProtocol newProtocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocol = context.RenovationProtocols.SingleOrDefault(p => p.ProtocolId == oldProtocol.ProtocolId.ToString());
                context.Entry(protocol).CurrentValues.SetValues(ModelToDto(newProtocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(RenovationProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.RenovationProtocols.SingleOrDefault(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
            }
        }

        private RenovationProtocolDbDto ModelToDto(RenovationProtocol protocol)
        {
            var protocolDto = new RenovationProtocolDbDto()
            {
                DeviceSerialNumber = protocol.DeviceSerialNumber,
                Recommendations = protocol.Recommendations,
                EstateId = protocol.EstateId.ToString(),
                IsPositive = protocol.IsPositive,
                PartsToBeReplaced = protocol.PartsToBeReplaced,
                ProtocolDate = protocol.ProtocolDate.ToString(),
                ProtocolId = protocol.ProtocolId.ToString(),
                ServicemanId = protocol.ServicemanId.ToString(),
                PartsReplaced = protocol.PartsReplaced
            };
            return protocolDto;
        }
        private RenovationProtocol DtoToModel(RenovationProtocolDbDto protocolDbDto)
        {
            var protocol = new RenovationProtocol(Guid.Parse(protocolDbDto.EstateId), Guid.Parse(protocolDbDto.ServicemanId),
                DateTime.Parse(  protocolDbDto.ProtocolDate), protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, Guid.Parse(protocolDbDto.ProtocolId),
                protocolDbDto.PartsReplaced);
            return protocol;
        }
    }
}
