using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class AddImageToBoilerPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BoilerParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "PCB Assembly", "http://contoso.com/image1", "Pumped Water Controller", 0, "Water pump controller for combination boiler", 45.99m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Heat Exchanger", "http://contoso.com/image2", "3.5 W/S Heater", 5, "Small heat exchanger for domestic boiler", 125.5m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Valve", "http://contoso.com/image3", "Inlet Valve", 13, "Water inlet valve with one-way operation", 120.2m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Valve", "http://contoso.com/image4", "Mid-position Valve", 8, "Bi-directional pressure release", 180.9m });

            migrationBuilder.InsertData(
                table: "BoilerParts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[,]
                {
                    { 5L, "Heat Exchanger", "http://contoso.com/image5", "5.0 W/S Heater", 1, "Medium heat exchanger for canteen boiler", 145.9m },
                    { 6L, "PCB Assembly", "http://contoso.com/image6", "Fan Controller", 7, "Controller for air-con unit", 28.35m }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderedDateTime",
                value: new DateTime(2021, 3, 11, 14, 34, 59, 446, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(2021, 3, 12, 14, 34, 59, 449, DateTimeKind.Local), new DateTime(2021, 3, 9, 14, 34, 59, 448, DateTimeKind.Local).AddTicks(9977) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BoilerParts");

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CategoryId", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Flange", "Caserta Stone Beige", 25, "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.", 8.1m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CategoryId", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Sprocket", "Caserta Sky Grey", 30, "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.", 8.1m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CategoryId", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Boiler", "Ageless Beauty Clay", 5, "Add some fashion to your floors with the Shaw Ageless Beauty Carpet collection.", 1.98m });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CategoryId", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[] { "Exchanger", "Lush II Tundra", 12, "Made with 100% premium nylon fiber, this textured carpet creates a warm, casual atmosphere that invites you to relax and thoroughly enjoy your home.", 3.79m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderedDateTime",
                value: new DateTime(2021, 3, 11, 11, 49, 41, 542, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(2021, 3, 12, 11, 49, 41, 545, DateTimeKind.Local).AddTicks(7044), new DateTime(2021, 3, 9, 11, 49, 41, 545, DateTimeKind.Local).AddTicks(7018) });
        }
    }
}
