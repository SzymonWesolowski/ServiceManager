using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class RepairProtocolRepository : IRepairProtocolRepository
    {
        public void Add(RepairProtocol repairProtocol)
        {
            using (var context = new ServiceManagerContext())
            {
                context.RepairProtocols.Add(ModelToDto(repairProtocol));
                context.SaveChanges();
            }
        }

        public List<RepairProtocol> GetProtocolList(Guid deviceId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDtoList = context.RepairProtocols
                    .Where(p => p.DeviceId == deviceId.ToString()).ToList();
                var protocolList = new List<RepairProtocol>();

                foreach (var protocolDto in protocolDtoList)
                {
                    protocolList.Add(DtoToModel(protocolDto));
                }

                return protocolList;
            }
        }

        public void ModifyProtocol(RepairProtocol protocol)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDbDto = context.RepairProtocols.Single(p => p.ProtocolId == protocol.ProtocolId.ToString());
                context.Entry(protocolDbDto).CurrentValues.SetValues(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.RepairProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                context.Attach(protocolDto);
                context.Remove(protocolDto);
                context.SaveChanges();
            }
        }

        public RepairProtocol GetProtocol(Guid protocolId)
        {
            using (var context = new ServiceManagerContext())
            {
                var protocolDto = context.RepairProtocols.Single(p => p.ProtocolId == protocolId.ToString());
                return DtoToModel(protocolDto);
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
                ProtocolDate = protocol.ProtocolDate.ToString("d"),
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