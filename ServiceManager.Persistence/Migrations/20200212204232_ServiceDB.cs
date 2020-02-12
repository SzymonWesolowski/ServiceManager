using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceManager.Persistence.Migrations
{
    public partial class ServiceDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<string>(nullable: false),
                    DeviceType = table.Column<string>(nullable: true),
                    ParkPlaces = table.Column<int>(nullable: false),
                    ParkPlacesNumbers = table.Column<string>(nullable: true),
                    DeviceSerialNumber = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<string>(nullable: true),
                    EstateId = table.Column<string>(nullable: true),
                    LastInspectionDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    EstateId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    InspectorId = table.Column<string>(nullable: true),
                    UnderContract = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.EstateId);
                });

            migrationBuilder.CreateTable(
                name: "InspectionProtocols",
                columns: table => new
                {
                    ProtocolId = table.Column<string>(nullable: false),
                    ServicemanId = table.Column<string>(nullable: true),
                    ProtocolDate = table.Column<string>(nullable: true),
                    EstateId = table.Column<string>(nullable: true),
                    DeviceSerialNumber = table.Column<string>(nullable: true),
                    IsPositive = table.Column<bool>(nullable: false),
                    Recommendations = table.Column<string>(nullable: true),
                    PartsToBeReplaced = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionProtocols", x => x.ProtocolId);
                });

            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    InspectorId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.InspectorId);
                });

            migrationBuilder.CreateTable(
                name: "RenovationProtocols",
                columns: table => new
                {
                    ProtocolId = table.Column<string>(nullable: false),
                    ServicemanId = table.Column<string>(nullable: true),
                    ProtocolDate = table.Column<string>(nullable: true),
                    EstateId = table.Column<string>(nullable: true),
                    DeviceSerialNumber = table.Column<string>(nullable: true),
                    IsPositive = table.Column<bool>(nullable: false),
                    Recommendations = table.Column<string>(nullable: true),
                    PartsToBeReplaced = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    PartsReplaced = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationProtocols", x => x.ProtocolId);
                });

            migrationBuilder.CreateTable(
                name: "RepairProtocols",
                columns: table => new
                {
                    ProtocolId = table.Column<string>(nullable: false),
                    ServicemanId = table.Column<string>(nullable: true),
                    ProtocolDate = table.Column<string>(nullable: true),
                    EstateId = table.Column<string>(nullable: true),
                    DeviceSerialNumber = table.Column<string>(nullable: true),
                    IsPositive = table.Column<bool>(nullable: false),
                    Recommendations = table.Column<string>(nullable: true),
                    PartsToBeReplaced = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    CauseOfFailure = table.Column<string>(nullable: true),
                    RepairDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairProtocols", x => x.ProtocolId);
                });

            migrationBuilder.CreateTable(
                name: "Servicemen",
                columns: table => new
                {
                    ServicemanId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PermissionNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicemen", x => x.ServicemanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "InspectionProtocols");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "RenovationProtocols");

            migrationBuilder.DropTable(
                name: "RepairProtocols");

            migrationBuilder.DropTable(
                name: "Servicemen");
        }
    }
}
