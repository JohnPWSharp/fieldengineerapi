using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "StatusName",
                value: "Unresolved");

            migrationBuilder.UpdateData(
                table: "AppointmentStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "StatusName",
                value: "Parts Ordered");

            migrationBuilder.InsertData(
                table: "AppointmentStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 3L, "Fixed" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ContactNumber", "Name" },
                values: new object[,]
                {
                    { 1L, "4567 Main St Buffalo, NY 98052", "555-0199", "Damayanti Basumatary" },
                    { 2L, "4568 Main St Buffalo, NY 98052", "555-0200", "Deepali Haloi" },
                    { 3L, "4569 Main St Buffalo, NY 98052", "555-0201", "Hua Long" },
                    { 4L, "4570 Main St Buffalo, NY 98052", "555-0202", "Volha Pashkevich" },
                    { 5L, "4571 Main St Buffalo, NY 98053", "555-0203", "Veselin Iliev" },
                    { 6L, "4571 Main St Buffalo, NY 98054", "555-0204", "Tsehayetu Abera" }
                });

            migrationBuilder.InsertData(
                table: "Engineers",
                columns: new[] { "Id", "ContactNumber", "Name" },
                values: new object[,]
                {
                    { 1L, "554-1000", "Sara Perez" },
                    { 2L, "554-1001", "Michelle Harris" },
                    { 3L, "554-1002", "Quincy Watson" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentStatusId", "CustomerId", "EngineerId", "Notes", "ProblemDetails", "StartDateTime" },
                values: new object[] { 1L, 3L, 1L, 1L, "Installed a new diverter valva", "Boiler wont start", new DateTime(2021, 2, 28, 17, 29, 21, 576, DateTimeKind.Local).AddTicks(7101) });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentStatusId", "CustomerId", "EngineerId", "Notes", "ProblemDetails", "StartDateTime" },
                values: new object[] { 2L, 2L, 2L, 2L, "Needed a new heat exchanger", "Can't change temperature", new DateTime(2021, 3, 2, 17, 29, 21, 579, DateTimeKind.Local).AddTicks(2438) });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentStatusId", "CustomerId", "EngineerId", "Notes", "ProblemDetails", "StartDateTime" },
                values: new object[] { 3L, 2L, 3L, 2L, "Bled radiators.", "Radiators aren't working", new DateTime(2021, 3, 3, 17, 29, 21, 579, DateTimeKind.Local).AddTicks(2465) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AppointmentStatuses",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "AppointmentStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "StatusName",
                value: "Open");

            migrationBuilder.UpdateData(
                table: "AppointmentStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "StatusName",
                value: "Resolved");
        }
    }
}
