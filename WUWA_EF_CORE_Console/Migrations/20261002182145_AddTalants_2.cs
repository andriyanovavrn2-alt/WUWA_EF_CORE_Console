using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WUWA_EF_CORE_Console.Migrations
{
    /// <inheritdoc />
    public partial class AddTalants_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talants_Talants_TalantId1",
                table: "Talants");

            migrationBuilder.DropIndex(
                name: "IX_Talants_TalantId1",
                table: "Talants");

            migrationBuilder.DropColumn(
                name: "TalantId1",
                table: "Talants");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TalantId",
                table: "Skills",
                column: "TalantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Talants_TalantId",
                table: "Skills",
                column: "TalantId",
                principalTable: "Talants",
                principalColumn: "TalantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Talants_TalantId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TalantId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "TalantId1",
                table: "Talants",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talants_TalantId1",
                table: "Talants",
                column: "TalantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Talants_Talants_TalantId1",
                table: "Talants",
                column: "TalantId1",
                principalTable: "Talants",
                principalColumn: "TalantId");
        }
    }
}
