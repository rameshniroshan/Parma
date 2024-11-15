using System.ComponentModel.DataAnnotations;

namespace Pharmacy_System.Models
{
    public class UsersType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }

    }
}
