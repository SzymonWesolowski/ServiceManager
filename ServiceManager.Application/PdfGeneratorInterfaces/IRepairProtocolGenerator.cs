using ServiceManager.Domain.Model;

namespace ServiceManager.Application.PdfGeneratorInterfaces
{
    public interface IRepairProtocolGenerator
    {
        void Generate(RepairProtocol protocol);
    }
}