using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentAPI.Infrastructure.Migrations
{
    public partial class Car_ReservationColumn_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations",
                column: "ReservedCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations",
                column: "ReservedCarId",
                unique: true);
        }
    }
}
