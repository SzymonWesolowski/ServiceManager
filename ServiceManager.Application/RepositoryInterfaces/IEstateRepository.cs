using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IEstateRepository
    {
        void AddEstate(Estate estate);
        List<Estate> GetEstateList();
        void ModifyEstate(Estate Estate);
        void RemoveEstate(Estate estate);
    }
}