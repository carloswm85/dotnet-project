using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerDef.Migrations
{
    public partial class AddingComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Tickets_TicketID",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TicketID",
                table: "Comments",
                newName: "IX_Comments_TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TicketID",
                table: "Comment",
                newName: "IX_Comment_TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Tickets_TicketID",
                table: "Comment",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
