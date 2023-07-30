﻿// <auto-generated />
using System;
using ArtGallery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    [DbContext(typeof(ArtGalleryDbContext))]
    [Migration("20230730071038_addUserIdInTableOrderAPicture")]
    partial class addUserIdInTableOrderAPicture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtGallery.Data.Models.ArtEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Описание на обучението");

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Адреса на изображението");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Име на обучението");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Мястото на обучението");

                    b.Property<DateTime>("Start")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 30, 7, 10, 38, 430, DateTimeKind.Utc).AddTicks(6351))
                        .HasComment("Начало на обучението");

                    b.HasKey("Id");

                    b.ToTable("ArtEvents");

                    b.HasComment("Обучение");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
                            ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                            Name = "Розовото дърво",
                            Place = "Варна, Галерията на Петя",
                            Start = new DateTime(2023, 7, 26, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
                            ImageAddress = "\\lib\\images\\ArtEventCatWithCoffee.jpg",
                            Name = "Коте с кафе",
                            Place = "Варна, Галерията на Петя",
                            Start = new DateTime(2023, 7, 27, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
                            ImageAddress = "\\lib\\images\\ArtEventDogWithBrush.jpg",
                            Name = "Куче художник",
                            Place = "Варна, Галерията на Петя",
                            Start = new DateTime(2023, 7, 28, 17, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ArtGallery.Data.Models.ArtEventParticipant", b =>
                {
                    b.Property<string>("ParticipantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ArtEventId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "ArtEventId");

                    b.HasIndex("ArtEventId");

                    b.ToTable("ArtEventParticipants");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор на категорията");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Име на категория на картината");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Категория");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Животни"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Хора"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Къщи"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Пейзаж"
                        });
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор на коментара");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Съдържание на коментара");

                    b.Property<int>("PictureId")
                        .HasColumnType("int")
                        .HasComment("Идентификатор на картината");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Име на коментиращият");

                    b.HasKey("CommentId");

                    b.HasIndex("PictureId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Exhibition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Описание на изложбата");

                    b.Property<DateTime>("End")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(2046))
                        .HasComment("Край на изложбата");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Адреса на изображинието");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Име на изложбата");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Мястото на изложбата");

                    b.Property<DateTime>("Start")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 7, 30, 7, 10, 38, 431, DateTimeKind.Utc).AddTicks(1793))
                        .HasComment("Начало на изложбата");

                    b.HasKey("Id");

                    b.ToTable("Exhibitions");

                    b.HasComment("Изложба");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни.",
                            End = new DateTime(2023, 7, 30, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "\\lib\\images\\ExhibitionAfrica.jpg",
                            Name = "Изложба Африка",
                            Place = "Варна, Галерията на Петя",
                            Start = new DateTime(2023, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ArtGallery.Data.Models.OrderAPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Допълнителни желания към картината");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Име на заявка");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Вашите имена");

                    b.Property<string>("ImageBase")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Върху какво желаете да бъде нарисувана картината");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasComment("Добавете изображението");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("С каква боя желаете да бъде нарисувана картината");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Вашият телефонен номер");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Желаният размер на картината");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Идентификатор на потребителя");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("OrdersAPictures");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Идентификатор на категорията");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Дата на създаване на картината");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Описание на картината");

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)")
                        .HasComment("Адреса на изображението");

                    b.Property<string>("ImageBase")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Върху какво е нарисувана картината");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("С какво е нарисувана картината");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Име на картината");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Размер на картината");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pictures");

                    b.HasComment("Картинa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Африканско момиче с цвете в косата",
                            ImageAddress = "\\lib\\images\\Girl1.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Момиче с цвете",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Африканско момиче със синя шапка",
                            ImageAddress = "\\lib\\images\\Girl2.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Момиче със синя шапка",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Африканско момиче със оранжева шапка",
                            ImageAddress = "\\lib\\images\\Girl3.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Момиче със оранжева шапка",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Портрет на кон",
                            ImageAddress = "\\lib\\images\\Animal1.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Конче",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Портрет на царя на животните",
                            ImageAddress = "\\lib\\images\\Animal2.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Лъв",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Портрет на тигър",
                            ImageAddress = "\\lib\\images\\Animal3.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Тигър",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Три шарени къщички",
                            ImageAddress = "\\lib\\images\\House1.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Три шарени къщички",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Шарени къщички на дърво",
                            ImageAddress = "\\lib\\images\\House2.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Шарени къщички на дърво",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Шарени къщички на колела",
                            ImageAddress = "\\lib\\images\\House3.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Шарени къщички на колела",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Розово дърво",
                            ImageAddress = "\\lib\\images\\Nature1.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Розово дърво",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Розово дърво на скала",
                            ImageAddress = "\\lib\\images\\Nature2.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Розово дърво на скала",
                            Size = "40 х 60"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Бурно море",
                            ImageAddress = "\\lib\\images\\Nature3.jpg",
                            ImageBase = "Платно",
                            Material = "Акрил",
                            Name = "Бурно море",
                            Size = "40 х 60"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "33093f3e-7375-4ede-b645-3013eb36e355",
                            Email = "admin@ArtGallery.bg",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ARTGALLERY.BG",
                            NormalizedUserName = "ADMIN@ARTGALLERY.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEHGX1C5xX4tCESUWfYk9G/7n9gaeYoSjuNbO2FuLBWCRp/A9anAvK1d310YH0hVHVw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9008cabf-3b5a-4c91-b643-56143f665b1b",
                            TwoFactorEnabled = false,
                            UserName = "admin@ArtGallery.bg"
                        },
                        new
                        {
                            Id = "c1f40236-ee63-452f-8c56-18f952098074",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "18e81716-9f22-4db9-8fef-1e6cee0f1325",
                            Email = "guest@ArtGallery.bg",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@ARTGALLERY.BG",
                            NormalizedUserName = "GUEST@ARTGALLERY.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEDzn370UUEolWocyw6RE0grgG3uhRN4L1i0zx6wTvcYPM5BjRBlXprGH537Ph0Y7eQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d62f880c-95bf-4be8-991b-c616f88d16ef",
                            TwoFactorEnabled = false,
                            UserName = "guest@ArtGallery.bg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ArtGallery.Data.Models.ArtEventParticipant", b =>
                {
                    b.HasOne("ArtGallery.Data.Models.ArtEvent", "ArtEvent")
                        .WithMany("ArtEventParticipants")
                        .HasForeignKey("ArtEventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ArtEvent");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Comment", b =>
                {
                    b.HasOne("ArtGallery.Data.Models.Picture", "Picture")
                        .WithMany("PictureComments")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.OrderAPicture", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Picture", b =>
                {
                    b.HasOne("ArtGallery.Data.Models.Category", "Category")
                        .WithMany("Pictures")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtGallery.Data.Models.ArtEvent", b =>
                {
                    b.Navigation("ArtEventParticipants");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Category", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("ArtGallery.Data.Models.Picture", b =>
                {
                    b.Navigation("PictureComments");
                });
#pragma warning restore 612, 618
        }
    }
}
