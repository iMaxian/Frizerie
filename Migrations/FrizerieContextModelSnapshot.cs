﻿// <auto-generated />
using System;
using Frizerie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frizerie.Migrations
{
    [DbContext(typeof(FrizerieContext))]
    partial class FrizerieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Frizerie.Models.Barber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Rateing")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Barber");
                });

            modelBuilder.Entity("Frizerie.Models.BarberShop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rateing")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BarberShop");
                });

            modelBuilder.Entity("Frizerie.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Frizerie.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BarberID")
                        .HasColumnType("int");

                    b.Property<int?>("BarberShopID")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("Data_Programare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tip_Serviciu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BarberID");

                    b.HasIndex("BarberShopID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("Frizerie.Models.ServiciuCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ServiciuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("ServiciuCategory");
                });

            modelBuilder.Entity("Frizerie.Models.Serviciu", b =>
                {
                    b.HasOne("Frizerie.Models.Barber", "Barber")
                        .WithMany("Servicii")
                        .HasForeignKey("BarberID");

                    b.HasOne("Frizerie.Models.BarberShop", "BarberShop")
                        .WithMany()
                        .HasForeignKey("BarberShopID");

                    b.Navigation("Barber");

                    b.Navigation("BarberShop");
                });

            modelBuilder.Entity("Frizerie.Models.ServiciuCategory", b =>
                {
                    b.HasOne("Frizerie.Models.Category", "Category")
                        .WithMany("ServiciuCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Frizerie.Models.Serviciu", "Serviciu")
                        .WithMany("ServiciuCategories")
                        .HasForeignKey("ServiciuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Serviciu");
                });

            modelBuilder.Entity("Frizerie.Models.Barber", b =>
                {
                    b.Navigation("Servicii");
                });

            modelBuilder.Entity("Frizerie.Models.Category", b =>
                {
                    b.Navigation("ServiciuCategories");
                });

            modelBuilder.Entity("Frizerie.Models.Serviciu", b =>
                {
                    b.Navigation("ServiciuCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
