using System.ComponentModel.DataAnnotations;

namespace Pharmacy_System.Models
{
    public class Suppliers
    {
        [Key]
        [Required]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
