using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class EstateRepository : IEstateRepository
    {
        public void AddEstate(Estate estate)
        {
            using (var context = new ServiceContext())
            {
                context.Estates.Add(modelToDto(estate));
                context.SaveChanges();
            }
        }

        public List<Estate> GetEstateList()
        {
            using (var context = new ServiceContext())
            {
                var estateDtoList = context.Estates.ToList();
                var estateList = new List<Estate>();
                foreach (var estateDbDto in estateDtoList)
                {
                    estateList.Add(DtoToModel(estateDbDto));
                }

                return estateList;
            }
        }

        public void ModifyEstate(Estate oldEstate, Estate newEstate)
        {
            using (var context = new ServiceContext())
            {
                var estate = context.Estates.SingleOrDefault(e => e.EstateId == oldEstate.EstateId);
                context.Entry(estate).CurrentValues.SetValues(modelToDto(newEstate));
                context.SaveChanges();
            }
        }

        public void RemoveEstate(Estate estate)
        {
            using (var context = new ServiceContext())
            {
                var estateDto = context.Estates.SingleOrDefault(e => e.EstateId == estate.EstateId);
                context.Attach(estateDto);
                context.Remove(estateDto);
                context.SaveChanges();
            }
        }

        private EstateDbDto modelToDto(Estate estate)
        {
            var estateDbDto = new EstateDbDto();
            estateDbDto.EstateId = estate.EstateId;
            estateDbDto.City = estate.City;
            estateDbDto.InspectorId = estate.InspectorId;
            estateDbDto.LastInspectionDate = estate.LastInspectionDate;
            estateDbDto.Name = estate.Name;
            estateDbDto.PostCode = estate.PostCode;
            estateDbDto.Street = estate.Street;
            estateDbDto.UnderContract = estate.UnderContract;
            return estateDbDto;
        }

        private Estate DtoToModel(EstateDbDto estateDbDto)
        {
            var estate = new Estate(estateDbDto.Name, estateDbDto.City, estateDbDto.Street, estateDbDto.PostCode,
                estateDbDto.UnderContract, estateDbDto.LastInspectionDate, estateDbDto.EstateId,
                estateDbDto.InspectorId);
            return estate;
        }
    }
}
