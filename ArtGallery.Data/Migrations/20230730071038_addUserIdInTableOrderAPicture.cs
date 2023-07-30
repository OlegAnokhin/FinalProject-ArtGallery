using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class addUserIdInTableOrderAPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "OrdersAPictures",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Допълнителни желания към картината",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Допълнителни желания към картината");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "OrdersAPictures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Идентификатор на потребителя");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(1793),
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
                defaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(2046),
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
                defaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 430, DateTimeKind.Utc).AddTicks(6351),
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
                values: new object[] { "18e81716-9f22-4db9-8fef-1e6cee0f1325", "AQAAAAEAACcQAAAAEDzn370UUEolWocyw6RE0grgG3uhRN4L1i0zx6wTvcYPM5BjRBlXprGH537Ph0Y7eQ==", "d62f880c-95bf-4be8-991b-c616f88d16ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33093f3e-7375-4ede-b645-3013eb36e355", "AQAAAAEAACcQAAAAEHGX1C5xX4tCESUWfYk9G/7n9gaeYoSjuNbO2FuLBWCRp/A9anAvK1d310YH0hVHVw==", "9008cabf-3b5a-4c91-b643-56143f665b1b" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersAPictures_userId",
                table: "OrdersAPictures",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersAPictures_AspNetUsers_userId",
                table: "OrdersAPictures",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersAPictures_AspNetUsers_userId",
                table: "OrdersAPictures");

            migrationBuilder.DropIndex(
                name: "IX_OrdersAPictures_userId",
                table: "OrdersAPictures");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "OrdersAPictures");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "OrdersAPictures",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Допълнителни желания към картината",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Допълнителни желания към картината");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 29, 7, 10, 55, 225, DateTimeKind.Utc).AddTicks(3364),
                comment: "Начало на изложбата",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(1793),
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
                oldDefaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(2046),
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
                oldDefaultValue: new DateTime(2023, 7, 30, 7, 10, 38, 430, DateTimeKind.Utc).AddTicks(6351),
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
    }
}
