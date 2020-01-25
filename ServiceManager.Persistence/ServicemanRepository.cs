using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class ServicemanRepository : IServicemanRepository
    {
        public void AddServiceman(Serviceman serviceman)
        {
            using (var context = new ServiceContext())
            {
                context.Servicemen.Add(ModelToDto(serviceman));
                context.SaveChanges();
            }
        }

        public List<Serviceman> GetServicemanList()
        {
            using (var context = new ServiceContext())
            {
                var servicemanDtoList = context.Servicemen.ToList();
                var servicemanList = new List<Serviceman>();
                foreach (var servicemanDbDto in servicemanDtoList)
                {
                    servicemanList.Add(DtoToModel(servicemanDbDto));
                }

                return servicemanList;
            }
        }

        public void ModifyServiceman(Serviceman oldServiceman, Serviceman newServiceman)
        {
            using (var context = new ServiceContext())
            {
                var serviceman = context.Servicemen.SingleOrDefault(s => s.ServicemanId == oldServiceman.ServicemanId);
                context.Entry(serviceman).CurrentValues.SetValues(ModelToDto(newServiceman));
                context.SaveChanges();
            }
        }

        public void RemoveServiceman(Serviceman serviceman)
        {
            using (var context = new ServiceContext())
            {
                var servicemanDto = context.Servicemen.SingleOrDefault(s => s.ServicemanId == serviceman.ServicemanId);
                context.Attach(servicemanDto);
                context.Remove(servicemanDto);
                context.SaveChanges();
            }
        }

        private Serviceman DtoToModel(ServicemanDbDto servicemanDbDto)
        {
            var serviceman = new Serviceman(servicemanDbDto.FirstName,
                servicemanDbDto.LastName,
                servicemanDbDto.PermissionNumber,
                servicemanDbDto.ServicemanId);
            return serviceman;
        }

        private ServicemanDbDto ModelToDto(Serviceman serviceman)
        {
            var servicemanDto = new ServicemanDbDto
            {
                FirstName = serviceman.FirstName,
                LastName = serviceman.LastName,
                ServicemanId = serviceman.ServicemanId,
                PermissionNumber = serviceman.PermissionNumber
            };
            return servicemanDto;
        }
    }
}
