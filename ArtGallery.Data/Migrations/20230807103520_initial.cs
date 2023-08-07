using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на обучението"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 7, 10, 35, 19, 906, DateTimeKind.Utc).AddTicks(8576), comment: "Начало на обучението"),
                    ImageAddress = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Адреса на изображението"),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Мястото на обучението"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Описание на обучението")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtEvents", x => x.Id);
                },
                comment: "Обучение");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на категорията")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на категория на картината")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Категория");

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на изложбата"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Адреса на изображинието"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 7, 10, 35, 19, 907, DateTimeKind.Utc).AddTicks(2688), comment: "Начало на изложбата"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 7, 10, 35, 19, 907, DateTimeKind.Utc).AddTicks(2910), comment: "Край на изложбата"),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Мястото на изложбата"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Описание на изложбата")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                },
                comment: "Изложба");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtEventParticipants",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtEventParticipants", x => new { x.ParticipantId, x.ArtEventId });
                    table.ForeignKey(
                        name: "FK_ArtEventParticipants_ArtEvents_ArtEventId",
                        column: x => x.ArtEventId,
                        principalTable: "ArtEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtEventParticipants_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersAPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Идентификатор на потребителя"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Име на заявка"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Вашите имена"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Вашият телефонен номер"),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Желаният размер на картината"),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "С каква боя желаете да бъде нарисувана картината"),
                    ImageBase = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Върху какво желаете да бъде нарисувана картината"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Допълнителни желания към картината"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "Добавете изображението")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersAPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersAPictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на картината"),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Размер на картината"),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "С какво е нарисувана картината"),
                    ImageAddress = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Адреса на изображението"),
                    ImageBase = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Върху какво е нарисувана картината"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на категорията"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Описание на картината"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Дата на създаване на картината")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Картинa");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на коментара")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Име на коментиращият"),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Съдържание на коментара"),
                    PictureId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор на картината")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ArtEvents",
                columns: new[] { "Id", "Description", "ImageAddress", "Name", "Place", "Start" },
                values: new object[,]
                {
                    { 1, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventPinkTree.jpg", "Розовото дърво", "Варна, Галерията на Петя", new DateTime(2023, 7, 26, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventCatWithCoffee.jpg", "Коте с кафе", "Варна, Галерията на Петя", new DateTime(2023, 7, 27, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.", "\\lib\\images\\ArtEventDogWithBrush.jpg", "Куче художник", "Варна, Галерията на Петя", new DateTime(2023, 7, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c1f40236-ee63-452f-8c56-18f952098074", 0, "d512f807-917a-42f8-af0c-825019d2993b", "guest@ArtGallery.bg", false, false, null, "GUEST@ARTGALLERY.BG", "GUEST@ARTGALLERY.BG", "AQAAAAEAACcQAAAAEKEhfn74r891if4Fhp7ww6AqM4YPOgGUpgH1giJtbyMNOe/QGuWz6UVC1heTsD8QMg==", null, false, "6428d057-f083-4960-a6d9-f4dc382497f7", false, "guest@ArtGallery.bg" },
                    { "d53a80c3-5fd9-4451-a381-f40d2f50ec08", 0, "161c3a08-8ab0-4aae-a083-bb9168723cdd", "admin@ArtGallery.bg", false, false, null, "ADMIN@ARTGALLERY.BG", "ADMIN@ARTGALLERY.BG", "AQAAAAEAACcQAAAAEEu304Gk+GOSJpb+6NDfBxAn2SpJgqIZ0KThDCOFGe83WOi3e54aE0O/DhDv7qpjvg==", null, false, "a788feae-9610-41bb-a8ac-2beab65b53c1", false, "admin@ArtGallery.bg" }
                });

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

            migrationBuilder.InsertData(
                table: "Exhibitions",
                columns: new[] { "Id", "Description", "End", "ImageUrl", "Name", "Place", "Start" },
                values: new object[] { 1, "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни.", new DateTime(2023, 7, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "\\lib\\images\\ExhibitionAfrica.jpg", "Изложба Африка", "Варна, Галерията на Петя", new DateTime(2023, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "CategoryId", "Description", "ImageAddress", "ImageBase", "Material", "Name", "Size" },
                values: new object[,]
                {
                    { 1, 2, "Африканско момиче с цвете в косата", "\\lib\\images\\Girl1.jpg", "Платно", "Акрил", "Момиче с цвете", "40 х 60" },
                    { 2, 2, "Африканско момиче със синя шапка", "\\lib\\images\\Girl2.jpg", "Платно", "Акрил", "Момиче със синя шапка", "40 х 60" },
                    { 3, 2, "Африканско момиче със оранжева шапка", "\\lib\\images\\Girl3.jpg", "Платно", "Акрил", "Момиче със оранжева шапка", "40 х 60" },
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

            migrationBuilder.CreateIndex(
                name: "IX_ArtEventParticipants_ArtEventId",
                table: "ArtEventParticipants",
                column: "ArtEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PictureId",
                table: "Comments",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersAPictures_UserId",
                table: "OrdersAPictures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CategoryId",
                table: "Pictures",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtEventParticipants");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "OrdersAPictures");

            migrationBuilder.DropTable(
                name: "ArtEvents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
