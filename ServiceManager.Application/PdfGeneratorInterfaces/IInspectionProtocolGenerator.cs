using ServiceManager.Domain.Model;

namespace ServiceManager.Application.PdfGeneratorInterfaces
{
    public interface IInspectionProtocolGenerator
    {
        void Generate(InspectionProtocol protocol);
    }
}