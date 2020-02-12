using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class InspectionProtocolRepository : IInspectionProtocolRepository
    {
        public void Add(InspectionProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.InspectionProtocols.Add(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public List<InspectionProtocol> GetProtocolList(Guid deviceId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.InspectionProtocols
                    .Where(p => p.DeviceId == deviceId.ToString()).ToList();
                var protocolList = new List<InspectionProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(InspectionProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDbDto = context.InspectionProtocols.Single(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Entry(protocolDbDto).CurrentValues.SetValues(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.InspectionProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
            }
        }

        public InspectionProtocol GetProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectionProtocolDto =
                    context.InspectionProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                return DtoToModel(inspectionProtocolDto);
            }
        }

        private InspectionProtocolDbDto ModelToDto(InspectionProtocol protocol)
        {
            var protocolDto = new InspectionProtocolDbDto
            {
                DeviceSerialNumber = protocol.DeviceSerialNumber,
                Recommendations = protocol.Recommendations,
                EstateId = protocol.EstateId.ToString(),
                IsPositive = protocol.IsPositive,
                PartsToBeReplaced = protocol.PartsToBeReplaced,
                ProtocolDate = protocol.ProtocolDate.ToString("d"),
                ProtocolId = protocol.ProtocolId.ToString(),
                ServicemanId = protocol.ServicemanId.ToString()
            };
            return protocolDto;
        }

        private InspectionProtocol DtoToModel(InspectionProtocolDbDto protocolDbDto)
        {
            var protocol = new InspectionProtocol(Guid.Parse(protocolDbDto.EstateId), Guid.Parse(protocolDbDto.ServicemanId),
                DateTime.Parse(protocolDbDto.ProtocolDate), protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, Guid.Parse(protocolDbDto.ProtocolId),
                Guid.Parse(protocolDbDto.DeviceId));
            return protocol;
        }

    }
}
