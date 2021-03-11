using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.KnowledgeBase
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoilerParts",
                columns: new[] { "Id", "Name", "Overview" },
                values: new object[,]
                {
                    { 1L, "Caserta Stone Beige", "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations." },
                    { 2L, "Caserta Sky Grey", "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations." },
                    { 3L, "Ageless Beauty Clay", "Add some fashion to your floors with the Shaw Ageless Beauty Carpet collection." },
                    { 4L, "Lush II Tundra", "Made with 100% premium nylon fiber, this textured carpet creates a warm, casual atmosphere that invites you to relax and thoroughly enjoy your home." }
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
                table: "Tips",
                columns: new[] { "Id", "Body", "KnowledgeBaseBoilerPartId", "KnowledgeBaseEngineerId", "Subject" },
                values: new object[] { 3L, "Sometimes the nozzle gets clogged with old oil or dirt. You can use a fine point to clear it, or replace.", 3L, 1L, "How to get this nozzle to light the furnace correctly" });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "Id", "Body", "KnowledgeBaseBoilerPartId", "KnowledgeBaseEngineerId", "Subject" },
                values: new object[] { 1L, "If water doesn't get hot when radiators are on, replace the diverter valve.", 1L, 3L, "How to get water to the right temperature" });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "Id", "Body", "KnowledgeBaseBoilerPartId", "KnowledgeBaseEngineerId", "Subject" },
                values: new object[] { 2L, "When installing this unit, don't place it more that 5 feet higher than the fuel tank, without a fuel pump.", 1L, 3L, "Where to site this boiler" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tips",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tips",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tips",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "BoilerParts",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Engineers",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
