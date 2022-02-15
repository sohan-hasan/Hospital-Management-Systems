using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models.ViewModels
{
    public class DoctorsInfoViewModel
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
        [MaxLength(15)]
        public string DutyStartTime { get; set; }
        [MaxLength(15)]
        public string DutyEndTime { get; set; }
        [MaxLength(15)]
        public string JoinDate { get; set; }
        [MaxLength(15)]
        public string ResignDate { get; set; }
        [Required]
        public string DoctorType { get; set; }
        [Required]
        public int CommissionStatus { get; set; }
        public string ImageName { get; set; }

        public IFormFile Photo { get; set; }
    }
    public class TestInfoViewModel
    {
        [Key]
        public int TestId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required, MaxLength(30)]
        public string TestName { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TestCost { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PercentangeToDoctor { get; set; }
        [Required, MaxLength(100)]
        public string Unit { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CashToDoctor { get; set; }
    }
    public class TestCategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
    }
    public class PatientAdmissionInfoViewModel
    {
        [Key]
        public int PatientAdmissionId { get; set; }
        [Required, MaxLength(15)]
        public string AdmissionDate { get; set; }
        [Required]
        public int PatientId { get; set; }
        public int CabinTypeId { get; set; }
        [MaxLength(15)]
        public string CabinTypeName { get; set; }
        public int CabinId { get; set; }
        public int UpdateCabinId { get; set; }
        [MaxLength(20)]
        public string CabinName { get; set; }
        public int WardNo { get; set; }
        [MaxLength(20)]
        public string WardName { get; set; }
        public int UpdateBedId { get; set; }
        public int BedId { get; set; }
        [MaxLength(10)]
        public string BedNo { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal AdvanceAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CostPerDay { get; set; }
        [MaxLength(200)]
        public string Remarks { get; set; }
        [Required]
        public int BookingStatus { get; set; }

        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required, MaxLength(50)]
        public string FatherName { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Occupation { get; set; }
        [MaxLength(30)]
        public string Nationality { get; set; }
        [MaxLength(30)]
        public string NidCardNo { get; set; }
        [MaxLength(5)]
        public string BloodGroup { get; set; }
        [Required]
        public int Age { get; set; }
        public string ImageName { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class PatientInfoViewModel
    {
        [Key]
        public int PatientId { get; set; }
        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required, MaxLength(50)]
        public string FatherName { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Occupation { get; set; }
        [MaxLength(30)]
        public string Nationality { get; set; }
        [MaxLength(30)]
        public string NidCardNo { get; set; }
        [MaxLength(5)]
        public string BloodGroup { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int IsAdmit { get; set; }
        public string ImageName { get; set; }
        public IFormFile Photo { get; set; }

    }
    public class OutdoorPatientTestViewModel
    {
        [Key]
        public int TestNo { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required, MaxLength(15)]
        public string TestDate { get; set; }
        [MaxLength(50)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInfo PatientInfo { get; set; }
        [ForeignKey("TestId")]
        public virtual TestInfo TestInfo { get; set; }
    }
    public class AppointmentInfoViewModel
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required,MaxLength(15)]
        public string AppointmentDate { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required, MaxLength(15)]
        public string AppointmentTime { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [MaxLength(15)]
        public string NextAppointmentDate { get; set; }
        [MaxLength(200)]
        public string Remark { get; set; }
    }
    public class OutDoorConsultancyViewModel
    {
        [Key]
        public int OutDoorId { get; set; }
        [Required]
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }
        [Required]
        public int SerialNo { get; set; }
        public string EntryDate { get; set; }
        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [MaxLength(500)]
        public string Prescription { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [ MaxLength(500)]
        public string Testifications { get; set; }
    }
    public class CabinInfoViewModel
    {
        [Key]
        public int CabinId { get; set; }
        [Required, MaxLength(20)]
        public string CabinName { get; set; }
        [Required]
        public int CabinTypeId { get; set; }
        public string CabinTypeName { get; set; }
        [Required, MaxLength(50)]
        public string CabinSize { get; set; }
        [Required, MaxLength(50)]
        public string FloorNo { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CostPerDay { get; set; }
        [Required]
        public int BookingStatus { get; set; }
        [MaxLength(30)]
        public string CabinDirection { get; set; }

        public string ImageName { get; set; }

        public IFormFile Photo { get; set; }

    }
    public class CabinTypeInfoViewModel
    {
        [Key]
        public int CabinTypeId { get; set; }
        [Required, MaxLength(15)]
        public string CabinTypeName { get; set; }
    }
    public class WardInfoViewModel
    {
        [Key]
        public int WardNo { get; set; }
        [Required, MaxLength(30)]
        public string WardName { get; set; }

        public decimal WardCost { get; set; }

        [Required, MaxLength(30)]
        public string FloorNo { get; set; }
        public string ImageName { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class BedInfoViewModel
    {
        [Key]
        public int BedId { get; set; }

        [Required, MaxLength(30)]
        public string BedNo { get; set; }

        [Required]
        public int WardNo { get; set; }

        public int BookingStatus { get; set; }

        public string WardName { get; set; }
    }

    public class DepartmentViewModel
    {


        [Key]
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string DepartmentName { get; set; }

    }
    public class DesignationViewModel
    {
        [Key]
        public int DesignationId { get; set; }
        [Required, MaxLength(50)]
        public string DesignationName { get; set; }

    }
    public class EducationViewModel
    {
        [Key]
        public int EducationID { get; set; }

        [MaxLength(15)]
        public string Degree { get; set; }

        [MaxLength(100)]
        public string Institution { get; set; }

        [MaxLength(6)]
        public string PasingYear { get; set; }

        [MaxLength(15)]
        public string Result { get; set; }
        [Required]
        public int EmployeeId { get; set; }

    }
    public class ExperienceViewModel
    {
        [Key]
        public int ExperienceID { get; set; }

        public string YearsOfExperience { get; set; }

        [MaxLength(25)]
        public string CompanyName { get; set; }

        [MaxLength(25)]
        public string StartDate { get; set; }

        [MaxLength(25)]
        public string FinishDate { get; set; }

        [MaxLength(500)]
        public string Responsibilities { get; set; }

        [MaxLength(50)]
        public string Designation { get; set; }
        [Required]
        public int EmployeeId { get; set; }

    }
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, MaxLength(50)]
        public string EmployeeName { get; set; }

        [Required, MaxLength(50)]
        public string FatherName { get; set; }

        [Required, MaxLength(50)]
        public string MotherName { get; set; }

        [Required, MaxLength(30)]
        public string Sex { get; set; }

        [Required, MaxLength(20)]
        public string DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }

        public string Maritaltatus { get; set; }

        [MaxLength(50)]
        public string SpouseName { get; set; }

        [MaxLength(50)]
        public string PesentAddress { get; set; }

        [MaxLength(50)]
        public string PermanentAddress { get; set; }

        [MaxLength(20)]
        public string BloodGroup { get; set; }

        [MaxLength(50)]
        public string Religion { get; set; }

        [MaxLength(20)]
        public string JoinDate { get; set; }

        [MaxLength(50)]
        public string ShiftTime { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal BasicSalary { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal HouseRent { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Medical { get; set; }

        [MaxLength(50)]
        public string AccountNo { get; set; }

        [MaxLength(20)]
        public string TerminationDate { get; set; }

        public int Active { get; set; }

        public string ImageName { get; set; }
        public IFormFile Photo { get; set; }
        [MaxLength(30)]
        public string NID { get; set; }

        [MaxLength(30)]
        public string Passport { get; set; }

        [MaxLength(30)]
        public string BirthID { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        [Required]
        public int DesignationId { get; set; }
        public string Designation { get; set; }

        public ICollection<EducationViewModel> EducationViewModels { get; set; }
        public ICollection<ExperienceViewModel> ExperienceViewModels { get; set; }
    }
    public class PatientTestingInfoViewModel
    {
        [Key]
        public int TestNo { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public string TestDate { get; set; }
        [Required]
        public int PatientAdmissionId { get; set; }
        public string PatientName { get; set; }
        [Required, MaxLength(50)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        //public int CategoryId { get; set; }
        //public int IndexNumber { get; set; }
        public string TestName { get; set; }
    }
    public class PatientMedicineInfoViewModel
    {
        [Key]
        public int PatientMedicineInfoId { get; set; }
        public string PatientName { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public int PatientAdmissionId { get; set; }
        [Required]
        public string MedicineDate { get; set; }
        [Required, MaxLength(200)]
        public string InstructionsForMedicine { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal Total { get; set; }
    }

    public class SupplierViewModel
    {
        [Key]
        public int SupplierId { get; set; }
        [Required, MaxLength(80)]
        public string CompanyName { get; set; }
        [Required, MaxLength(80)]
        public string ContactName { get; set; }
        [Required, MaxLength(80)]
        public string Address { get; set; }
        [Required, MaxLength(80)]
        public string Phone { get; set; }
        [Required, MaxLength(80)]
        public string Email { get; set; }
        public string ImageName { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required, MaxLength(80)]
        public string ProductName { get; set; }
        [Required, MaxLength(15)]
        public string PurchaseDate { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal SalesUnitPrice { get; set; }
        public string ImageName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(80)]
        public string CategoryName { get; set; }
    }
    public class Product_In_The_OrderViewModel
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }

    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int PatientAdmissionId { get; set; }
        public string PatientName { get; set; }
        [Required, MaxLength(15)]
        public string Date_Of_Order { get; set; }
        [MaxLength(200)]
        public string OrderDeatils { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal SalesUnitPrice { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
    }
}
