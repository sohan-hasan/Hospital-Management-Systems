﻿// <auto-generated />
using System;
using HospitalManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagementApi.Migrations
{
    [DbContext(typeof(HospitalManagementSystemContext))]
    partial class HospitalManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

<<<<<<< HEAD
=======
            modelBuilder.Entity("HospitalManagementApi.Models.AppointmentInfo", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NextAppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remark")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DoctorId");

                    b.ToTable("AppoinmentInfos");
                });

>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
            modelBuilder.Entity("HospitalManagementApi.Models.BedInfo", b =>
                {
                    b.Property<int>("BedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BedNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WardNo")
                        .HasColumnType("int");

                    b.HasKey("BedId");

                    b.HasIndex("WardNo");

                    b.ToTable("BedInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.CabinInfo", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

<<<<<<< HEAD
                    b.ToTable("BedInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.CabinInfo", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

=======
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CabinDirection")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CabinSize")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CabinType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("FloorNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CabinId");

                    b.ToTable("CabinInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.DoctorsInfo", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CommissionStatus")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoctorType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DutyEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DutyStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ResignDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Specialist")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DoctorId");

                    b.ToTable("DoctorsInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.InvoiceInfo", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CommissionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CommissionApplication")
                        .HasColumnType("int");

                    b.Property<decimal>("CommissionPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiscountDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<decimal>("DueAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DuePaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DuePaidDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaitentTotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReportDeliveryChechBox")
                        .HasColumnType("int");

                    b.Property<decimal>("VatParcentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("PatientId");

                    b.ToTable("InvoiceInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.LabandTestEntryInfo", b =>
                {
                    b.Property<int>("LabandTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Sample")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("LabandTestId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TestId");

                    b.ToTable("LabandTestEntryInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.OutDoorConsultancy", b =>
                {
                    b.Property<int>("OutDoorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<string>("Testifications")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("OutDoorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("OutDoorConsultancies");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientAdmissionInfo", b =>
                {
                    b.Property<int>("PatientAdmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("AdvanceAmount")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("BedCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(16,2)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<decimal>("MedicineCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("OthersCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<decimal>("PayableAmount")
                        .HasColumnType("decimal(16,2)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ServiceCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("ServiceChargePercentage")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("TestingCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("TotalCharge")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("TotalDueAmount")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("TotalPaidAmount")
                        .HasColumnType("decimal(16,2)");

                    b.Property<int>("TotalStayingDay")
                        .HasColumnType("int");

                    b.HasKey("PatientAdmissionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAdmissionInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientInfo", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NIDCardNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PatientId");

                    b.ToTable("PatientInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientMedicineInfo", b =>
                {
                    b.Property<int>("PatientMedicineInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstructionsForMedicine")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("MedicineDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("MedicineNo")
                        .HasColumnType("int");

                    b.Property<int>("PatientAddmissionId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(16,2)");

                    b.HasKey("PatientMedicineInfoId");

                    b.HasIndex("PatientAddmissionId");

                    b.ToTable("PatientMedicineInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientOthersInfo", b =>
                {
                    b.Property<int>("PatientOthersInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientAddmissionId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VoucherDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PatientOthersInfoId");

                    b.HasIndex("PatientAddmissionId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientOthersInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientTestingInfo", b =>
                {
                    b.Property<int>("TestNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientAddmissionId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(16,2)");

                    b.Property<DateTime>("VoucherDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TestNo");

                    b.HasIndex("PatientAddmissionId");

                    b.ToTable("PatientTestingInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.TestInfo", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CashToDoctor")
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("PercentangeToDoctor")
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("TestCost")
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TestId");

                    b.ToTable("TestInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.TestReportInfo", b =>
                {
                    b.Property<int>("TestReportInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Remarks")
                        .HasMaxLength(300)
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("TestReportInfoId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("TestId");

                    b.ToTable("TestReportInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.WardInfo", b =>
                {
                    b.Property<int>("WardNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FloorNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WardCost")
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("WardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WardNo");

                    b.ToTable("WardInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.AppointmentInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.DoctorsInfo", "DoctorsInfo")
                        .WithMany("AppointmentInfos")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorsInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.BedInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.WardInfo", "WardInfo")
                        .WithMany("BedInfos")
                        .HasForeignKey("WardNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WardInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.InvoiceInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.PatientInfo", "PatientInfo")
                        .WithMany("InvoiceInfos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.LabandTestEntryInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.InvoiceInfo", "InvoiceInfo")
                        .WithMany("LabandTestEntryInfos")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementApi.Models.TestInfo", "TestInfo")
                        .WithMany("LabandTestEntryInfos")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInfo");

                    b.Navigation("TestInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.OutDoorConsultancy", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.DoctorsInfo", "DoctorsInfo")
                        .WithMany("OutDoorConsultancies")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorsInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientAdmissionInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.DoctorsInfo", "DoctorsInfo")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementApi.Models.PatientInfo", "PatientInfo")
                        .WithMany("PatientAdmissionInfos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorsInfo");

                    b.Navigation("PatientInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientMedicineInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.PatientAdmissionInfo", "PatientAdmissionInfo")
                        .WithMany("PatientMedicineInfos")
                        .HasForeignKey("PatientAddmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientAdmissionInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientOthersInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.PatientAdmissionInfo", "PatientAdmissionInfo")
                        .WithMany("PatientOthersInfos")
                        .HasForeignKey("PatientAddmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementApi.Models.PatientInfo", "PatientInfo")
                        .WithMany("PatientOthersInfos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PatientAdmissionInfo");

                    b.Navigation("PatientInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientTestingInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.PatientAdmissionInfo", "PatientAdmissionInfo")
                        .WithMany("PatientTestingInfos")
                        .HasForeignKey("PatientAddmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientAdmissionInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.TestReportInfo", b =>
                {
                    b.HasOne("HospitalManagementApi.Models.InvoiceInfo", "InvoiceInfo")
                        .WithMany("TestReportInfos")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementApi.Models.TestInfo", "TestInfo")
                        .WithMany("TestReportInfos")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceInfo");

                    b.Navigation("TestInfo");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.DoctorsInfo", b =>
                {
                    b.Navigation("AppointmentInfos");

                    b.Navigation("OutDoorConsultancies");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.InvoiceInfo", b =>
                {
                    b.Navigation("LabandTestEntryInfos");

                    b.Navigation("TestReportInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientAdmissionInfo", b =>
                {
                    b.Navigation("PatientMedicineInfos");

                    b.Navigation("PatientOthersInfos");

                    b.Navigation("PatientTestingInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.PatientInfo", b =>
                {
                    b.Navigation("InvoiceInfos");

                    b.Navigation("PatientAdmissionInfos");

                    b.Navigation("PatientOthersInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.TestInfo", b =>
                {
                    b.Navigation("LabandTestEntryInfos");

                    b.Navigation("TestReportInfos");
                });

            modelBuilder.Entity("HospitalManagementApi.Models.WardInfo", b =>
                {
                    b.Navigation("BedInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
