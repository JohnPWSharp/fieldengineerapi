using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.Schedule
{
    public partial class InitialDeployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ProblemDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentStatusId = table.Column<long>(type: "bigint", nullable: false),
                    EngineerId = table.Column<long>(type: "bigint", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStatuses_AppointmentStatusId",
                        column: x => x.AppointmentStatusId,
                        principalTable: "AppointmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1L, "Unresolved" },
                    { 2L, "Parts Ordered" },
                    { 3L, "Fixed" }
                });

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
                    { 6L, "4572 Main St Buffalo, NY 98054", "555-0204", "Tsehayetu Abera" }
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
                columns: new[] { "Id", "AppointmentStatusId", "CustomerId", "EngineerId", "ImageUrl", "Notes", "ProblemDetails", "StartDateTime" },
                values: new object[,]
                {
                    { 1L, 3L, 1L, 1L, null, "Installed a new diverter valve", "Boiler wont start", new DateTime(2021, 3, 12, 15, 0, 42, 286, DateTimeKind.Local).AddTicks(1498) },
                    { 4L, 3L, 1L, 1L, null, "Installed a second new diverter valve", "Boiler wont start", new DateTime(2021, 3, 17, 15, 0, 42, 289, DateTimeKind.Local).AddTicks(966) },
                    { 2L, 2L, 2L, 2L, null, "Needed a new heat exchanger", "Can't change temperature", new DateTime(2021, 3, 14, 15, 0, 42, 289, DateTimeKind.Local).AddTicks(936) },
                    { 3L, 2L, 3L, 2L, null, "Bled radiators.", "Radiators aren't working", new DateTime(2021, 3, 15, 15, 0, 42, 289, DateTimeKind.Local).AddTicks(962) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStatusId",
                table: "Appointments",
                column: "AppointmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EngineerId",
                table: "Appointments",
                column: "EngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentStatuses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Engineers");
        }
    }
}
