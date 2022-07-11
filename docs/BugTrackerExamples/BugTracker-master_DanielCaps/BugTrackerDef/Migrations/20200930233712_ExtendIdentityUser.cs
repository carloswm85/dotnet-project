using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Empregado_ID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empregado_ID",
                table: "AspNetUsers");
        }
    }
}
