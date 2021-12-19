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

<<<<<<< HEAD
        public virtual DbSet<WordInfo> WordInfos { get; set; }

        public virtual DbSet<CabinInfo> CabinInfos { get; set; }
        public virtual DbSet<BedInfo> BedInfos { get; set; }
        
=======
        public virtual DbSet<WardInfo> WardInfos { get; set; }

        public virtual DbSet<CabinInfo> CabinInfos { get; set; }

        public virtual DbSet<BedInfo> BedInfos { get; set; }
        public virtual DbSet<TestInfo> TestInfos { get; set; }
        public virtual DbSet<AppointmentInfo> AppoinmentInfos { get; set; }
        public virtual DbSet<OutDoorConsultancy> OutDoorConsultancies { get; set; }
        public virtual DbSet<LabandTestEntryInfo> LabandTestEntryInfos { get; set; }

>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Apartment>().HasMany(e => e.ApartmentBookings).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Apartment>().HasMany(e => e.ViewUnitStatuses).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
