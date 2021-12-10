using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class WordInfoViewModel
    {
        [Key]
        public int WordNo { get; set; }
        [Required]
        public string WordName { get; set; }
        
        public decimal WordCost { get; set; }
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
        public int WordNo { get; set; }
    }
}
