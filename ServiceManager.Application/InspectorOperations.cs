using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    internal interface IInspectorOperations
    {
        void AddInspector(string firstName, string lastName, string city, string phoneNumber, Guid inspectorId);
        List<Inspector> GeInspectorList();
        void ModifyInspector(Inspector oldInspector, Inspector newInspector);
        void RemoveInspector(Inspector inspector);
    }

    class InspectorOperations : IInspectorOperations

    {
        private readonly IInspectorRepository _inspectorRepository;

        public InspectorOperations(IInspectorRepository inspectorRepository)
        {
            _inspectorRepository = inspectorRepository;
        }
        public void AddInspector(string firstName, string lastName, string city, string phoneNumber, Guid inspectorId)
        {
            var inspector = new Inspector(firstName, lastName, city, phoneNumber, inspectorId);
            _inspectorRepository.AddInspector(inspector);
        }

        public List<Inspector> GeInspectorList()
        {
            return _inspectorRepository.GetInspectorList();
        }

        public void ModifyInspector(Inspector oldInspector, Inspector newInspector)
        {
            _inspectorRepository.ModifyInspector(oldInspector, newInspector);
        }

        public void RemoveInspector(Inspector inspector)
        {
            _inspectorRepository.RemoveInspector(inspector);
        }
    }
}