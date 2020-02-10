using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class InspectionProtocolRepository : IInspectionProtocolRepository
    {
        public void Add(InspectionProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.InspectionProtocols.Add(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public List<InspectionProtocol> GetProtocolList(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.InspectionProtocols
                    .Where(p => p.DeviceSerialNumber == device.DeviceSerialNumber).ToList();
                var protocolList = new List<InspectionProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(InspectionProtocol oldProtocol, InspectionProtocol newProtocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocol = context.InspectionProtocols.SingleOrDefault(p => p.ProtocolId == oldProtocol.ProtocolId.ToString());
                context.Entry(protocol).CurrentValues.SetValues(ModelToDto(newProtocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(InspectionProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.InspectionProtocols.SingleOrDefault(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
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
                ProtocolDate = protocol.ProtocolDate.ToString(),
                ProtocolId = protocol.ProtocolId.ToString(),
                ServicemanId = protocol.ServicemanId.ToString()
            };
            return protocolDto;
        }

        private InspectionProtocol DtoToModel(InspectionProtocolDbDto protocolDbDto)
        {
            var protocol = new InspectionProtocol(Guid.Parse(protocolDbDto.EstateId), Guid.Parse(protocolDbDto.ServicemanId),
                DateTime.Parse(protocolDbDto.ProtocolDate), protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, Guid.Parse(protocolDbDto.ProtocolId));
            return protocol;
        }

    }
}
