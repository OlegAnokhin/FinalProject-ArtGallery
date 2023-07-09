using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class AddDbPictureComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(3752),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8661),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(4009),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8921),
                oldComment: "Край на изложбата");

            migrationBuilder.CreateTable(
                name: "PicturesComment",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на картината"),
                    CommentId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на коментар")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicturesComment", x => new { x.PictureId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_PicturesComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PicturesComment_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PicturesComment_CommentId",
                table: "PicturesComment",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PicturesComment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8661),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(3752),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8921),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(4009),
                oldComment: "Край на изложбата");
        }
    }
}
