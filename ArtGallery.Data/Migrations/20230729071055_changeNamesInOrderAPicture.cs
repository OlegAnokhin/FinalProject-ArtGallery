using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class changeNamesInOrderAPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrdersAPictures");

            migrationBuilder.RenameColumn(
                name: "ImageAddress",
                table: "OrdersAPictures",
                newName: "ImageData");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "OrdersAPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Име на заявка");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 225, DateTimeKind.Utc).AddTicks(3364),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 729, DateTimeKind.Utc).AddTicks(731),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 225, DateTimeKind.Utc).AddTicks(3689),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 729, DateTimeKind.Utc).AddTicks(1020),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 224, DateTimeKind.Utc).AddTicks(5704),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 728, DateTimeKind.Utc).AddTicks(5721),
                oldComment: "Начало на обучението");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1f40236-ee63-452f-8c56-18f952098074",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db46638a-7ad1-4299-a854-253bcf70843a", "AQAAAAEAACcQAAAAEOgrV9GJmk2ksekN64QBHahRNInMsw0YFaNyrdKSKQtKcdZEozhQX5pYrtjezTdPfA==", "28f8e75b-b197-4829-84a0-a6202a67da93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8983e62a-8202-48a1-b8a5-c4a80c6ce507", "AQAAAAEAACcQAAAAEK12C7ikmOLV7Wf91M3SfuyD25GxBNV2Bp63yZRvAQWQiNy5EshZPKNUw5J2VgRUsQ==", "faa03379-1870-4ad4-9e76-ffe42d72473c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "OrdersAPictures");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "OrdersAPictures",
                newName: "ImageAddress");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrdersAPictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 729, DateTimeKind.Utc).AddTicks(731),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 225, DateTimeKind.Utc).AddTicks(3364),
                oldComment: "Начало на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 729, DateTimeKind.Utc).AddTicks(1020),
                comment: "Край на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 225, DateTimeKind.Utc).AddTicks(3689),
                oldComment: "Край на изложбата");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ArtEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 728, DateTimeKind.Utc).AddTicks(5721),
                comment: "Начало на обучението",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 224, DateTimeKind.Utc).AddTicks(5704),
                oldComment: "Начало на обучението");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1f40236-ee63-452f-8c56-18f952098074",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a8f8de5-544f-4863-bcaa-d7474e23ddc0", "AQAAAAEAACcQAAAAEPccProhi14LvTYsC0bmE/GJICB11jKASEIb86tLup00pHc0qO47Q/YaI4imQf+tTQ==", "495820af-031a-451d-adce-ab224383378e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12842d64-468b-4508-9161-0be3cad031d4", "AQAAAAEAACcQAAAAEE5XM4KAHwTEjs+wUvzSe++iKimfWUKs4rdUa0IMEYhtUCABxA5UnqGCWF4G31V1yw==", "ea7a676f-8fee-4828-ac7b-61b56ef777c5" });
        }
    }
}
