using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class newcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Comment",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_postId",
                table: "Comment",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment",
                column: "postId",
                principalTable: "Post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_postId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_postId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Comment");
        }
    }
}
