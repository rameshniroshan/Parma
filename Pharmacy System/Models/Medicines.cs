using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Pharmacy_System.Models
{
    public class Medicines
    {
        [Key]
        [Required]
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string DosageForm { get; set; }
        public string Strength { get; set; }
        public string Manufacturer { get; set; }
        public string ExpirationDate { get; set; }
        public int ReorderLevel { get; set; }
        public decimal PricePerUnit { get; set; }
        public bool Active { get; set; }
    }
}

