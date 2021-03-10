using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoilerParts_Category_CategoryId",
                table: "BoilerParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

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
                values: new object[] { 2L, 3L, true, new DateTime(2021, 3, 6, 17, 29, 45, 695, DateTimeKind.Local).AddTicks(2442), new DateTime(2021, 3, 3, 17, 29, 45, 695, DateTimeKind.Local).AddTicks(2416), 39.6m, 20L });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BoilerPartId", "Delivered", "DeliveredDateTime", "OrderedDateTime", "TotalPrice", "quantity" },
                values: new object[] { 1L, 1L, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 5, 17, 29, 45, 692, DateTimeKind.Local).AddTicks(7244), 243.0m, 30L });

            migrationBuilder.AddForeignKey(
                name: "FK_BoilerParts_Categories_CategoryId",
                table: "BoilerParts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoilerParts_Categories_CategoryId",
                table: "BoilerParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoilerParts_Category_CategoryId",
                table: "BoilerParts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
