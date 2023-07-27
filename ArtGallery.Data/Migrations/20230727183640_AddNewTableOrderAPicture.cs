using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class AddNewTableOrderAPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrdersAPictures",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Идентификатор на потребителя",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 18, 36, 39, 729, DateTimeKind.Utc).AddTicks(731),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 232, DateTimeKind.Utc).AddTicks(2611),
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
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 232, DateTimeKind.Utc).AddTicks(2884),
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
                oldDefaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 231, DateTimeKind.Utc).AddTicks(8739),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OrdersAPictures",
                type: "int",
                nullable: false,
                comment: "Идентификатор на потребителя",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 232, DateTimeKind.Utc).AddTicks(2611),
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
                defaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 232, DateTimeKind.Utc).AddTicks(2884),
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
                defaultValue: new DateTime(2023, 7, 27, 18, 33, 3, 231, DateTimeKind.Utc).AddTicks(8739),
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
                values: new object[] { "5c6d2a91-2a91-4670-a3b1-41731c78a44b", "AQAAAAEAACcQAAAAEGBGn3u2pYX5dvrozIINUjf5QOwmLqQM+YWT+zglx91rkVIExryPqc5vZ4TFq0hZ+g==", "8f46a275-88cd-4529-a075-f67af1829bad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6db707d0-91eb-4dda-9065-111e36d31cbf", "AQAAAAEAACcQAAAAEAmKZC/ihJyuoNIlcqnkuoJ1kGoRX1dK07z6H4w+UUf2fyYblXdS4b4Ye8ckKMdSuw==", "4f65f007-468e-486e-97d0-578a0f409610" });
        }
    }
}
