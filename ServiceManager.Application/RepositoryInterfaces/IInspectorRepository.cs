using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IInspectorRepository
    {
        void AddInspector(Inspector inspector);
        List<Inspector> GetInspectorList();
        void ModifyInspector(Inspector oldInspector, Inspector newInspector);
        void RemoveInspector(Inspector inspector);
    }
}