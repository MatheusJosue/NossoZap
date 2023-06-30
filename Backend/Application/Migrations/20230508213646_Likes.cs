using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class Likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_Postid",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "publicationId",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "Postid",
                table: "Like",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_Postid",
                table: "Like",
                newName: "IX_Like_postId");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_postId",
                table: "Like",
                column: "postId",
                principalTable: "Post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_postId",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Like",
                newName: "Postid");

            migrationBuilder.RenameIndex(
                name: "IX_Like_postId",
                table: "Like",
                newName: "IX_Like_Postid");

            migrationBuilder.AlterColumn<int>(
                name: "Postid",
                table: "Like",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "publicationId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_Postid",
                table: "Like",
                column: "Postid",
                principalTable: "Post",
                principalColumn: "id");
        }
    }
}
