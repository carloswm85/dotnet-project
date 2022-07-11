using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class TicketFixMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "AssignedDev",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Submitter",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketPriority",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketStatus",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketType",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDev",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Submitter",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketPriority",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
