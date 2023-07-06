using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class seedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(6871),
                comment: "Дата на създаване на картината",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Дата на създаване на картината");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(4860),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 5, 33, 35, 320, DateTimeKind.Utc).AddTicks(5888),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(5161),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 5, 33, 35, 320, DateTimeKind.Utc).AddTicks(6364),
                oldComment: "Край на изложбата");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Животни" },
                    { 2, "Хора" },
                    { 3, "Къщи" },
                    { 4, "Пейзаж" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                type: "datetime2",
                nullable: false,
                comment: "Дата на създаване на картината",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(6871),
                oldComment: "Дата на създаване на картината");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 5, 33, 35, 320, DateTimeKind.Utc).AddTicks(5888),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(4860),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 5, 33, 35, 320, DateTimeKind.Utc).AddTicks(6364),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(5161),
                oldComment: "Край на изложбата");
        }
    }
}
