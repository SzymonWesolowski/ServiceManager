using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class InspectorRepository :IInspectorRepository
    {
        public void AddInspector(Inspector inspector)
        {
            using (var context = new ServiceManagerContext())
            {
                context.Inspectors.Add(ModelToDto(inspector));
                context.SaveChanges();
            }
        }

        public List<Inspector> GetInspectorList()
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectorDtoList = context.Inspectors.ToList();
                var inspectorList = new List<Inspector>();
                foreach (var inspectorDbDto in inspectorDtoList)
                {
                    inspectorList.Add(DtoToModel(inspectorDbDto));
                }

                return inspectorList;
            }
        }

        public void ModifyInspector(Inspector inspector)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectorDto = context.Inspectors.SingleOrDefault(i => i.InspectorId == inspector.InspectorId.ToString());
                context.Entry(inspectorDto).CurrentValues.SetValues(ModelToDto(inspector));
                context.SaveChanges();
            }
        }

        public void RemoveInspector(Guid inspectorId)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectorDto = context.Inspectors.SingleOrDefault(i => i.InspectorId == inspectorId.ToString());
                context.Attach(inspectorDto);
                context.Remove(inspectorDto);
                context.SaveChanges();
            }
        }

        public Inspector GetInspector(Guid inspectorId)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectorDto = context.Inspectors.First(i => i.InspectorId == inspectorId.ToString());
                return DtoToModel(inspectorDto);
            }
        }

        private InspectorDbDto ModelToDto(Inspector inspector)
        {
            var inspectorDto = new InspectorDbDto
            {
                InspectorId = inspector.InspectorId.ToString(),
                City = inspector.City,
                FirstName = inspector.FirstName,
                LastName = inspector.LastName,
                PhoneNumber = inspector.PhoneNumber
            };
            return inspectorDto;
        }

        private Inspector DtoToModel(InspectorDbDto inspectorDbDto)
        {
            var inspector = new Inspector(inspectorDbDto.FirstName, inspectorDbDto.LastName, inspectorDbDto.City,
                inspectorDbDto.PhoneNumber, Guid.Parse(inspectorDbDto.InspectorId));
            return inspector;
        }
    }

}
