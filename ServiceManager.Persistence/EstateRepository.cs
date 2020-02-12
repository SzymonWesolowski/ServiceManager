using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class EstateRepository : IEstateRepository
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
                var estate = context.Estates.Single(e => e.EstateId == Estate.EstateId.ToString());
                context.Entry(estate).CurrentValues.SetValues(ModelToDto(Estate));
                context.SaveChanges();
            }
        }

        public void RemoveEstate(Guid estateId)
        {
            using (var context = new ServiceManagerContext())
            {
                var estateDto = context.Estates.Single(e => e.EstateId == estateId.ToString());
                context.Attach(estateDto);
                context.Remove(estateDto);
                context.SaveChanges();
            }
        }

        public Estate GetEstate(Guid estateGuid)
        {
            using (var context = new ServiceManagerContext())
            {
                var estateDto = context.Estates.FirstOrDefault(e => e.EstateId == estateGuid.ToString());
                return DtoToModel(estateDto);
            }
        }

        private EstateDbDto ModelToDto(Estate estate)
        {
            {
                var estateDbDto = new EstateDbDto
                {
                    EstateId = estate.EstateId.ToString(),
                    City = estate.City,
                    LastInspectionDate = estate.LastInspectionDate.ToString(),
                    Name = estate.Name,
                    PostCode = estate.PostCode,
                    Street = estate.Street,
                    UnderContract = estate.UnderContract
                };

                estateDbDto.InspectorId = estate.InspectorId == null ? null : estate.InspectorId.ToString();

                return estateDbDto;
            }
        }

        private Estate DtoToModel(EstateDbDto estateDbDto)
        {
            if (estateDbDto.InspectorId != null)
            {
                return new Estate(estateDbDto.Name, estateDbDto.City, estateDbDto.Street, estateDbDto.PostCode,
                    estateDbDto.UnderContract, DateTime.Parse(estateDbDto.LastInspectionDate),
                    Guid.Parse(estateDbDto.EstateId),
                    Guid.Parse(estateDbDto.InspectorId));
            }

            return new Estate(estateDbDto.Name, estateDbDto.City, estateDbDto.Street, estateDbDto.PostCode,
                estateDbDto.UnderContract, DateTime.Parse(estateDbDto.LastInspectionDate),
                Guid.Parse(estateDbDto.EstateId),
                null);
        }
    }
}