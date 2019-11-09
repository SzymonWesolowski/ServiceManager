using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public interface IRepairProtocolGenerator
    {
        void Generate(RepairProtocol protocol);
    }
}