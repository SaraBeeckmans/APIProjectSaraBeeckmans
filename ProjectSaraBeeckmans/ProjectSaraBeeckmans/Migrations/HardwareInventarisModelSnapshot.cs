﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSaraBeeckmans.Data;

namespace ProjectSaraBeeckmans.Migrations
{
    [DbContext(typeof(HardwareInventaris))]
    partial class HardwareInventarisModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Bedrijf", b =>
                {
                    b.Property<int>("BedrijfId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("BedrijfNaam")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Tel");

                    b.HasKey("BedrijfId");

                    b.ToTable("Bedrijven");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Opmerking");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Tel");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Toestel", b =>
                {
                    b.Property<int>("ToestelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AankoopDatum");

                    b.Property<int?>("BedrijfId");

                    b.Property<string>("Garantie");

                    b.Property<double>("Prijs");

                    b.Property<string>("SerieNummer")
                        .IsRequired();

                    b.Property<int?>("SupplierId");

                    b.HasKey("ToestelId");

                    b.HasIndex("BedrijfId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Toesellen");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Toestel", b =>
                {
                    b.HasOne("ProjectSaraBeeckmans.Models.Bedrijf", "Bedrijf")
                        .WithMany("Toestellen")
                        .HasForeignKey("BedrijfId");

                    b.HasOne("ProjectSaraBeeckmans.Models.Supplier", "Supplier")
                        .WithMany("Toestellen")
                        .HasForeignKey("SupplierId");
                });
#pragma warning restore 612, 618
        }
    }
}
