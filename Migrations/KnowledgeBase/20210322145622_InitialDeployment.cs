using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.KnowledgeBase
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
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilerParts", x => x.Id);
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
                name: "Tips",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnowledgeBaseBoilerPartId = table.Column<long>(type: "bigint", nullable: false),
                    KnowledgeBaseEngineerId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tips_BoilerParts_KnowledgeBaseBoilerPartId",
                        column: x => x.KnowledgeBaseBoilerPartId,
                        principalTable: "BoilerParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Engineers_KnowledgeBaseEngineerId",
                        column: x => x.KnowledgeBaseEngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tips_KnowledgeBaseBoilerPartId",
                table: "Tips",
                column: "KnowledgeBaseBoilerPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_KnowledgeBaseEngineerId",
                table: "Tips",
                column: "KnowledgeBaseEngineerId");

            // Create a unified view of the knowledge base for Azure Search to index
            migrationBuilder.Sql(
                @"CREATE OR ALTER VIEW [dbo].[Knowledge] AS
                    SELECT T.Id, T.Subject, T.Body, B.Name, B.Overview
                    FROM [dbo].[Tips] T INNER JOIN [dbo].[BoilerParts] B 
                    ON B.Id=T.KnowledgeBaseBoilerPartId"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "BoilerParts");

            migrationBuilder.DropTable(
                name: "Engineers");

            migrationBuilder.Sql(@"DROP VIEW Knowledge");
        }
    }
}
