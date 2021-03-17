using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Inventory
{
    public partial class NullableDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveredDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { null, new DateTime(2021, 3, 12, 14, 8, 22, 115, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(2021, 3, 13, 14, 8, 22, 118, DateTimeKind.Local).AddTicks(1383), new DateTime(2021, 3, 10, 14, 8, 22, 118, DateTimeKind.Local).AddTicks(1359) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveredDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 14, 34, 59, 446, DateTimeKind.Local).AddTicks(5830) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DeliveredDateTime", "OrderedDateTime" },
                values: new object[] { new DateTime(2021, 3, 12, 14, 34, 59, 449, DateTimeKind.Local), new DateTime(2021, 3, 9, 14, 34, 59, 448, DateTimeKind.Local).AddTicks(9977) });
        }
    }
}
