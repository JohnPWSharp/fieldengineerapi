using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoilerParts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilerParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoilerParts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DeliveredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Boiler" },
                    { 2L, "Sprocket" },
                    { 3L, "Flange" },
                    { 4L, "Exchanger" }
                });

            migrationBuilder.InsertData(
                table: "BoilerParts",
                columns: new[] { "Id", "CategoryId", "Name", "NumberInStock", "Overview", "Price" },
                values: new object[,]
                {
                    { 3L, 1L, "Ageless Beauty Clay", 5, "Add some fashion to your floors with the Shaw Ageless Beauty Carpet collection.", 1.98m },
                    { 2L, 2L, "Caserta Sky Grey", 30, "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.", 8.1m },
                    { 1L, 3L, "Caserta Stone Beige", 25, "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.", 8.1m },
                    { 4L, 4L, "Lush II Tundra", 12, "Made with 100% premium nylon fiber, this textured carpet creates a warm, casual atmosphere that invites you to relax and thoroughly enjoy your home.", 3.79m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BoilerPartId", "Delivered", "DeliveredDateTime", "OrderedDateTime", "TotalPrice", "quantity" },
                values: new object[] { 2L, 3L, true, new DateTime(2021, 3, 7, 9, 58, 35, 853, DateTimeKind.Local).AddTicks(6975), new DateTime(2021, 3, 4, 9, 58, 35, 853, DateTimeKind.Local).AddTicks(6952), 39.6m, 20L });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BoilerPartId", "Delivered", "DeliveredDateTime", "OrderedDateTime", "TotalPrice", "quantity" },
                values: new object[] { 1L, 1L, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 6, 9, 58, 35, 851, DateTimeKind.Local).AddTicks(251), 243.0m, 30L });

            migrationBuilder.CreateIndex(
                name: "IX_BoilerParts_CategoryId",
                table: "BoilerParts",
                column: "CategoryId");

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

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
