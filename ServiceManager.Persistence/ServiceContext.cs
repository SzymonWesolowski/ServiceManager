using System;
using Microsoft.EntityFrameworkCore;

namespace ServiceManager.Persistence
{
    public class ServiceContext : DbContext
    {
        //public DbSet<UserDtoDb> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
