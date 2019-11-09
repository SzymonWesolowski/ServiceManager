using System;
using ServiceManager.Application;
using ServiceManager.Domain.Model;
using ServiceManager.PdfCreator;

namespace ServiceManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repair = new RepairProtocol("Szym", new DateTime(2019, 10, 10), City.Gdańsk, DeviceType.CL542,
                "Chmielna", "123", true, string.Empty, null);
            var inspection = new InspectionProtocol("Szym", new DateTime(2019, 10, 10), City.Gdańsk, DeviceType.CL542,
                "Chmielna", "123", true, string.Empty, null);
            var renovation = new RenovationProtocol("Szym", new DateTime(2019, 10, 10), City.Gdańsk, DeviceType.CL542,
                "Chmielna", "123", true, string.Empty, null);
            var inspectionGenerator = new InspectionProtocolGenerator();
            var repairGenerator = new RepairProtocolGenerator();
            var renovationGenerator = new RenovationProtocolGenerator();
            var generatorService = new ProtocolGeneratorService(inspectionGenerator, repairGenerator, renovationGenerator);

            generatorService.GenerateRepairProtocol(repair);
            generatorService.GenerateInspectionProtocol(inspection);
            generatorService.GenerateRenovationProtocol(renovation);


        }
    }
}
