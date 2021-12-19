using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.ViewModels
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
        public DateTime DutyStartTime { get; set; }
        public DateTime DutyEndTime { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ResignDate { get; set; }
        [Required, MaxLength(50)]
        public string DoctorType { get; set; }
        [Required]
        public int CommissionStatus { get; set; }
        public string ImageName { get; set; }
    }

<<<<<<< HEAD
    public class WordInfoViewModel
=======
    public class WardInfoViewModel
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
    {
        [Key]
        public int WardNo { get; set; }
        [Required]
        public string WardName { get; set; }
        
        public decimal WardCost { get; set; }
        [Required, MaxLength(10)]
        public string BookingStatus { get; set; }

        [Required, MaxLength(30)]
        public string FloorNo { get; set; }
        public string ImageName { get; set; }
       
    }
    public class BedInfoViewModel
    {
        [Key]
        public int BedId { get; set; }
        [Required]
        public string BedNo { get; set; }
        [Required]
<<<<<<< HEAD
        public int WordNo { get; set; }
=======
        public int WardNo { get; set; }
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
    }
    public class CabinInfoViewModel
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

<<<<<<< HEAD
=======
    }
    public class TestInfoViewModel
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
    }
    public class AppointmentInfoViewModel
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
    }
    public class OutDoorConsultancyViewModel
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
    }
    public class LabandTestEntryInfoViewModel
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
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
    }
}
