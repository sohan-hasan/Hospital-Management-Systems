﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models
{
    public class DoctorsInfo
    {
        [Key]
        public int DoctorId { get; set; }
        [Required, MaxLength(50)]
        public string DoctorName { get; set; }
        [Required, MaxLength(50)]
        public string Specialist { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Qualification { get; set; }
        public DateTime DutyStartTime { get; set; }
        public DateTime DutyEndTime { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ResignDate { get; set; }
        [Required, MaxLength(50)]
        public string DoctorType { get; set; }
        [Required]
        public int CommissionStatus { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<OutDoorConsultancy> OutDoorConsultancies { get; set; }
        public virtual ICollection<AppointmentInfo> AppointmentInfos { get; set; }
    }
    public class WardInfo
    {
        [Key]
        public int WardNo { get; set; }
        [Required]
        public string WardName { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal WardCost { get; set; }
        [Required, MaxLength(10)]
        public string BookingStatus { get; set; }
        [Required, MaxLength(30)]
        public string FloorNo { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<BedInfo> BedInfos { get; set; }

    }
    public class BedInfo
    {
        [Key]
        public int BedId { get; set; }

        [Required]
        public string BedNo { get; set; }

        [Required]
        public int WardNo { get; set; }
        [ForeignKey("WardNo")]
        public virtual WardInfo WardInfo { get; set; }
    }
    public class CabinInfo
    {
        [Key]
        public int CabinId { get; set; }
        [Required, MaxLength(20)]
        public string CabinName { get; set; }
        [Required, MaxLength(50)]
        public string CabinType { get; set; }
        [Required, MaxLength(50)]
        public string CabinSize { get; set; }
        [Required, MaxLength(50)]
        public string FloorNo { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CostPerDay { get; set; }
        [Required, MaxLength(10)]
        public string BookingStatus { get; set; }
        [MaxLength(30)]
        public string CabinDirection { get; set; }

        public string ImageName { get; set; }
    }
    public class TestInfo
    {
        [Key]
        public int TestId { get; set; }
        [Required, MaxLength(30)]
        public string TestName { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TestCost { get; set; }
        [Required, MaxLength(30)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PercentangeToDoctor { get; set; }
        [Required, MaxLength(100)]
        public string Unit { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CashToDoctor { get; set; }
        public ICollection<LabandTestEntryInfo> LabandTestEntryInfos { get; set; }
        public ICollection<TestReportInfo> TestReportInfos { get; set; }

    }
    //public class TestType
    //{
    //    [Key]
    //    public int TestTypeId { get; set; }
    //    [Required, MaxLength(50)]
    //    public int TestTypeName { get; set; }
    //    [Required, MaxLength(50)]
    //    public string TestGroup { get; set; }
    //    public string Remarks { get; set; }
    //    public int GrpSlNo { get; set; }
    //    public int TypeSlNo { get; set; }
    //}
    public class AppointmentInfo
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int SerialNo { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime NextAppointmentDate { get; set; }
        [Required, MaxLength(200)]
        public string Remark { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorsInfo DoctorsInfo { get; set; }
    }

    public class OutDoorConsultancy
    {
        [Key]
        public int OutDoorId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int SerialNo { get; set; }
        public DateTime EntryDate { get; set; }
        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Prescription { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [Required, MaxLength(500)]
        public string Testifications { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorsInfo DoctorsInfo { get; set; }
    }
    public class PatientInfo
    {
        [Key]
        public int PatientId { get; set; }
        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required, MaxLength(50)]
        public string FatherName { get; set; }
        [Required, MaxLength(100), DefaultValue("")]
        public string Address { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [Required, MaxLength(30)]
        public string Occupation { get; set; }
        [Required, MaxLength(30)]
        public string Nationality { get; set; }
        [Required, MaxLength(30)]
        public string NIDCardNo { get; set; }
        [Required, MaxLength(5)]
        public string BloodGroup { get; set; }
        [Required]
        public int Age { get; set; }
        public ICollection<PatientAdmissionInfo> PatientAdmissionInfos { get; set; }
        public ICollection<PatientOthersInfo> PatientOthersInfos { get; set; }
        public ICollection<InvoiceInfo> InvoiceInfos { get; set; }

    }
    public class PatientAdmissionInfo
    {
        [Key]
        public int PatientAdmissionId { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public int PatientId { get; set; }
        //[Required]
        //public int CabinId { get; set; }
        //[Required]
        //public int WordNo { get; set; }
        //[Required]
        //public int BedNo { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal AdvanceAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CostPerDay { get; set; }
        [Required, MaxLength(200)]
        public string Remarks { get; set; }
        [Required, MaxLength(10)]
        public string BookingStatus { get; set; }
        [Required]
        public int TotalStayingDay { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal BedCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal OthersCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TotalCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal Discount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PayableAmount { get; set; }
        [Required]
        public DateTime RelaseDate { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal MedicineCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal ServiceCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TestingCharge { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal ServiceChargePercentage { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TotalPaidAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TotalDueAmount { get; set; }
        [ForeignKey("PatientId")]
        public virtual PatientInfo PatientInfo { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorsInfo DoctorsInfo { get; set; }
        public ICollection<PatientMedicineInfo> PatientMedicineInfos { get; set; }
        public ICollection<PatientTestingInfo> PatientTestingInfos { get; set; }
        public ICollection<PatientOthersInfo> PatientOthersInfos { get; set; }
    }
    public class PatientMedicineInfo
    {
        [Key]
        public int PatientMedicineInfoId { get; set; }
        [Required]
        public int MedicineNo { get; set; }
        [Required, MaxLength(60)]
        public string MedicineName { get; set; }
        [Required]
        public int PatientAddmissionId { get; set; }
        [Required]
        public DateTime MedicineDate { get; set; }
        [Required, MaxLength(200)]
        public string InstructionsForMedicine { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal Total { get; set; }
        [ForeignKey("PatientAddmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
    }
    public class PatientTestingInfo
    {
        [Key]
        public int TestNo { get; set; }
        [Required, MaxLength(50)]
        public string TestName { get; set; }
        [Required]
        public DateTime TestDate { get; set; }
        [Required]
        public int PatientAddmissionId { get; set; }
        [Required, MaxLength(50)]
        public string Remarks { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal Total { get; set; }

        public DateTime VoucherDate { get; set; }
        [ForeignKey("PatientAddmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
    }
    public class PatientOthersInfo
    {
        [Key]
        public int PatientOthersInfoId { get; set; }
        [Required]
        public int PatientAddmissionId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required, MaxLength(50)]
        public string ServiceName { get; set; }

        [Required, MaxLength(50)]
        public string Remarks { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        public DateTime VoucherDate { get; set; }
        [ForeignKey("PatientAddmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
        [ForeignKey("PatientId")]
        public virtual PatientInfo PatientInfo { get; set; }

    }
    public class InvoiceInfo
    {
        [Key]
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PaitentTotalAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal VatParcentage { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal Discount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal NetAmount { get; set; }
        [Required, MaxLength(50)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PaidAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DueAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DuePaid { get; set; }
        [Required]
        public DateTime DuePaidDate { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int ReferenceId { get; set; }
        [Required]
        public int ReportDeliveryChechBox { get; set; }
        [Required]
        public int CommissionApplication { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CommissionPercentage { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CommissionAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DiscountPercentage { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DiscountDue { get; set; }
        [ForeignKey("PatientId")]
        public virtual PatientInfo PatientInfo { get; set; }
        public ICollection<LabandTestEntryInfo> LabandTestEntryInfos { get; set; }
        public ICollection<TestReportInfo> TestReportInfos { get; set; }
    }
    public class LabandTestEntryInfo
    {
        [Key]
        public int LabandTestId { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int TestId { get; set; }

        public DateTime ReceiveDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        [Required]
        public int Sample { get; set; }//for checkBox
        [Required, MaxLength(200)]
        public string Remarks { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual InvoiceInfo InvoiceInfo { get; set; }
        [ForeignKey("TestId")]
        public virtual TestInfo TestInfo { get; set; }
    }
    public class TestReportInfo
    {
        [Key]
        public int TestReportInfoId { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required, MaxLength(50)]
        public int Result { get; set; }
        [Required, MaxLength(300)]
        public int Remarks { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual InvoiceInfo InvoiceInfo { get; set; }
        [ForeignKey("TestId")]
        public virtual TestInfo TestInfo { get; set; }
    }
}
