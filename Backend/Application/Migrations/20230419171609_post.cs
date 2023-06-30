using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Publication_publicationId",
                table: "Like");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Like_publicationId",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Like",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UserId",
                table: "Like",
                newName: "IX_Like_userId");

            migrationBuilder.UpdateData(
                table: "Like",
                keyColumn: "userId",
                keyValue: null,
                column: "userId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Like",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Postid",
                table: "Like",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    photo = table.Column<byte[]>(type: "longblob", nullable: true),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Postid",
                table: "Like",
                column: "Postid");

            migrationBuilder.CreateIndex(
                name: "IX_Post_userId",
                table: "Post",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_userId",
                table: "Like",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_Postid",
                table: "Like",
                column: "Postid",
                principalTable: "Post",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_userId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_Postid",
                table: "Like");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Like_Postid",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Postid",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Like",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_userId",
                table: "Like",
                newName: "IX_Like_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Like",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    photo = table.Column<byte[]>(type: "longblob", nullable: true),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.id);
                    table.ForeignKey(
                        name: "FK_Publication_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Like_publicationId",
                table: "Like",
                column: "publicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_UserId",
                table: "Publication",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Publication_publicationId",
                table: "Like",
                column: "publicationId",
                principalTable: "Publication",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
