using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IEstateOperations
    {
        List<Estate> GetEstateList();
        void AddEstate(Estate estate);

        void ModifyEstate(Estate estate);
        void DeleteEstate(Estate estate);

    }

    public class EstateOperations : IEstateOperations
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

        public void AddEstate(Estate estate)
        {
            _estateRepository.AddEstate(estate);
        }

        public void ModifyEstate(Estate Estate)
        {
            _estateRepository.ModifyEstate(Estate);
        }

        public void DeleteEstate(Estate estate)
        {
            _estateRepository.RemoveEstate(estate);
        }
    }
}