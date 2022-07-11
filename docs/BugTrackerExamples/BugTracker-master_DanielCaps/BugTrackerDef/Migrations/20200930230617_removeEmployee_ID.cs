using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class removeEmployee_ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee_ID",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Employee_ID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
