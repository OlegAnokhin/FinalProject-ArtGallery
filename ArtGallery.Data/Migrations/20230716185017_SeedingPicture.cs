using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SeedingPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(7870),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(8097),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(3659),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 370, DateTimeKind.Utc).AddTicks(4734),
                oldComment: "Начало на обучението");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Material",
                value: "Акрил");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Material",
                value: "Акрил");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Material", "Name" },
                values: new object[] { "Африканско момиче със оранжева шапка", "Акрил", "Момиче със оранжева шапка" });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CategoryId", "Description", "ImageAddress", "ImageBase", "Material", "Name", "Size" },
                values: new object[,]
                {
                    { 1, 2, "Момиче с цвете", "\\lib\\images\\Girl1.jpg", "Платно", "Акрил", "Африканско момиче с цвете в косата", "40 х 60" },
                    { 2, 2, "Момиче със синя шапка", "\\lib\\images\\Girl2.jpg", "Платно", "Акрил", "Африканско момиче със синя шапка", "40 х 60" },
                    { 3, 2, "Момиче със оранжева шапка", "\\lib\\images\\Girl3.jpg", "Платно", "Акрил", "Африканско момиче със оранжева шапка", "40 х 60" },
                    { 4, 1, "Портрет на кон", "\\lib\\images\\Animal1.jpg", "Платно", "Акрил", "Конче", "40 х 60" },
                    { 5, 1, "Портрет на царя на животните", "\\lib\\images\\Animal2.jpg", "Платно", "Акрил", "Лъв", "40 х 60" },
                    { 6, 1, "Портрет на тигър", "\\lib\\images\\Animal3.jpg", "Платно", "Акрил", "Тигър", "40 х 60" },
                    { 7, 3, "Три шарени къщички", "\\lib\\images\\House1.jpg", "Платно", "Акрил", "Три шарени къщички", "40 х 60" },
                    { 8, 3, "Шарени къщички на дърво", "\\lib\\images\\House2.jpg", "Платно", "Акрил", "Шарени къщички на дърво", "40 х 60" },
                    { 9, 3, "Шарени къщички на колела", "\\lib\\images\\House3.jpg", "Платно", "Акрил", "Шарени къщички на колела", "40 х 60" },
                    { 10, 4, "Розово дърво", "\\lib\\images\\Nature1.jpg", "Платно", "Акрил", "Розово дърво", "40 х 60" },
                    { 11, 4, "Розово дърво на скала", "\\lib\\images\\Nature2.jpg", "Платно", "Акрил", "Розово дърво на скала", "40 х 60" },
                    { 12, 4, "Бурно море", "\\lib\\images\\Nature3.jpg", "Платно", "Акрил", "Бурно море", "40 х 60" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(367),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 371, DateTimeKind.Utc).AddTicks(674),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 25, 16, 370, DateTimeKind.Utc).AddTicks(4734),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 50, 16, 628, DateTimeKind.Utc).AddTicks(3659),
                oldComment: "Начало на обучението");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Material",
                value: "Акварел");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Material",
                value: "Акварел");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Material", "Name" },
                values: new object[] { "Африканско момиче със зелена шапка", "Акварел", "Момиче със зелена шапка" });
        }
    }
}
