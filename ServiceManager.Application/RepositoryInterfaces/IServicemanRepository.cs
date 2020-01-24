using System.Collections.Generic;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application.RepositoryInterfaces
{
    public interface IServicemanRepository
    {
        void AddServiceman(Serviceman serviceman);
        List<Serviceman> GetServicemanList();
        void ModifyServiceman(Serviceman oldServiceman, Serviceman newServiceman);
        void RemoveServiceman(Serviceman serviceman);
    }
}