using System;
using System.Collections.Generic;
using System.Text;
using ServiceManager.Application.RepositoryInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IServicemanOperations
    {
        void AddServiceman(Serviceman serviceman);
        List<Serviceman> GetServicemanList();
        void ModifyServiceman(Serviceman serviceman);
        void DeleteServiceman(Guid servicemanId);
        Serviceman GetServiceman(Guid servicemanId);
    }

    public class ServicemanOperations : IServicemanOperations
    {
        private readonly IServicemanRepository _servicemanRepository;

        public ServicemanOperations(IServicemanRepository servicemanRepository)
        {
            _servicemanRepository = servicemanRepository;
        }

        public void AddServiceman(Serviceman serviceman)
        {
            _servicemanRepository.AddServiceman(serviceman);
        }

        public List<Serviceman> GetServicemanList()
        {
            return _servicemanRepository.GetServicemanList();
        }

        public void ModifyServiceman(Serviceman serviceman)
        {
            _servicemanRepository.ModifyServiceman(serviceman);
        }

        public void DeleteServiceman(Guid servicemanId)
        {
            _servicemanRepository.RemoveServiceman(servicemanId);
        }

        public Serviceman GetServiceman(Guid servicemanId)
        {
            return _servicemanRepository.GetServiceman(servicemanId);
        }
    }
}