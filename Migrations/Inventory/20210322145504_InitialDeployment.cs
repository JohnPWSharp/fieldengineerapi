using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class InitialDeployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoilerParts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberInStock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilerParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoilerPartId = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    OrderedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_BoilerParts_BoilerPartId",
                        column: x => x.BoilerPartId,
                        principalTable: "BoilerParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoilerParts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[,]
                {
                    { 1L, "PCB Assembly", "http://contoso.com/image1", "Pumped Water Controller", 0, "Water pump controller for combination boiler", 45.99m },
                    { 2L, "Heat Exchanger", "http://contoso.com/image2", "3.5 W/S Heater", 5, "Small heat exchanger for domestic boiler", 125.5m },
                    { 3L, "Valve", "http://contoso.com/image3", "Inlet Valve", 13, "Water inlet valve with one-way operation", 120.2m },
                    { 4L, "Valve", "http://contoso.com/image4", "Mid-position Valve", 8, "Bi-directional pressure release", 180.9m },
                    { 5L, "Heat Exchanger", "http://contoso.com/image5", "5.0 W/S Heater", 1, "Medium heat exchanger for canteen boiler", 145.9m },
                    { 6L, "PCB Assembly", "http://contoso.com/image6", "Fan Controller", 7, "Controller for air-con unit", 28.35m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BoilerPartId", "Delivered", "DeliveredDateTime", "OrderedDateTime", "TotalPrice", "quantity" },
                values: new object[] { 1L, 1L, false, null, new DateTime(2021, 3, 17, 14, 55, 4, 127, DateTimeKind.Local).AddTicks(5924), 243.0m, 30L });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BoilerPartId", "Delivered", "DeliveredDateTime", "OrderedDateTime", "TotalPrice", "quantity" },
                values: new object[] { 2L, 3L, true, new DateTime(2021, 3, 18, 14, 55, 4, 130, DateTimeKind.Local).AddTicks(9776), new DateTime(2021, 3, 15, 14, 55, 4, 130, DateTimeKind.Local).AddTicks(9743), 39.6m, 20L });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BoilerPartId",
                table: "Orders",
                column: "BoilerPartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BoilerParts");
        }
    }
}
