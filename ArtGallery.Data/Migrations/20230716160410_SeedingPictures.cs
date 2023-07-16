using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SeedingPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1301),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 699, DateTimeKind.Utc).AddTicks(1305),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1726),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 699, DateTimeKind.Utc).AddTicks(1574),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 61, DateTimeKind.Utc).AddTicks(4063),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 698, DateTimeKind.Utc).AddTicks(4597),
                oldComment: "Начало на обучението");

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CategoryId", "Description", "ImageAddress", "ImageBase", "Material", "Name", "Size" },
                values: new object[] { 1, 2, "Африканско момиче с цвете в косата", "\\lib\\images\\Girl1.jpg", "Платно", "Акварел", "Момиче с цвете", "40 х 60" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CategoryId", "Description", "ImageAddress", "ImageBase", "Material", "Name", "Size" },
                values: new object[] { 2, 2, "Африканско момиче със синя шапка", "\\lib\\images\\Girl2.jpg", "Платно", "Акварел", "Момиче със синя шапка", "40 х 60" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CategoryId", "Description", "ImageAddress", "ImageBase", "Material", "Name", "Size" },
                values: new object[] { 3, 2, "Африканско момиче със зелена шапка", "\\lib\\images\\Girl3.jpg", "Платно", "Акварел", "Момиче със зелена шапка", "40 х 60" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 699, DateTimeKind.Utc).AddTicks(1305),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1301),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 699, DateTimeKind.Utc).AddTicks(1574),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1726),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 0, 27, 698, DateTimeKind.Utc).AddTicks(4597),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 61, DateTimeKind.Utc).AddTicks(4063),
                oldComment: "Начало на обучението");
        }
    }
}
