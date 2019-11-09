using ServiceManager.Application;
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