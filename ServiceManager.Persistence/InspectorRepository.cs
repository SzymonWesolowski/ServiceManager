using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    class InspectorRepository :IInspectorRepository
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

        public void ModifyInspector(Inspector oldInspector, Inspector newInspector)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspector = context.Inspectors.SingleOrDefault(i => i.InspectorId == oldInspector.InspectorId);
                context.Entry(inspector).CurrentValues.SetValues(ModelToDto(newInspector));
                context.SaveChanges();
            }
        }

        public void RemoveInspector(Inspector inspector)
        {
            using (var context = new ServiceManagerContext())
            {
                var inspectorDto = context.Inspectors.SingleOrDefault(i => i.InspectorId == inspector.InspectorId);
                context.Attach(inspectorDto);
                context.Remove(inspectorDto);
                context.SaveChanges();
            }
        }

        private InspectorDbDto ModelToDto(Inspector inspector)
        {
            var inspectorDto = new InspectorDbDto
            {
                InspectorId = inspector.InspectorId,
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
                inspectorDbDto.PhoneNumber, inspectorDbDto.InspectorId);
            return inspector;
        }
    }

}
