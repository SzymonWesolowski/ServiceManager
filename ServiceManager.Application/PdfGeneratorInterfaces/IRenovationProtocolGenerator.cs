using ServiceManager.Domain.Model;

namespace ServiceManager.Application.PdfGeneratorInterfaces
{
    public interface IRenovationProtocolGenerator
    {
        void Generate(RenovationProtocol protocol);
    }
}