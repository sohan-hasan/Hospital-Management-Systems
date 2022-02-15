using HospitalManagementApi.Models.ContextModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, string jsonData) : base(roleName)
        {
            base.Name = roleName;

            this.JsonData = jsonData;
        }

        [Display(Name = "JsonData")]
        public string JsonData { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public ApplicationUser(string userName) : base(userName) { }
        public ApplicationUser(string userId, string firstName, string lastName, string userName, string Email, string PhoneNumber, DateTime dateCreated, DateTime dateModified, string imageName) : base(userName)
        {
            this.Id = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            base.UserName = userName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.ImageName = imageName;
        }
        [Required, MaxLength(80)]
        public string FirstName { get; set; }

        [Required, MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }
        public string ImageName { get; set; }

    }
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
        [Required, MaxLength(80)]
        public string Qualification { get; set; }
        [MaxLength(15)]
        public string DutyStartTime { get; set; }
        [MaxLength(15)]
        public string DutyEndTime { get; set; }
        [MaxLength(15)]
        public string JoinDate { get; set; }
        [MaxLength(15)]
        public string ResignDate { get; set; }
       
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
        [Required,MaxLength(30)]
        public string WardName { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal WardCost { get; set; }
        [Required, MaxLength(30)]
        public string FloorNo { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<BedInfo> BedInfos { get; set; }

    }
    public class BedInfo
    {
        [Key]
        public int BedId { get; set; }

        [Required,MaxLength(30)]
        public string BedNo { get; set; }

        [Required]
        public int WardNo { get; set; }

        [Required]
        public int BookingStatus { get; set; }
        [ForeignKey("WardNo")]
        public virtual WardInfo WardInfo { get; set; }
    }
    public class CabinInfo
    {
        [Key]
        public int CabinId { get; set; }
        [Required, MaxLength(20)]
        public string CabinName { get; set; }
        [Required]
        public int CabinTypeId { get; set; }
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
        [ForeignKey("CabinTypeId")]
        public virtual CabinTypeInfo CabinTypeInfo { get; set; }
    }
    public class CabinTypeInfo
    {
        [Key]
        public int CabinTypeId { get; set; }
        [Required, MaxLength(15)]
        public string CabinTypeName { get; set; }
        public virtual ICollection<CabinInfo> CabinInfos { get; set; }
    }

    public class TestInfo
    {
        [Key]
        public int TestId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, MaxLength(30)]
        public string TestName { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal TestCost { get; set; }
        [MaxLength(30)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PercentangeToDoctor { get; set; }
        [Required, MaxLength(100)]
        public string Unit { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CashToDoctor { get; set; }
        [ForeignKey("CategoryId")]
        public virtual TestCategory TestCategory { get; set; }
        public ICollection<LabandTestEntryInfo> LabandTestEntryInfos { get; set; }
        public ICollection<TestReportInfo> TestReportInfos { get; set; }
        public ICollection<PatientTestingInfo> PatientTestingInfos { get; set; }

    }
    public class TestCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<TestInfo> TestInfos { get; set; }
    }
    public class AppointmentInfo
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required,MaxLength(15)]
        public string AppointmentDate { get; set; }
        [Required, MaxLength(50)]
        public string PatientName { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNo { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required, MaxLength(15)]
        public string AppointmentTime { get; set; }
        [MaxLength(15)]
        public string NextAppointmentDate { get; set; }
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
        [MaxLength(15)]
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
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(50)]
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
        public ICollection<PatientAdmissionInfo> PatientAdmissionInfos { get; set; }
        public ICollection<PatientOthersInfo> PatientOthersInfos { get; set; }
        public ICollection<InvoiceInfo> InvoiceInfos { get; set; }
        public ICollection<PatientTestingInfo> PatientTestingInfos { get; set; }

    }
    public class PatientAdmissionInfo
    {
        [Key]
        public int PatientAdmissionId { get; set; }
        [Required,MaxLength(15)]
        public string AdmissionDate { get; set; }
        [Required]
        public int PatientId { get; set; }
        public int CabinTypeId { get; set; }
        [MaxLength(15)]
        public string CabinTypeName { get; set; }
        public int CabinId { get; set; }
        [MaxLength(20)]
        public string CabinName { get; set; }
        public int WardNo { get; set; }
        [MaxLength(20)]
        public string WardName { get; set; }
        public int BedId { get; set; }
        [MaxLength(10)]
        public string BedNo { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal AdvanceAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal CostPerDay { get; set; }
        //public int TotalStayingDay { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal BedCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal OthersCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal TotalCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal Discount { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal PayableAmount { get; set; }
        //[Required]
        //public DateTime RelaseDate { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal MedicineCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal ServiceCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal TestingCharge { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal ServiceChargePercentage { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal TotalPaidAmount { get; set; }
        //[Required, Column(TypeName = "decimal(16, 2)")]
        //public decimal TotalDueAmount { get; set; }
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
        public int ProductId { get; set; }
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
        [ForeignKey("PatientAdmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }

    public class PatientTestingInfo
    {
        [Key]
        public int TestNo { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required, MaxLength(15)]
        public string TestDate { get; set; }
        [Required]
        public int PatientAdmissionId { get; set; }
        [MaxLength(50)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("PatientAdmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
        [ForeignKey("TestId")]
        public virtual TestInfo TestInfo { get; set; }
    }
    public class OutdoorPatientTest
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

        [MaxLength(200)]
        public string Remarks { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal UnitPrice { get; set; }
        [MaxLength(15)]
        public string VoucherDate { get; set; }
        [ForeignKey("PatientAddmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
        [ForeignKey("PatientId")]
        public virtual PatientInfo PatientInfo { get; set; }

    }
    public class InvoiceInfo
    {
        [Key]
        public int InvoiceId { get; set; }
        [MaxLength(15)]
        public string InvoiceDate { get; set; }
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
        [MaxLength(200)]
        public string Remarks { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PaidAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DueAmount { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DuePaid { get; set; }
        [MaxLength(15)]
        public string DuePaidDate { get; set; }
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
        [MaxLength(15)]
        public string ReceiveDate { get; set; }
        [MaxLength(15)]
        public string DeliveryDate { get; set; }
        [Required]
        public int Samples { get; set; }//for checkBox
        [MaxLength(200)]
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
        public string Result { get; set; }
        [MaxLength(300)]
        public string Remarks { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual InvoiceInfo InvoiceInfo { get; set; }
        [ForeignKey("TestId")]
        public virtual TestInfo TestInfo { get; set; }
    }
    public class Department
    {
        

        [Key]
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }


    public class Designation
    {
        

        [Key]
        public int DesignationId { get; set; }
        [Required, MaxLength(50)]
        public string DesignationName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }


    public class Education
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
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }


    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        public string YearsOfExperience { get; set; }

        [ MaxLength(25)]
        public string CompanyName { get; set; }

        [MaxLength(25)]
        public string StartDate { get; set; }

        [ MaxLength(25)]
        public string FinishDate { get; set; }

        [MaxLength(500)]
        public string Responsibilities { get; set; }

        [MaxLength(50)]
        public string Designation { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }


    public class Employee
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

        [ MaxLength(50)]
        public string Religion { get; set; }

        [ MaxLength(20)]
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

        [MaxLength(30)]
        public string NID { get; set; }

        [MaxLength(30)]
        public string Passport { get; set; }

        [MaxLength(30)]
        public string BirthID { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int DesignationId { get; set; }


        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }

    //public class HolidayCalender
    //{
    //    [Key]
    //    public int HolidayCalenderId { get; set; }

    //    [Column(Order = 0)]
    //    [StringLength(10)]
    //    public string HolidayMonth { get; set; }


    //    [Column(Order = 1)]
    //    [StringLength(4)]
    //    public string HolidayYear { get; set; }

    //    public string HolidayDate { get; set; }
        
    //    [Column(Order = 2)]
    //    [StringLength(50)]
    //    public string HDay { get; set; }

    //    [Column(Order = 3)]
    //    [StringLength(250)]
    //    public string Reason { get; set; }


    //    [Column(Order = 4)]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int FOpen { get; set; }


    //    [Column(Order = 5)]
    //    [StringLength(50)]
    //    public string PcName { get; set; }


    //    [Column(Order = 6)]
    //    [StringLength(50)]
    //    public string UserCode { get; set; }


    //    [Column(Order = 7)]
    //    [StringLength(10)]
    //    public string ComId { get; set; }


    //    [Column(Order = 8)]
    //    public DateTime EntryTime { get; set; }
    //}
}
