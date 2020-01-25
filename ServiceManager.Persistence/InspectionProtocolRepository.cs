﻿using System;
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
            using (var context = new ServiceContext())
            {
                context.InspectionProtocols.Add(ModelToDto(protocol));
                context.SaveChanges();
            }
        }

        public List<InspectionProtocol> GetProtocolList(Device device)
        {
            using (var context = new ServiceContext())
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
            using (var context = new ServiceContext())
            {
                var protocol = context.InspectionProtocols.SingleOrDefault(p => p.ProtocolId == oldProtocol.ProtocolId);
                context.Entry(protocol).CurrentValues.SetValues(ModelToDto(newProtocol));
                context.SaveChanges();
            }
        }

        public void DeleteProtocol(InspectionProtocol protocol)
        {
            using (var context = new ServiceContext())
            {
                var protocolDto = context.InspectionProtocols.SingleOrDefault(p => p.ProtocolId == protocol.ProtocolId);
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
                EstateId = protocol.EstateId,
                IsPositive = protocol.IsPositive,
                PartsToBeReplaced = protocol.PartsToBeReplaced,
                ProtocolDate = protocol.ProtocolDate,
                ProtocolId = protocol.ProtocolId,
                ServicemanId = protocol.ServicemanId
            };
            return protocolDto;
        }

        private InspectionProtocol DtoToModel(InspectionProtocolDbDto protocolDbDto)
        {
            var protocol = new InspectionProtocol(protocolDbDto.EstateId, protocolDbDto.ServicemanId,
                protocolDbDto.ProtocolDate, protocolDbDto.IsPositive, protocolDbDto.Recommendations,
                protocolDbDto.PartsToBeReplaced, protocolDbDto.DeviceSerialNumber, protocolDbDto.ProtocolId);
            return protocol;
        }

    }
}