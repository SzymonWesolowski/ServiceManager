using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class RenovationProtocolRepository : IRenovationProtocolRepository
    {
        public void Add(RenovationProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.RenovationProtocols.Add(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public List<RenovationProtocol> GetProtocolList(Guid deviceId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.RenovationProtocols
                    .Where(p => p.DeviceSerialNumber == deviceId.ToString()).ToList();
                var protocolList = new List<RenovationProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(RenovationProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDbDto = context.RenovationProtocols.Single(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Entry(protocolDbDto).CurrentValues.SetValues(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.RenovationProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
            }
        }

        public RenovationProtocol GetProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var renovationProtocolDto =
                    context.RenovationProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                return DtoToModel(renovationProtocolDto);
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
                protocolDbDto.PartsReplaced, Guid.Parse(protocolDbDto.DeviceId));
            return protocol;
        }
    }
}
