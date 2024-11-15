using System.ComponentModel.DataAnnotations;

namespace Pharmacy_System.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }        
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
