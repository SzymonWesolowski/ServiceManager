using System;
using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IInspectorRepository
    {
        void AddInspector(Inspector inspector);
        List<Inspector> GetInspectorList();
        void ModifyInspector(Inspector inspector);
        void RemoveInspector(Guid inspectorId);
        Inspector GetInspector(Guid inspectorId);
    }
}