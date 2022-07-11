using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class FixTicketEmplid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Tickets");
        }
    }
}
