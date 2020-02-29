using System;
using Microsoft.EntityFrameworkCore;
using ServiceManager.Domain.Model;

namespace ServiceManager.Persistence
{
    public class ServiceManagerContext : DbContext
    {
        public DbSet<EstateDbDto> Estates { get; set; }
        public DbSet<DeviceDbDto> Devices { get; set; }
        public DbSet<InspectorDbDto> Inspectors { get; set; }
        public DbSet<InspectionProtocolDbDto> InspectionProtocols { get; set; }
        public DbSet<RenovationProtocolDbDto> RenovationProtocols { get; set; }
        public DbSet<RepairProtocolDbDto> RepairProtocols { get; set; }
        public DbSet<ServicemanDbDto> Servicemen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ServiceManager; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
