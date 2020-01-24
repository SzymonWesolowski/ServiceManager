using ServiceManager.Application.PdfGeneratorInterfaces;
using ServiceManager.Domain.Model;

namespace ServiceManager.Application
{
    public class ProtocolGeneratorService
    {
        private readonly IInspectionProtocolGenerator _inspectionProtocolGenerator;
        private readonly IRepairProtocolGenerator _repairProtocolGenerator;
        private readonly IRenovationProtocolGenerator _renovationProtocolGenerator;

        public ProtocolGeneratorService(IInspectionProtocolGenerator inspectionProtocolGenerator, IRepairProtocolGenerator repairProtocolGenerator, IRenovationProtocolGenerator renovationProtocolGenerator)
        {
            _inspectionProtocolGenerator = inspectionProtocolGenerator;
            _repairProtocolGenerator = repairProtocolGenerator;
            _renovationProtocolGenerator = renovationProtocolGenerator;
        }

        public void GenerateInspectionProtocol(InspectionProtocol protocol)
        {
            _inspectionProtocolGenerator.Generate(protocol);
        }

        public void GenerateRepairProtocol(RepairProtocol protocol)
        {
            _repairProtocolGenerator.Generate(protocol);
        }

        public void GenerateRenovationProtocol(RenovationProtocol protocol)
        {
            _renovationProtocolGenerator.Generate(protocol);
        }
    }
}