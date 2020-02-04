using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class EstateRepository : IEstateRepository
    {
        public void AddEstate(Estate estate)
        {
            using (var context = new ServiceManagerContext())
            {
                context.Estates.Add(ModelToDto(estate));
                context.SaveChanges();
            }
        }

        public List<Estate> GetEstateList()
        {
            using (var context = new ServiceManagerContext())
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

        public void ModifyEstate(Estate Estate)
        {
            using (var context = new ServiceManagerContext())
            {
                var estate = context.Estates.SingleOrDefault(e => e.EstateId == Estate.EstateId);
                context.Entry(estate).CurrentValues.SetValues(ModelToDto(Estate));
                context.SaveChanges();
            }
        }

        public void RemoveEstate(Estate estate)
        {
            using (var context = new ServiceManagerContext())
            {
                var estateDto = context.Estates.SingleOrDefault(e => e.EstateId == estate.EstateId);
                context.Attach(estateDto);
                context.Remove(estateDto);
                context.SaveChanges();
            }
        }

        private EstateDbDto ModelToDto(Estate estate)
        {
            var estateDbDto = new EstateDbDto
            {
                EstateId = estate.EstateId,
                City = estate.City,
                InspectorId = estate.InspectorId,
                LastInspectionDate = estate.LastInspectionDate,
                Name = estate.Name,
                PostCode = estate.PostCode,
                Street = estate.Street,
                UnderContract = estate.UnderContract
            };
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
