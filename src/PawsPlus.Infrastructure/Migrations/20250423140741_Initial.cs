using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

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
                name: "Dates",
                columns: table => new
                {
                    Day = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Day);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    Location_PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Point = table.Column<Point>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Animals_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status_Value = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    YearsOld = table.Column<int>(type: "int", nullable: true),
                    MonthsOld = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WeightId = table.Column<int>(type: "int", nullable: true),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrained = table.Column<int>(type: "int", nullable: true),
                    HasFears = table.Column<int>(type: "int", nullable: true),
                    FearsDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsVaccinated = table.Column<bool>(type: "bit", nullable: true),
                    IsCastrated = table.Column<bool>(type: "bit", nullable: true),
                    TakesMedications = table.Column<bool>(type: "bit", nullable: true),
                    HasEatingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDietaryNeeds = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    HealthProblems = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Weights_WeightId",
                        column: x => x.WeightId,
                        principalTable: "Weights",
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AnimalPost",
                columns: table => new
                {
                    AnimalsId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPost", x => new { x.AnimalsId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_AnimalPost_Animals_AnimalsId",
                        column: x => x.AnimalsId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalPost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostWeight",
                columns: table => new
                {
                    PostsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeightsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostWeight", x => new { x.PostsId, x.WeightsId });
                    table.ForeignKey(
                        name: "FK_PostWeight_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostWeight_Weights_WeightsId",
                        column: x => x.WeightsId,
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReviewedPostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Posts_ReviewedPostId",
                        column: x => x.ReviewedPostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Profiles_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedPet",
                columns: table => new
                {
                    BreedsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PetsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedPet", x => new { x.BreedsId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_BreedPet_Breeds_BreedsId",
                        column: x => x.BreedsId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedPet_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDay = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDay = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingPlaceId = table.Column<int>(type: "int", nullable: false),
                    GooglePlaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Status_Value = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SitterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_MeetingPlaces_MeetingPlaceId",
                        column: x => x.MeetingPlaceId,
                        principalTable: "MeetingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Profiles_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Profiles_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateService",
                columns: table => new
                {
                    AvailableDatesDay = table.Column<DateOnly>(type: "date", nullable: false),
                    ServicesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateService", x => new { x.AvailableDatesDay, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_DateService_Dates_AvailableDatesDay",
                        column: x => x.AvailableDatesDay,
                        principalTable: "Dates",
                        principalColumn: "Day",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPlaceService",
                columns: table => new
                {
                    MeetingPlacesId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPlaceService", x => new { x.MeetingPlacesId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_MeetingPlaceService_MeetingPlaces_MeetingPlacesId",
                        column: x => x.MeetingPlacesId,
                        principalTable: "MeetingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingPlaceService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" }
                });

            migrationBuilder.InsertData(
                table: "MeetingPlaces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AtOwners" },
                    { 2, "AtSitters" },
                    { 3, "Another" }
                });

            migrationBuilder.InsertData(
                table: "Weights",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SmallToMedium" },
                    { 2, "Medium" },
                    { 3, "MediumToLarge" },
                    { 4, "Large" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "AnimalTypeId", "Name" },
                values: new object[,]
                {
                    { "1", 1, "Аффенпинчер" },
                    { "10", 1, "Американски булдог" },
                    { "100", 1, "Комондор" },
                    { "101", 1, "Койкер хондие" },
                    { "102", 1, "Кувас" },
                    { "103", 1, "Лабрадор ретрийвър" },
                    { "104", 1, "Лагото романьоло" },
                    { "105", 1, "Ланкашир хийлър" },
                    { "106", 1, "Леонбергер" },
                    { "107", 1, "Лхаса апсо" },
                    { "108", 1, "Малтийско болонезе" },
                    { "109", 1, "Миниатюрна американска овчарка" },
                    { "11", 1, "Американски були" },
                    { "110", 1, "Миниатюрен пинчер" },
                    { "111", 1, "Миниатюрен шнауцер" },
                    { "112", 1, "Нюфаундленд" },
                    { "113", 1, "Норфолк териер" },
                    { "114", 1, "Норич териер" },
                    { "115", 1, "Нова шотландска патица ретрийвър" },
                    { "116", 1, "Староанглийско овчарско куче" },
                    { "117", 1, "Староанглийски булдог" },
                    { "118", 1, "Папийон" },
                    { "119", 1, "Пекинез" },
                    { "12", 1, "Американско ескимоско куче" },
                    { "120", 1, "Уелско корги пембрук" },
                    { "121", 1, "Преса канарио" },
                    { "122", 1, "Фараонско куче" },
                    { "123", 1, "Плот хаунд" },
                    { "124", 1, "Померан" },
                    { "125", 1, "Пудел миниатюрен" },
                    { "126", 1, "Пудел той" },
                    { "127", 1, "Мопс" },
                    { "128", 1, "Пули" },
                    { "129", 1, "Пуми" },
                    { "13", 1, "Американска лисица" },
                    { "130", 1, "Рат териер" },
                    { "131", 1, "Редбоун кунхаунд" },
                    { "132", 1, "Родезийски риджбек" },
                    { "133", 1, "Ротвайлер" },
                    { "134", 1, "Руски той териер" },
                    { "135", 1, "Санбернар" },
                    { "136", 1, "Салуки" },
                    { "137", 1, "Самоед" },
                    { "138", 1, "Шиперке" },
                    { "139", 1, "Шотландска еленова хрътка" },
                    { "14", 1, "Американски питбул териер" },
                    { "140", 1, "Шотландски териер" },
                    { "141", 1, "Шетландско овчарско куче" },
                    { "142", 1, "Шиба ину" },
                    { "143", 1, "Ши Тцу" },
                    { "144", 1, "Шило пастирско куче" },
                    { "145", 1, "Сибирско хъски" },
                    { "146", 1, "Визла" },
                    { "147", 1, "Ваймаранер" },
                    { "148", 2, "Абисинска" },
                    { "149", 2, "Австралийска мъгла" },
                    { "15", 1, "Американски стафордширски териер" },
                    { "150", 2, "Азиатска" },
                    { "151", 2, "Американска грубокосместа" },
                    { "152", 2, "Балийска" },
                    { "153", 2, "Бенгалска" },
                    { "154", 2, "Бирманска" },
                    { "155", 2, "Британска късокосместа" },
                    { "156", 2, "Бурманска" },
                    { "157", 2, "Бурмила" },
                    { "158", 2, "Девон Рекс" },
                    { "159", 2, "Египетска Мау" },
                    { "16", 1, "Американски воден шпаньол" },
                    { "160", 2, "Европейска късокосместа" },
                    { "161", 2, "Канадски сфинкс" },
                    { "162", 2, "Корат" },
                    { "163", 2, "Корниш Рекс" },
                    { "164", 2, "Мейн Куун" },
                    { "165", 2, "Норвежка горска" },
                    { "166", 2, "Ориенталска късокосместа" },
                    { "167", 2, "Персийска" },
                    { "168", 2, "Петерболд" },
                    { "169", 2, "Пикси-боб" },
                    { "17", 1, "Анатолийско пастирско куче" },
                    { "170", 2, "Рагдол" },
                    { "171", 2, "Руска синя" },
                    { "172", 2, "Селкирк Рекс" },
                    { "173", 2, "Серенгети" },
                    { "174", 2, "Сиамска" },
                    { "175", 2, "Сибирска" },
                    { "176", 2, "Сингапурска" },
                    { "177", 2, "Сомалийска" },
                    { "178", 2, "Тайска" },
                    { "179", 2, "Тонкинска" },
                    { "18", 1, "Апенцелер зененхунд" },
                    { "180", 2, "Турска Ангора" },
                    { "181", 2, "Турски ван" },
                    { "182", 2, "Украински Левкой" },
                    { "183", 2, "Уралски Рекс" },
                    { "184", 2, "Шартрьо" },
                    { "185", 2, "Шотландска клепоуха" },
                    { "186", 2, "Японски бобтейл" },
                    { "19", 1, "Австралийско пастирско куче" },
                    { "2", 1, "Афганска хрътка" },
                    { "20", 1, "Австралийски келпи" },
                    { "21", 1, "Австралийска овчарка" },
                    { "22", 1, "Австралийски териер" },
                    { "23", 1, "Азавах" },
                    { "24", 1, "Барбе" },
                    { "25", 1, "Басенджи" },
                    { "26", 1, "Гасконски басет" },
                    { "27", 1, "Басет хрътка" },
                    { "28", 1, "Бийгъл" },
                    { "29", 1, "Брадато коли" },
                    { "3", 1, "Африканско ловно куче" },
                    { "30", 1, "Босерон" },
                    { "31", 1, "Бедлингтон териер" },
                    { "32", 1, "Белгийски малиноа" },
                    { "33", 1, "Белгийски тервюрен" },
                    { "34", 1, "Бернско планинско куче" },
                    { "35", 1, "Бишон фризе" },
                    { "36", 1, "Черно-тан кунхаунд" },
                    { "37", 1, "Блъдхаунд" },
                    { "38", 1, "Блутик кунхаунд" },
                    { "39", 1, "Бурбул" },
                    { "4", 1, "Еърдейл териер" },
                    { "40", 1, "Бордър коли" },
                    { "41", 1, "Бордър териер" },
                    { "42", 1, "Бостън териер" },
                    { "43", 1, "Бувие де Фландр" },
                    { "44", 1, "Боксер" },
                    { "45", 1, "Бойкин шпаньол" },
                    { "46", 1, "Брако Италиано" },
                    { "47", 1, "Бриар" },
                    { "48", 1, "Бретонски епаньол" },
                    { "49", 1, "Бул териер" },
                    { "5", 1, "Акбаш куче" },
                    { "50", 1, "Бул мастиф" },
                    { "51", 1, "Керн териер" },
                    { "52", 1, "Кане корсо" },
                    { "53", 1, "Уелско корги кардиган" },
                    { "54", 1, "Куче леопард от Катахула" },
                    { "55", 1, "Кавказка овчарка" },
                    { "56", 1, "Кавалер Кинг Чарлз шпаньол" },
                    { "57", 1, "Чесапийк бей ретрийвър" },
                    { "58", 1, "Китайско голо качулато куче" },
                    { "59", 1, "Китайски шарпей" },
                    { "6", 1, "Акита" },
                    { "60", 1, "Чинук" },
                    { "61", 1, "Чау Чау" },
                    { "62", 1, "Кламбър шпаньол" },
                    { "63", 1, "Кокер шпаньол" },
                    { "64", 1, "Американски кокер шпаньол" },
                    { "65", 1, "Котон де тулеар" },
                    { "66", 1, "Далматинец" },
                    { "67", 1, "Доберман" },
                    { "68", 1, "Дого Аржентино" },
                    { "69", 1, "Холандско пастирско куче" },
                    { "7", 1, "Алапахски булдог" },
                    { "70", 1, "Английски сетер" },
                    { "71", 1, "Английско пастирско куче" },
                    { "72", 1, "Английски спрингер шпаньол" },
                    { "73", 1, "Английски той шпаньол" },
                    { "74", 1, "Английски териер" },
                    { "75", 1, "Евразиец" },
                    { "76", 1, "Полски шпаньол" },
                    { "77", 1, "Финландско лапландско куче" },
                    { "78", 1, "Финландски шпиц" },
                    { "79", 1, "Френски булдог" },
                    { "8", 1, "Аляски хъски" },
                    { "80", 1, "Немски пинчер" },
                    { "81", 1, "Немска овчарка" },
                    { "82", 1, "Немски късокосмест пойнтер" },
                    { "83", 1, "Гигантски шнауцер" },
                    { "84", 1, "Глен ъф Имаал териер" },
                    { "85", 1, "Голдън ретрийвър" },
                    { "86", 1, "Гордън сетер" },
                    { "87", 1, "Немски мастиф" },
                    { "88", 1, "Пиренейска планинска овчарка" },
                    { "89", 1, "Грейхаунд" },
                    { "9", 1, "Аляски маламут" },
                    { "90", 1, "Грифон брюкселуа" },
                    { "91", 1, "Харие" },
                    { "92", 1, "Хаванез" },
                    { "93", 1, "Ирландски сетер" },
                    { "94", 1, "Ирландски териер" },
                    { "95", 1, "Ирландски вълкодав" },
                    { "96", 1, "Италиански грейхаунд" },
                    { "97", 1, "Японски чин" },
                    { "98", 1, "Японски шпиц" },
                    { "99", 1, "Кеесхонд" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalPost_PostsId",
                table: "AnimalPost",
                column: "PostsId");

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
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MeetingPlaceId",
                table: "Bookings",
                column: "MeetingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OwnerId",
                table: "Bookings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SitterId",
                table: "Bookings",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedPet_PetsId",
                table: "BreedPet",
                column: "PetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DateService_ServicesId",
                table: "DateService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPlaceService_ServicesId",
                table: "MeetingPlaceService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalId",
                table: "Pets",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ProfileId",
                table: "Pets",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_WeightId",
                table: "Pets",
                column: "WeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostWeight_WeightsId",
                table: "PostWeight",
                column: "WeightsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedPostId",
                table: "Reviews",
                column: "ReviewedPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PostId",
                table: "Services",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPost");

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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BreedPet");

            migrationBuilder.DropTable(
                name: "DateService");

            migrationBuilder.DropTable(
                name: "MeetingPlaceService");

            migrationBuilder.DropTable(
                name: "PostWeight");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "MeetingPlaces");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
