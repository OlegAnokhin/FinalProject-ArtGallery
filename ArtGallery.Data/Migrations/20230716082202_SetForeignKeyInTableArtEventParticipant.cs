using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class SetForeignKeyInTableArtEventParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(6533),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 926, DateTimeKind.Utc).AddTicks(2879),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(6770),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 926, DateTimeKind.Utc).AddTicks(3116),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(1685),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 925, DateTimeKind.Utc).AddTicks(8506),
                oldComment: "Начало на обучението");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 926, DateTimeKind.Utc).AddTicks(2879),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(6533),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 926, DateTimeKind.Utc).AddTicks(3116),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(6770),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 8, 8, 27, 925, DateTimeKind.Utc).AddTicks(8506),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 8, 22, 2, 581, DateTimeKind.Utc).AddTicks(1685),
                oldComment: "Начало на обучението");
        }
    }
}
