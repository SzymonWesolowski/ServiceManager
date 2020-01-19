using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    interface IEstateRepository
    {
        void AddEstate(Estate estate);
        List<Estate> GetEstateList();
        void ModifyEstate(Estate oldEstate, Estate newEstate);
        void RemoveEstate(Estate estate);
    }
}