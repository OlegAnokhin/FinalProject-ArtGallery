using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SeedAdminAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(6392),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(7870),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(6794),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(8097),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(1376),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(3659),
                oldComment: "Начало на обучението");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1f40236-ee63-452f-8c56-18f952098074", 0, "8404f792-9ba4-491f-a301-f3e5efb1c408", "guest@ArtGallery.bg", false, false, null, "GUEST@ARTGALLERY.BG", "GUEST@ARTGALLERY.BG", "AQAAAAEAACcQAAAAEHfYpqpxvQM34khlAWYV6GRSK9srcGjLDMa+izGLISX8QzP7l+hsN5z1Y7ZQGkP2XA==", null, false, "33f1f095-f14a-4d85-9abf-f48b9b286fb0", false, "guest@ArtGallery.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d53a80c3-5fd9-4451-a381-f40d2f50ec08", 0, "8fa4db39-2928-4f76-a27c-e81f32d3f4b2", "admin@ArtGallery.bg", false, false, null, "ADMIN@ARTGALLERY.BG", "ADMIN@ARTGALLERY.BG", "AQAAAAEAACcQAAAAEKA4YOngXwQiB0Unhsxucak6uqXNAJsUnzPKY4MCBqtX77vziWsturfwG6XmpS2cDA==", null, false, "4b6708ed-887f-4aaa-a109-b6b0abc9bf18", false, "admin@ArtGallery.bg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1f40236-ee63-452f-8c56-18f952098074");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d53a80c3-5fd9-4451-a381-f40d2f50ec08");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(7870),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(6392),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(8097),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(6794),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(3659),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 9, 4, 11, 19, DateTimeKind.Utc).AddTicks(1376),
                oldComment: "Начало на обучението");
        }
    }
}
