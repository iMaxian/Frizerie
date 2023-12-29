﻿// <auto-generated />
using System;
using Frizerie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frizerie.Migrations
{
    [DbContext(typeof(FrizerieContext))]
    [Migration("20231229195403_PrimaMigrare")]
    partial class PrimaMigrare
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("ID");

                    b.HasIndex("BarberID");

                    b.HasIndex("BarberShopID");

                    b.ToTable("Serviciu");
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

            modelBuilder.Entity("Frizerie.Models.Barber", b =>
                {
                    b.Navigation("Servicii");
                });
#pragma warning restore 612, 618
        }
    }
}
