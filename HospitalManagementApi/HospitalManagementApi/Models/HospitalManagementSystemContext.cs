using HospitalManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models
{
    public class HospitalManagementSystemContext : DbContext
    {
        public HospitalManagementSystemContext(DbContextOptions<HospitalManagementSystemContext> options)
              : base(options)
        {
        }

        public virtual DbSet<DoctorsInfo> DoctorsInfos { get; set; }
<<<<<<< HEAD:HospitalManagementApi/HospitalManagementApi/Models/HospitalManagementSystemContext.cs
=======

<<<<<<< HEAD
        public virtual DbSet<WordInfo> WordInfos { get; set; }

        public virtual DbSet<CabinInfo> CabinInfos { get; set; }
        public virtual DbSet<BedInfo> BedInfos { get; set; }
        
=======
>>>>>>> 3c358c77282145af55f8c7708c57cb95615b8d69:HospitalManagementApi/HospitalManagementApi/ViewModels/HospitalManagementSystemContext.cs
        public virtual DbSet<WardInfo> WardInfos { get; set; }
        public virtual DbSet<BedInfo> BedInfos { get; set; }
        public virtual DbSet<CabinInfo> CabinInfos { get; set; }
        public virtual DbSet<TestInfo> TestInfos { get; set; }
        public virtual DbSet<AppointmentInfo> AppoinmentInfos { get; set; }
        public virtual DbSet<OutDoorConsultancy> OutDoorConsultancies { get; set; }
        public virtual DbSet<PatientInfo> PatientInfos { get; set; }
        public virtual DbSet<PatientAdmissionInfo> PatientAdmissionInfos { get; set; }
        public virtual DbSet<PatientMedicineInfo> PatientMedicineInfos { get; set; }
        public virtual DbSet<PatientTestingInfo> PatientTestingInfos { get; set; }
        public virtual DbSet<PatientOthersInfo> PatientOthersInfos { get; set; }
        public virtual DbSet<InvoiceInfo> InvoiceInfos { get; set; }
        public virtual DbSet<LabandTestEntryInfo> LabandTestEntryInfos { get; set; }
        public virtual DbSet<TestReportInfo> TestReportInfos { get; set; }


>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInfo>().HasMany(e => e.PatientOthersInfos).WithOne(e => e.PatientInfo).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Apartment>().HasMany(e => e.ViewUnitStatuses).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
