using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SeedingArtEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(4885),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(5109),
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
                defaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(892),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 61, DateTimeKind.Utc).AddTicks(4063),
                oldComment: "Начало на обучението");

            migrationBuilder.InsertData(
                table: "ArtEvents",
                columns: new[] { "Id", "Description", "ImageAddress", "Name", "Place", "Start" },
                values: new object[] { 1, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventPinkTree.jpg", "Розовото дърво", "Варна, Галерията на Петя", new DateTime(2023, 7, 26, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ArtEvents",
                columns: new[] { "Id", "Description", "ImageAddress", "Name", "Place", "Start" },
                values: new object[] { 2, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventCatWithCoffee.jpg", "Коте с кафе", "Варна, Галерията на Петя", new DateTime(2023, 7, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ArtEvents",
                columns: new[] { "Id", "Description", "ImageAddress", "Name", "Place", "Start" },
                values: new object[] { 3, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventDogWithBrush.jpg", "Куче художник", "Варна, Галерията на Петя", new DateTime(2023, 7, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1301),
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
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 62, DateTimeKind.Utc).AddTicks(1726),
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
                defaultValue: new DateTime(2023, 7, 16, 16, 4, 10, 61, DateTimeKind.Utc).AddTicks(4063),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 18, 7, 33, 847, DateTimeKind.Utc).AddTicks(892),
                oldComment: "Начало на обучението");
        }
    }
}
