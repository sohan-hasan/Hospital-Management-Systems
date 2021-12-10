using HospitalManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.ViewModels
{
    public class HospitalManagementSystemContext : DbContext
    {
        public HospitalManagementSystemContext(DbContextOptions<HospitalManagementSystemContext> options)
              : base(options)
        {
        }

        public virtual DbSet<DoctorsInfo> DoctorsInfos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Apartment>().HasMany(e => e.ApartmentBookings).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Apartment>().HasMany(e => e.ViewUnitStatuses).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
