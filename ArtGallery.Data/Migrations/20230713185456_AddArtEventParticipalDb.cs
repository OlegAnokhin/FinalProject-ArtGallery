using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class AddArtEventParticipalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ArtEvents_ArtEventId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ArtEventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArtEventId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 874, DateTimeKind.Utc).AddTicks(2808),
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
                defaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 874, DateTimeKind.Utc).AddTicks(3032),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(4009),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 873, DateTimeKind.Utc).AddTicks(9547),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Начало на обучението");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtEventParticipants",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtEventParticipants", x => new { x.ParticipantId, x.ArtEventId });
                    table.ForeignKey(
                        name: "FK_ArtEventParticipants_ArtEvents_ArtEventId",
                        column: x => x.ArtEventId,
                        principalTable: "ArtEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtEventParticipants_IdentityUser_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtEventParticipants_ArtEventId",
                table: "ArtEventParticipants",
                column: "ArtEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtEventParticipants");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 7, 4, 46, 819, DateTimeKind.Utc).AddTicks(3752),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 874, DateTimeKind.Utc).AddTicks(2808),
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
                oldDefaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 874, DateTimeKind.Utc).AddTicks(3032),
                oldComment: "Край на изложбата");

            migrationBuilder.AddColumn<int>(
                name: "ArtEventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 13, 18, 54, 55, 873, DateTimeKind.Utc).AddTicks(9547),
                oldComment: "Начало на обучението");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ArtEventId",
                table: "AspNetUsers",
                column: "ArtEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ArtEvents_ArtEventId",
                table: "AspNetUsers",
                column: "ArtEventId",
                principalTable: "ArtEvents",
                principalColumn: "Id");
        }
    }
}
