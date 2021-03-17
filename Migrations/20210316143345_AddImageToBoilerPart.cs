using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations
{
    public partial class AddImageToBoilerPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 6, 14, 33, 45, 631, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 8, 14, 33, 45, 634, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 9, 14, 33, 45, 634, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 11, 14, 33, 45, 634, DateTimeKind.Local).AddTicks(2187));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 6, 11, 50, 32, 833, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 8, 11, 50, 32, 836, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 9, 11, 50, 32, 836, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 11, 11, 50, 32, 836, DateTimeKind.Local).AddTicks(2086));
        }
    }
}
