using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WUWA_EF_CORE_Console.Migrations
{
    /// <inheritdoc />
    public partial class AddTalant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TalantId",
                table: "Skills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Talants",
                columns: table => new
                {
                    TalantId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TalantName = table.Column<string>(type: "text", nullable: false),
                    TalantId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talants", x => x.TalantId);
                    table.ForeignKey(
                        name: "FK_Talants_Talants_TalantId1",
                        column: x => x.TalantId1,
                        principalTable: "Talants",
                        principalColumn: "TalantId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talants_TalantId1",
                table: "Talants",
                column: "TalantId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talants");

            migrationBuilder.DropColumn(
                name: "TalantId",
                table: "Skills");
        }
    }
}
