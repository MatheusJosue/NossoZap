using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class RequestWithUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "toUserId",
                table: "Request",
                newName: "toUsername");

            migrationBuilder.RenameColumn(
                name: "fromUserId",
                table: "Request",
                newName: "fromUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "toUsername",
                table: "Request",
                newName: "toUserId");

            migrationBuilder.RenameColumn(
                name: "fromUsername",
                table: "Request",
                newName: "fromUserId");
        }
    }
}
