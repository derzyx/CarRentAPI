using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentAPI.Migrations
{
    public partial class ExampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCars",
                table: "RentalPlaces");

            migrationBuilder.AlterColumn<float>(
                name: "BasePrice",
                table: "RentalPlaces",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "AvgFuelConsumption",
                table: "Cars",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
                columns: new[] { "Id", "AvgFuelConsumption", "Name", "PriceCategory", "RentalPlaceId" },
                values: new object[,]
                {
                    { 1, 13.5f, "Audi", 3, 1 },
                    { 2, 10.7f, "Renault", 2, 1 },
                    { 3, 9.1f, "Fiat", 1, 1 },
                    { 4, 17.2f, "Porshe", 3, 2 },
                    { 5, 9.7f, "Kia", 0, 2 },
                    { 6, 9.1f, "Fiat", 1, 2 },
                    { 7, 11.2f, "Ford", 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalPlaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalPlaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<double>(
                name: "BasePrice",
                table: "RentalPlaces",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCars",
                table: "RentalPlaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "AvgFuelConsumption",
                table: "Cars",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
