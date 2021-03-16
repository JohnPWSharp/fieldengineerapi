using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class AddImageToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoilerParts_Categories_CategoryId",
                table: "BoilerParts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BoilerParts_CategoryId",
                table: "BoilerParts");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BoilerParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CategoryId",
                value: "Flange");

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CategoryId",
                value: "Sprocket");

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CategoryId",
                value: "Boiler");

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CategoryId",
                value: "Exchanger");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "BoilerParts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderedDateTime",
                value: new DateTime(2021, 3, 6, 9, 58, 35, 851, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(2021, 3, 7, 9, 58, 35, 853, DateTimeKind.Local).AddTicks(6975), new DateTime(2021, 3, 4, 9, 58, 35, 853, DateTimeKind.Local).AddTicks(6952) });

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CategoryId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CategoryId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CategoryId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CategoryId",
                value: 4L);

            migrationBuilder.CreateIndex(
                name: "IX_BoilerParts_CategoryId",
                table: "BoilerParts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoilerParts_Categories_CategoryId",
                table: "BoilerParts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
