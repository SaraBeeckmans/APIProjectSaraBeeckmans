using Microsoft.EntityFrameworkCore;
using ProjectSaraBeeckmans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSaraBeeckmans.Data
{
    public class HardwareInventaris: DbContext
    {
        public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Toestel> Toesellen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = hwinventaris; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            
        }
    }
}
