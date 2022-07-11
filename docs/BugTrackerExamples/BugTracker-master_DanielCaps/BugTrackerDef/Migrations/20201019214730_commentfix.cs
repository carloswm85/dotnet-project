using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class commentfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Comments");
        }
    }
}
