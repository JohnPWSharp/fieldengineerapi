using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations
{
    public partial class AddImageToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Address",
                value: "4572 Main St Buffalo, NY 98054");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 1, 9, 58, 8, 204, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 3, 9, 58, 8, 207, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 4, 9, 58, 8, 207, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "StartDateTime",
                value: new DateTime(2021, 3, 6, 9, 58, 8, 207, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Address",
                value: "4571 Main St Buffalo, NY 98054");
        }
    }
}
