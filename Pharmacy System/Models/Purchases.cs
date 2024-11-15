using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_System.Models
{
    public class Purchases
    {
        [Key]
        [Required]
        public int PurchaseID { get; set; }

        //[ForeignKey("Medicines")]
        public int MedicineID { get; set; }

        //[ForeignKey("Suppliers")]
        public int SupplierID { get; set; }
        public int Quantity { get; set; }
        public string PurchaseDate { get; set; }
        public decimal CostPerUnit {  get; set; }
        public decimal TotalCost { get; set; }
    }
}
