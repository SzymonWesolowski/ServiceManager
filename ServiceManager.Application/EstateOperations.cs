using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    internal interface IEstateOperations
    {
        List<Estate> GetEstateList();
        void AddEstate(string name, string city, string street, string postCode, Inspector inspector,
            bool underContract, DateTime lastInspectionDate);

        void ModifyEstate(Estate oldEstate, Estate newEstate);
        void DeleteEstate(Estate estate);

    }

    class EstateOperations : IEstateOperations
    {
        private readonly IEstateRepository _estateRepository;

        public EstateOperations(IEstateRepository estateRepository)
        {
            _estateRepository = estateRepository;
        }

        public List<Estate> GetEstateList()
        {
            return _estateRepository.GetEstateList();
        }

        public void AddEstate(string name, string city, string street, string postCode, Inspector inspector,
            bool underContract, DateTime lastInspectionDate)
        {
            Estate estate = new Estate(name, city, street, postCode, inspector, underContract, lastInspectionDate);
            _estateRepository.AddEstate(estate);
        }

        public void ModifyEstate(Estate oldEstate, Estate newEstate)
        {
            _estateRepository.ModifyEstate(oldEstate,newEstate);
        }

        public void DeleteEstate(Estate estate)
        {
            _estateRepository.RemoveEstate(estate);
        }
    }
}