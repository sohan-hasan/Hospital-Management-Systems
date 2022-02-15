using HospitalManagementApi.Models.ContextModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models
{
    public class HospitalManagementContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options): base(options){ }

        public virtual DbSet<DoctorsInfo> DoctorsInfos { get; set; }
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
        public virtual DbSet<TestCategory> TestCategories { get; set; }
        public virtual DbSet<CabinTypeInfo> CabinTypeInfos { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product_In_The_Order> Product_In_The_Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInfo>().HasMany(e => e.PatientOthersInfos).WithOne(e => e.PatientInfo).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasMany(e => e.Orders).WithOne(e => e.Product).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
