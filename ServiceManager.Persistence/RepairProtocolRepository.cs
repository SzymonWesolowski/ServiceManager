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
            using (var context = new ServiceContext())
            {
                context.RepairProtocols.Add(ModelToDto(repairProtocol));
                context.SaveChanges();
            }
        }

        public List<RepairProtocol> GetProtocolList(Device device)
        {
            using (var context = new ServiceContext())
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
            using (var context = new ServiceContext())
            {
                var protocol = context.RepairProtocols.SingleOrDefault(p => p.ProtocolId == oldProtocol.ProtocolId);
                context.Entry(protocol).CurrentValues.SetValues(ModelToDto(newProtocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(RepairProtocol protocol)
        {
            using (var context = new ServiceContext())
            {
                var protocolDto = context.RepairProtocols.SingleOrDefault(p => p.ProtocolId == protocol.ProtocolId);
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
                EstateId = protocol.EstateId,
                IsPositive = protocol.IsPositive,
                PartsToBeReplaced = protocol.PartsToBeReplaced,
                ProtocolDate = protocol.ProtocolDate,
                ProtocolId = protocol.ProtocolId,
                ServicemanId = protocol.ServicemanId,
                RepairDescription = protocol.RepairDescription,
                CauseOfFailure = protocol.CauseOfFailure
            };
            return protocolDto;
        }

        private RepairProtocol DtoToModel(RepairProtocolDbDto protocolDbDto)
        {
            var protocol = new RepairProtocol(protocolDbDto.EstateId, protocolDbDto.ServicemanId,
                protocolDbDto.ProtocolDate, protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, protocolDbDto.ProtocolId,
                protocolDbDto.CauseOfFailure, protocolDbDto.RepairDescription);
            return protocol;
        }
    }
}
