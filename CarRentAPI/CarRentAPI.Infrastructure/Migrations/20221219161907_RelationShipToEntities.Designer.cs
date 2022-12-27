﻿// <auto-generated />
using System;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentAPI.Infrastructure.Migrations
{
    [DbContext(typeof(CarRentDbContext))]
    [Migration("20221219161907_RelationShipToEntities")]
    partial class RelationShipToEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentAPI.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AvgFuelConsumption")
                        .HasColumnType("real");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvgFuelConsumption = 13.5f,
                            IsReserved = false,
                            Name = "Audi",
                            PriceCategory = 3,
                            RentalPlaceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AvgFuelConsumption = 10.7f,
                            IsReserved = false,
                            Name = "Renault",
                            PriceCategory = 2,
                            RentalPlaceId = 1
                        },
                        new
                        {
                            Id = 3,
                            AvgFuelConsumption = 9.1f,
                            IsReserved = false,
                            Name = "Fiat",
                            PriceCategory = 1,
                            RentalPlaceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AvgFuelConsumption = 17.2f,
                            IsReserved = false,
                            Name = "Porshe",
                            PriceCategory = 3,
                            RentalPlaceId = 2
                        },
                        new
                        {
                            Id = 5,
                            AvgFuelConsumption = 9.7f,
                            IsReserved = false,
                            Name = "Kia",
                            PriceCategory = 0,
                            RentalPlaceId = 2
                        },
                        new
                        {
                            Id = 6,
                            AvgFuelConsumption = 9.1f,
                            IsReserved = false,
                            Name = "Fiat",
                            PriceCategory = 1,
                            RentalPlaceId = 2
                        },
                        new
                        {
                            Id = 7,
                            AvgFuelConsumption = 11.2f,
                            IsReserved = false,
                            Name = "Ford",
                            PriceCategory = 2,
                            RentalPlaceId = 2
                        });
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.RentalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("BasePrice")
                        .HasColumnType("real");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentalPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 230f,
                            City = "Rzeszow"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 310f,
                            City = "Poznan"
                        });
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservedCarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservedCarId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRentAPI.Domain.Entities.RentalPlace", "RentalPlace")
                        .WithMany("Car")
                        .HasForeignKey("RentalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentalPlace");
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("CarRentAPI.Domain.Entities.Car", "ReservedCar")
                        .WithOne("Reservation")
                        .HasForeignKey("CarRentAPI.Domain.Entities.Reservation", "ReservedCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservedCar");
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.Car", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("CarRentAPI.Domain.Entities.RentalPlace", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
