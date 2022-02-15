using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementApi.Models.ContextModels
{
    public class Supplier
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
        public ICollection<Product> Products { get; set; }
    }
    public class Product
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
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<Product_In_The_Order> Product_In_The_Orders { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(80)]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class Product_In_The_Order
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int PatientAdmissionId { get; set; }
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
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("PatientAdmissionId")]
        public virtual PatientAdmissionInfo PatientAdmissionInfo { get; set; }
        public ICollection<Product_In_The_Order> Product_In_The_Orders { get; set; }
    }
}
