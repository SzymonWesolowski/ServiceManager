using ServiceManager.Application;
using ServiceManager.Application.PdfGeneratorInterfaces;
using StructureMap;

namespace ServiceManager.PdfCreator
{
    public class PdfCreatorRegistry :Registry
    {
        public PdfCreatorRegistry()
        {
            For<IInspectionProtocolGenerator>().Use<InspectionProtocolGenerator>();

        }
    }
}