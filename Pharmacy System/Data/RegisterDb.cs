using Microsoft.EntityFrameworkCore;
using Pharmacy_System.Models;

namespace Pharmacy_System.Data
{
    public class RegisterDb : DbContext
    {
        public RegisterDb(DbContextOptions<RegisterDb> options) : base(options)
        {
                
        }
        public DbSet<Pharmacy_System.Models.Medicines> Medicines { get; set; }
        public DbSet<Pharmacy_System.Models.Users> Users { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Purchases> Purchases { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Sales> Sales { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Stock> Stock { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Suppliers> Suppliers { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.UsersType> UsersType { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Brands> Brands { get; set; } = default!;
        public DbSet<Pharmacy_System.Models.Manufacturer> Manufacturer { get; set; } = default!;
    }
}
