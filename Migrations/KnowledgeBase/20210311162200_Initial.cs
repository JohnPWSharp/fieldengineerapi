using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldEngineerApi.Migrations.KnowledgeBase
{
    public partial class Initial : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Tips_KnowledgeBaseBoilerPartId",
                table: "Tips",
                column: "KnowledgeBaseBoilerPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_KnowledgeBaseEngineerId",
                table: "Tips",
                column: "KnowledgeBaseEngineerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "BoilerParts");

            migrationBuilder.DropTable(
                name: "Engineers");
        }
    }
}
