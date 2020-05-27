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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("BedrijfNaam")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Tel");

                    b.HasKey("id");

                    b.ToTable("Bedrijven");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Categorie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Opmerking");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Tel");

                    b.HasKey("id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Toestel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AankoopDatum");

                    b.Property<int?>("Bedrijfid");

                    b.Property<string>("Garantie");

                    b.Property<double>("Prijs");

                    b.Property<string>("SerieNummer")
                        .IsRequired();

                    b.Property<int?>("Supplierid");

                    b.HasKey("id");

                    b.HasIndex("Bedrijfid");

                    b.HasIndex("Supplierid");

                    b.ToTable("Toesellen");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.ToestelCategorie", b =>
                {
                    b.Property<int>("ToestelId");

                    b.Property<int>("CategorieId");

                    b.HasKey("ToestelId", "CategorieId");

                    b.HasIndex("CategorieId");

                    b.ToTable("ToestelCategories");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.Toestel", b =>
                {
                    b.HasOne("ProjectSaraBeeckmans.Models.Bedrijf", "Bedrijf")
                        .WithMany("Toestellen")
                        .HasForeignKey("Bedrijfid");

                    b.HasOne("ProjectSaraBeeckmans.Models.Supplier", "Supplier")
                        .WithMany("Toestellen")
                        .HasForeignKey("Supplierid");
                });

            modelBuilder.Entity("ProjectSaraBeeckmans.Models.ToestelCategorie", b =>
                {
                    b.HasOne("ProjectSaraBeeckmans.Models.Categorie", "categorie")
                        .WithMany("ToestelCategories")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSaraBeeckmans.Models.Toestel", "toestel")
                        .WithMany("ToestelCategories")
                        .HasForeignKey("ToestelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
