using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WUWA_EF_CORE_Console.Migrations
{
    /// <inheritdoc />
    public partial class WUWA_EF_CORE_Console_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Character");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Character",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
