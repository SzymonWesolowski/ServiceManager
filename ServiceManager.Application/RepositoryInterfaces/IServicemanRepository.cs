using System;
using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IServicemanRepository
    {
        void AddServiceman(Serviceman serviceman);
        List<Serviceman> GetServicemanList();
        void ModifyServiceman(Serviceman serviceman);
        void RemoveServiceman(Guid servicemanId);
        Serviceman GetServiceman(Guid servicemanId);
    }
}