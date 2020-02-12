using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class ServicemanRepository : IServicemanRepository
    {
        public void AddServiceman(Serviceman serviceman)
        {
            using (var context = new ServiceManagerContext())
            {
                context.Servicemen.Add(ModelToDto(serviceman));
                context.SaveChanges();
            }
        }

        public List<Serviceman> GetServicemanList()
        {
            using (var context = new ServiceManagerContext())
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

        public void ModifyServiceman(Serviceman serviceman)
        {
            using (var context = new ServiceManagerContext())
            {
                var servicemanDto = context.Servicemen.Single(s => s.ServicemanId == serviceman.ServicemanId.ToString());
                context.Entry(servicemanDto).CurrentValues.SetValues(ModelToDto(serviceman));
                context.SaveChanges();
            }
        }

        public void RemoveServiceman(Guid servicemanId)
        {
            using (var context = new ServiceManagerContext())
            {
                var servicemanDto = context.Servicemen.Single(s => s.ServicemanId == servicemanId.ToString());
                context.Attach(servicemanDto);
                context.Remove(servicemanDto);
                context.SaveChanges();
            }
        }

        public Serviceman GetServiceman(Guid servicemanId)
        {
            using (var context = new ServiceManagerContext())
            {
                var servicemanDto = context.Servicemen.Single(s => s.ServicemanId == servicemanId.ToString());
                return DtoToModel(servicemanDto);
            }
        }

        private Serviceman DtoToModel(ServicemanDbDto servicemanDbDto)
        {
            var serviceman = new Serviceman(servicemanDbDto.FirstName,
                servicemanDbDto.LastName,
                servicemanDbDto.PermissionNumber,
                Guid.Parse(servicemanDbDto.ServicemanId));
            return serviceman;
        }

        private ServicemanDbDto ModelToDto(Serviceman serviceman)
        {
            var servicemanDto = new ServicemanDbDto
            {
                FirstName = serviceman.FirstName,
                LastName = serviceman.LastName,
                ServicemanId = serviceman.ServicemanId.ToString(),
                PermissionNumber = serviceman.PermissionNumber
            };
            return servicemanDto;
        }
    }
}
