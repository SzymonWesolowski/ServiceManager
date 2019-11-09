using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IRenovationProtocolGenerator
    {
        void Generate(RenovationProtocol protocol);
    }
}