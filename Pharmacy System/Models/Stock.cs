using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_System.Models
{
    public class Stock
    {
        [Key]
        [Required]
        public int StockID { get; set; }

        //[ForeignKey("Medicines")]
        public int MedicineID { get; set; }
        public string BatchNumber { get; set; }
        public int Quantity { get; set; }
        public string ManufacturingDate { get; set; }
        public string ExpirationDate { get; set; }
    }
}

