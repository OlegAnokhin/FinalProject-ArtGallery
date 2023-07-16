using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SeedingExhibition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(367),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(4885),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(674),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(5109),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 370, DateTimeKind.Utc).AddTicks(4734),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(892),
                oldComment: "Начало на обучението");

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "Id", "Description", "End", "ImageUrl", "Name", "Place", "Start" },
                values: new object[] { 1, "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни.", new DateTime(2023, 7, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "\\lib\\images\\ExhibitionAfrica.jpg", "Изложба Африка", "Варна, Галерията на Петя", new DateTime(2023, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(4885),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(367),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(5109),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(674),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(892),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 370, DateTimeKind.Utc).AddTicks(4734),
                oldComment: "Начало на обучението");
        }
    }
}
