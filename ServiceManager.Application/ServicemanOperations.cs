using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    internal interface IServicemanOperations
    {
        void AddServiceman(string firstName, string lastName, string permissionNumber, Guid servicemanId);
        List<Serviceman> GetServicemanList();
        void ModifyServiceman(Serviceman oldServiceman, Serviceman newServiceman);
        void DeleteServiceman(Serviceman serviceman);
    }

    class ServicemanOperations : IServicemanOperations
    {
        private readonly IServicemanRepository _servicemanRepository;

        public ServicemanOperations(IServicemanRepository servicemanRepository)
        {
            _servicemanRepository = servicemanRepository;
        }

        public void AddServiceman(string firstName, string lastName, string permissionNumber, Guid servicemanId)
        {
            var serviceman = new Serviceman(firstName, lastName, permissionNumber, servicemanId);
            _servicemanRepository.AddServiceman(serviceman);
        }

        public List<Serviceman> GetServicemanList()
        {
            return _servicemanRepository.GetServicemanList();
        }

        public void ModifyServiceman(Serviceman oldServiceman, Serviceman newServiceman)
        {
            _servicemanRepository.ModifyServiceman(oldServiceman, newServiceman);
        }

        public void DeleteServiceman(Serviceman serviceman)
        {
            _servicemanRepository.RemoveServiceman(serviceman);
        }
    }
}