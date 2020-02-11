﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceManager.Persistence;

namespace ServiceManager.Persistence.Migrations
{
    [DbContext(typeof(ServiceManagerContext))]
    partial class ServiceManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("ServiceManager.Domain.Model.DeviceDbDto", b =>
                {
                    b.Property<string>("DeviceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceSerialNumber");

                    b.Property<string>("DeviceType");

                    b.Property<string>("EstateId");

                    b.Property<int>("ParkPlaces");

                    b.Property<string>("ParkPlacesNumbers");

                    b.Property<string>("ProductionYear");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.EstateDbDto", b =>
                {
                    b.Property<string>("EstateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("InspectorId");

                    b.Property<string>("LastInspectionDate");

                    b.Property<string>("Name");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<bool>("UnderContract");

                    b.HasKey("EstateId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.InspectionProtocolDbDto", b =>
                {
                    b.Property<string>("ProtocolId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceId");

                    b.Property<string>("DeviceSerialNumber");

                    b.Property<string>("EstateId");

                    b.Property<bool>("IsPositive");

                    b.Property<string>("PartsToBeReplaced");

                    b.Property<string>("ProtocolDate");

                    b.Property<string>("Recommendations");

                    b.Property<string>("ServicemanId");

                    b.HasKey("ProtocolId");

                    b.ToTable("InspectionProtocols");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.InspectorDbDto", b =>
                {
                    b.Property<string>("InspectorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("InspectorId");

                    b.ToTable("Inspectors");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.RenovationProtocolDbDto", b =>
                {
                    b.Property<string>("ProtocolId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceId");

                    b.Property<string>("DeviceSerialNumber");

                    b.Property<string>("EstateId");

                    b.Property<bool>("IsPositive");

                    b.Property<string>("PartsReplaced");

                    b.Property<string>("PartsToBeReplaced");

                    b.Property<string>("ProtocolDate");

                    b.Property<string>("Recommendations");

                    b.Property<string>("ServicemanId");

                    b.HasKey("ProtocolId");

                    b.ToTable("RenovationProtocols");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.RepairProtocolDbDto", b =>
                {
                    b.Property<string>("ProtocolId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CauseOfFailure");

                    b.Property<string>("DeviceId");

                    b.Property<string>("DeviceSerialNumber");

                    b.Property<string>("EstateId");

                    b.Property<bool>("IsPositive");

                    b.Property<string>("PartsToBeReplaced");

                    b.Property<string>("ProtocolDate");

                    b.Property<string>("Recommendations");

                    b.Property<string>("RepairDescription");

                    b.Property<string>("ServicemanId");

                    b.HasKey("ProtocolId");

                    b.ToTable("RepairProtocols");
                });

            modelBuilder.Entity("ServiceManager.Domain.Model.ServicemanDbDto", b =>
                {
                    b.Property<string>("ServicemanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PermissionNumber");

                    b.HasKey("ServicemanId");

                    b.ToTable("Servicemen");
                });
#pragma warning restore 612, 618
        }
    }
}
