using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class RepairProtocolRepository : IRepairProtocolRepository
    {
        public void Add(RepairProtocol repairProtocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.RepairProtocols.Add(ModelToDto(repairProtocol));
                context.SaveChanges();
            }
        }

        public List<RepairProtocol> GetProtocolList(Device device)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.RepairProtocols
                    .Where(p => p.DeviceSerialNumber == device.DeviceSerialNumber).ToList();
                var protocolList = new List<RepairProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(RepairProtocol oldProtocol, RepairProtocol newProtocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocol = context.RepairProtocols.Single(p => p.ProtocolId == oldProtocol.ProtocolId.ToString());
                context.Entry(protocol).CurrentValues.SetValues(ModelToDto(newProtocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(RepairProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.RepairProtocols.Single(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
            }
        }

        private RepairProtocolDbDto ModelToDto(RepairProtocol protocol)
        {
            var protocolDto = new RepairProtocolDbDto()
            {
                DeviceSerialNumber = protocol.DeviceSerialNumber,
                Recommendations = protocol.Recommendations,
                EstateId = protocol.EstateId.ToString(),
                IsPositive = protocol.IsPositive,
                PartsToBeReplaced = protocol.PartsToBeReplaced,
                ProtocolDate = protocol.ProtocolDate.ToString(),
                ProtocolId = protocol.ProtocolId.ToString(),
                ServicemanId = protocol.ServicemanId.ToString(),
                RepairDescription = protocol.RepairDescription,
                CauseOfFailure = protocol.CauseOfFailure
            };
            return protocolDto;
        }

        private RepairProtocol DtoToModel(RepairProtocolDbDto protocolDbDto)
        {
            var protocol = new RepairProtocol(Guid.Parse(protocolDbDto.EstateId), Guid.Parse(protocolDbDto.ServicemanId),
                DateTime.Parse(protocolDbDto.ProtocolDate), protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, Guid.Parse(protocolDbDto.ProtocolId),
                protocolDbDto.CauseOfFailure, protocolDbDto.RepairDescription, Guid.Parse(protocolDbDto.DeviceId));
            return protocol;
        }
    }
}