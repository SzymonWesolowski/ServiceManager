using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IInspectorOperations
    {
        void AddInspector(Inspector inspector);
        List<Inspector> GetInspectorList();
        void ModifyInspector(Inspector inspector);
        void RemoveInspector(Guid inspectorId);
        Inspector GetInspector(Guid inspectorId);
    }

    public class InspectorOperations : IInspectorOperations

    {
        private readonly IInspectorRepository _inspectorRepository;

        public InspectorOperations(IInspectorRepository inspectorRepository, IDeviceRepository deviceRepository)
        {
            _inspectorRepository = inspectorRepository;
        }

        public void AddInspector(Inspector inspector)
        {
            _inspectorRepository.AddInspector(inspector);
        }

        public List<Inspector> GetInspectorList()
        {
            return _inspectorRepository.GetInspectorList();
        }

        public void ModifyInspector(Inspector inspector)
        {
            _inspectorRepository.ModifyInspector(inspector);
        }

        public void RemoveInspector(Guid inspectorId)
        {
            _inspectorRepository.RemoveInspector(inspectorId);
        }

        public Inspector GetInspector(Guid inspectorId)
        {
            return _inspectorRepository.GetInspector(inspectorId);
        }
    }
}