﻿// <auto-generated />
using CarRentAPI.Infrastructure.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentAPI.OldMigrations
{
    [DbContext(typeof(CarRentDbContext))]
    [Migration("20221116175921_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AvgFuelConsumption")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceCategory")
                        .HasColumnType("int");

                    b.Property<int>("RentalPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RentalPlaceId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRentAPI.Models.RentalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableCars")
                        .HasColumnType("int");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentalPlaces");
                });

            modelBuilder.Entity("CarRentAPI.Models.Car", b =>
                {
                    b.HasOne("CarRentAPI.Models.RentalPlace", null)
                        .WithMany("Car")
                        .HasForeignKey("RentalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarRentAPI.Models.RentalPlace", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}