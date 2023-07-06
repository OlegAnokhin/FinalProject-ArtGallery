using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class changeOnCreatedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
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
                defaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8661),
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
                defaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8921),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 12, 15, 45, 321, DateTimeKind.Utc).AddTicks(5161),
                oldComment: "Край на изложбата");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValueSql: "GETDATE()",
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
                oldDefaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8661),
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
                oldDefaultValue: new DateTime(2023, 7, 6, 14, 57, 7, 371, DateTimeKind.Utc).AddTicks(8921),
                oldComment: "Край на изложбата");
        }
    }
}
