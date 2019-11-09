using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IInspectionProtocolGenerator
    {
        void Generate(InspectionProtocol protocol);
    }
}