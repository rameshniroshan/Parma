using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_System.Models
{
    public class Sales
    {
        [Key]
        [Required]
        public int SaleID { get; set; }

        //[ForeignKey("Medicines")]
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public string SaleDate { get; set; }
        public decimal SellingPricePerUnit { get; set; }
        public decimal TotalSaleAmount { get; set; }

    }
}
