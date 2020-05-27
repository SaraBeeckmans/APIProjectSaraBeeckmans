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
        public DbSet<ToestelCategorie> ToestelCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relatie toestel supplier
            modelBuilder.Entity<Supplier>()
                .HasMany(c => c.Toestellen)
                 .WithOne(e => e.Supplier);
            modelBuilder.Entity<Toestel>()
                .HasOne(e => e.Supplier)
                .WithMany(c => c.Toestellen);

            modelBuilder.Entity<Bedrijf>()
                .HasMany(c => c.Toestellen)
                 .WithOne(e => e.Bedrijf);
            modelBuilder.Entity<Toestel>()
                .HasOne(e => e.Bedrijf)
                .WithMany(c => c.Toestellen);

            //Manytomany
            modelBuilder.Entity<ToestelCategorie>()
                .HasKey(bc => new { bc.ToestelId, bc.CategorieId });
            modelBuilder.Entity<ToestelCategorie>()
                .HasOne(bc => bc.toestel)
                .WithMany(b => b.ToestelCategories)
                .HasForeignKey(bc => bc.ToestelId);
            modelBuilder.Entity<ToestelCategorie>()
                .HasOne(bc => bc.categorie)
                .WithMany(c => c.ToestelCategories)
                .HasForeignKey(bc => bc.CategorieId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = hwinventaris; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
           // optionsBuilder.UseMySql("server=localhost;database=hwinventaris;user=webapi;password=webapi;");
        }
    }
}

//public class DesignLocationFactory : IDesignTimeDbContextFactory<LocationDbContext>
//{
//    public LocationDbContext CreateDbContext(string[] args)
//    {
//        var builder = new DbContextOptionsBuilder<LocationDbContext>();
//        builder.UseMySQL("server=localhost;port=3306;user=***;passsword=***;database=locationdb");
//        return new LocationDbContext(builder.Options);
//    }
//}
