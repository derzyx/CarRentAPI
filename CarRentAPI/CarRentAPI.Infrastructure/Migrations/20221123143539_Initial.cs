using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentAPI.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceCategory = table.Column<int>(type: "int", nullable: false),
                    AvgFuelConsumption = table.Column<float>(type: "real", nullable: false),
                    RentalPlaceId = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_RentalPlaces_RentalPlaceId",
                        column: x => x.RentalPlaceId,
                        principalTable: "RentalPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservedCarId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_ReservedCarId",
                        column: x => x.ReservedCarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RentalPlaces",
                columns: new[] { "Id", "BasePrice", "City" },
                values: new object[] { 1, 230f, "Rzeszow" });

            migrationBuilder.InsertData(
                table: "RentalPlaces",
                columns: new[] { "Id", "BasePrice", "City" },
                values: new object[] { 2, 310f, "Poznan" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvgFuelConsumption", "IsReserved", "Name", "PriceCategory", "RentalPlaceId" },
                values: new object[,]
                {
                    { 1, 13.5f, false, "Audi", 3, 1 },
                    { 2, 10.7f, false, "Renault", 2, 1 },
                    { 3, 9.1f, false, "Fiat", 1, 1 },
                    { 4, 17.2f, false, "Porshe", 3, 2 },
                    { 5, 9.7f, false, "Kia", 0, 2 },
                    { 6, 9.1f, false, "Fiat", 1, 2 },
                    { 7, 11.2f, false, "Ford", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalPlaceId",
                table: "Cars",
                column: "RentalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations",
                column: "ReservedCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentalPlaces");
        }
    }
}
