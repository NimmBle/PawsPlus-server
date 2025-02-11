using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seedbreedsandroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "Location_PlaceId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Point>(
                name: "Location_Point",
                table: "Profiles",
                type: "geometry",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "020ae868-c87b-429e-bf53-91a164c95bd2", "020ae868-c87b-429e-bf53-91a164c95bd2", "Owner", "OWNER" },
                    { "2b36e6fc-8886-4224-91bb-8b0cfc744627", "2b36e6fc-8886-4224-91bb-8b0cfc744627", "Sitter", "SITTER" },
                    { "ddd0a343-5d90-46cb-a020-7c2910d436e9", "ddd0a343-5d90-46cb-a020-7c2910d436e9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33896ccc-d260-415f-bbc1-8379ccf04c0e", 0, "ba416b33-d51a-403a-9496-3f9b8587bfba", "hristopanev20@gmail.com", true, false, null, "HRISTOPANEV20@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEG/vPoGvgalVLrMeU5FRRSvVUo/F0G074AUgbKWGbmNORr7CBeF0igt2h418Nn34FA==", null, false, null, "cf6c4666-82b2-4e46-85d1-c79a0ae4e58d", false, "admin" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name", "PetType" },
                values: new object[,]
                {
                    { "1", "Аффенпинчер", "Dog" },
                    { "10", "Американски булдог", "Dog" },
                    { "100", "Комондор", "Dog" },
                    { "101", "Койкер хондие", "Dog" },
                    { "102", "Кувас", "Dog" },
                    { "103", "Лабрадор ретрийвър", "Dog" },
                    { "104", "Лагото романьоло", "Dog" },
                    { "105", "Ланкашир хийлър", "Dog" },
                    { "106", "Леонбергер", "Dog" },
                    { "107", "Лхаса апсо", "Dog" },
                    { "108", "Малтийско болонезе", "Dog" },
                    { "109", "Миниатюрна американска овчарка", "Dog" },
                    { "11", "Американски були", "Dog" },
                    { "110", "Миниатюрен пинчер", "Dog" },
                    { "111", "Миниатюрен шнауцер", "Dog" },
                    { "112", "Нюфаундленд", "Dog" },
                    { "113", "Норфолк териер", "Dog" },
                    { "114", "Норич териер", "Dog" },
                    { "115", "Нова шотландска патица ретрийвър", "Dog" },
                    { "116", "Староанглийско овчарско куче", "Dog" },
                    { "117", "Староанглийски булдог", "Dog" },
                    { "118", "Папийон", "Dog" },
                    { "119", "Пекинез", "Dog" },
                    { "12", "Американско ескимоско куче", "Dog" },
                    { "120", "Уелско корги пембрук", "Dog" },
                    { "121", "Преса канарио", "Dog" },
                    { "122", "Фараонско куче", "Dog" },
                    { "123", "Плот хаунд", "Dog" },
                    { "124", "Померан", "Dog" },
                    { "125", "Пудел миниатюрен", "Dog" },
                    { "126", "Пудел той", "Dog" },
                    { "127", "Мопс", "Dog" },
                    { "128", "Пули", "Dog" },
                    { "129", "Пуми", "Dog" },
                    { "13", "Американска лисица", "Dog" },
                    { "130", "Рат териер", "Dog" },
                    { "131", "Редбоун кунхаунд", "Dog" },
                    { "132", "Родезийски риджбек", "Dog" },
                    { "133", "Ротвайлер", "Dog" },
                    { "134", "Руски той териер", "Dog" },
                    { "135", "Санбернар", "Dog" },
                    { "136", "Салуки", "Dog" },
                    { "137", "Самоед", "Dog" },
                    { "138", "Шиперке", "Dog" },
                    { "139", "Шотландска еленова хрътка", "Dog" },
                    { "14", "Американски питбул териер", "Dog" },
                    { "140", "Шотландски териер", "Dog" },
                    { "141", "Шетландско овчарско куче", "Dog" },
                    { "142", "Шиба ину", "Dog" },
                    { "143", "Ши Тцу", "Dog" },
                    { "144", "Шило пастирско куче", "Dog" },
                    { "145", "Сибирско хъски", "Dog" },
                    { "146", "Визла", "Dog" },
                    { "147", "Ваймаранер", "Dog" },
                    { "148", "Абисинска", "Cat" },
                    { "149", "Австралийска мъгла", "Cat" },
                    { "15", "Американски стафордширски териер", "Dog" },
                    { "150", "Азиатска", "Cat" },
                    { "151", "Американска грубокосместа", "Cat" },
                    { "152", "Балийска", "Cat" },
                    { "153", "Бенгалска", "Cat" },
                    { "154", "Бирманска", "Cat" },
                    { "155", "Британска късокосместа", "Cat" },
                    { "156", "Бурманска", "Cat" },
                    { "157", "Бурмила", "Cat" },
                    { "158", "Девон Рекс", "Cat" },
                    { "159", "Египетска Мау", "Cat" },
                    { "16", "Американски воден шпаньол", "Dog" },
                    { "160", "Европейска късокосместа", "Cat" },
                    { "161", "Канадски сфинкс", "Cat" },
                    { "162", "Корат", "Cat" },
                    { "163", "Корниш Рекс", "Cat" },
                    { "164", "Мейн Куун", "Cat" },
                    { "165", "Норвежка горска", "Cat" },
                    { "166", "Ориенталска късокосместа", "Cat" },
                    { "167", "Персийска", "Cat" },
                    { "168", "Петерболд", "Cat" },
                    { "169", "Пикси-боб", "Cat" },
                    { "17", "Анатолийско пастирско куче", "Dog" },
                    { "170", "Рагдол", "Cat" },
                    { "171", "Руска синя", "Cat" },
                    { "172", "Селкирк Рекс", "Cat" },
                    { "173", "Серенгети", "Cat" },
                    { "174", "Сиамска", "Cat" },
                    { "175", "Сибирска", "Cat" },
                    { "176", "Сингапурска", "Cat" },
                    { "177", "Сомалийска", "Cat" },
                    { "178", "Тайска", "Cat" },
                    { "179", "Тонкинска", "Cat" },
                    { "18", "Апенцелер зененхунд", "Dog" },
                    { "180", "Турска Ангора", "Cat" },
                    { "181", "Турски ван", "Cat" },
                    { "182", "Украински Левкой", "Cat" },
                    { "183", "Уралски Рекс", "Cat" },
                    { "184", "Шартрьо", "Cat" },
                    { "185", "Шотландска клепоуха", "Cat" },
                    { "186", "Японски бобтейл", "Cat" },
                    { "19", "Австралийско пастирско куче", "Dog" },
                    { "2", "Афганска хрътка", "Dog" },
                    { "20", "Австралийски келпи", "Dog" },
                    { "21", "Австралийска овчарка", "Dog" },
                    { "22", "Австралийски териер", "Dog" },
                    { "23", "Азавах", "Dog" },
                    { "24", "Барбе", "Dog" },
                    { "25", "Басенджи", "Dog" },
                    { "26", "Гасконски басет", "Dog" },
                    { "27", "Басет хрътка", "Dog" },
                    { "28", "Бийгъл", "Dog" },
                    { "29", "Брадато коли", "Dog" },
                    { "3", "Африканско ловно куче", "Dog" },
                    { "30", "Босерон", "Dog" },
                    { "31", "Бедлингтон териер", "Dog" },
                    { "32", "Белгийски малиноа", "Dog" },
                    { "33", "Белгийски тервюрен", "Dog" },
                    { "34", "Бернско планинско куче", "Dog" },
                    { "35", "Бишон фризе", "Dog" },
                    { "36", "Черно-тан кунхаунд", "Dog" },
                    { "37", "Блъдхаунд", "Dog" },
                    { "38", "Блутик кунхаунд", "Dog" },
                    { "39", "Бурбул", "Dog" },
                    { "4", "Еърдейл териер", "Dog" },
                    { "40", "Бордър коли", "Dog" },
                    { "41", "Бордър териер", "Dog" },
                    { "42", "Бостън териер", "Dog" },
                    { "43", "Бувие де Фландр", "Dog" },
                    { "44", "Боксер", "Dog" },
                    { "45", "Бойкин шпаньол", "Dog" },
                    { "46", "Брако Италиано", "Dog" },
                    { "47", "Бриар", "Dog" },
                    { "48", "Бретонски епаньол", "Dog" },
                    { "49", "Бул териер", "Dog" },
                    { "5", "Акбаш куче", "Dog" },
                    { "50", "Бул мастиф", "Dog" },
                    { "51", "Керн териер", "Dog" },
                    { "52", "Кане корсо", "Dog" },
                    { "53", "Уелско корги кардиган", "Dog" },
                    { "54", "Куче леопард от Катахула", "Dog" },
                    { "55", "Кавказка овчарка", "Dog" },
                    { "56", "Кавалер Кинг Чарлз шпаньол", "Dog" },
                    { "57", "Чесапийк бей ретрийвър", "Dog" },
                    { "58", "Китайско голо качулато куче", "Dog" },
                    { "59", "Китайски шарпей", "Dog" },
                    { "6", "Акита", "Dog" },
                    { "60", "Чинук", "Dog" },
                    { "61", "Чау Чау", "Dog" },
                    { "62", "Кламбър шпаньол", "Dog" },
                    { "63", "Кокер шпаньол", "Dog" },
                    { "64", "Американски кокер шпаньол", "Dog" },
                    { "65", "Котон де тулеар", "Dog" },
                    { "66", "Далматинец", "Dog" },
                    { "67", "Доберман", "Dog" },
                    { "68", "Дого Аржентино", "Dog" },
                    { "69", "Холандско пастирско куче", "Dog" },
                    { "7", "Алапахски булдог", "Dog" },
                    { "70", "Английски сетер", "Dog" },
                    { "71", "Английско пастирско куче", "Dog" },
                    { "72", "Английски спрингер шпаньол", "Dog" },
                    { "73", "Английски той шпаньол", "Dog" },
                    { "74", "Английски териер", "Dog" },
                    { "75", "Евразиец", "Dog" },
                    { "76", "Полски шпаньол", "Dog" },
                    { "77", "Финландско лапландско куче", "Dog" },
                    { "78", "Финландски шпиц", "Dog" },
                    { "79", "Френски булдог", "Dog" },
                    { "8", "Аляски хъски", "Dog" },
                    { "80", "Немски пинчер", "Dog" },
                    { "81", "Немска овчарка", "Dog" },
                    { "82", "Немски късокосмест пойнтер", "Dog" },
                    { "83", "Гигантски шнауцер", "Dog" },
                    { "84", "Глен ъф Имаал териер", "Dog" },
                    { "85", "Голдън ретрийвър", "Dog" },
                    { "86", "Гордън сетер", "Dog" },
                    { "87", "Немски мастиф", "Dog" },
                    { "88", "Пиренейска планинска овчарка", "Dog" },
                    { "89", "Грейхаунд", "Dog" },
                    { "9", "Аляски маламут", "Dog" },
                    { "90", "Грифон брюкселуа", "Dog" },
                    { "91", "Харие", "Dog" },
                    { "92", "Хаванез", "Dog" },
                    { "93", "Ирландски сетер", "Dog" },
                    { "94", "Ирландски териер", "Dog" },
                    { "95", "Ирландски вълкодав", "Dog" },
                    { "96", "Италиански грейхаунд", "Dog" },
                    { "97", "Японски чин", "Dog" },
                    { "98", "Японски шпиц", "Dog" },
                    { "99", "Кеесхонд", "Dog" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ddd0a343-5d90-46cb-a020-7c2910d436e9", "33896ccc-d260-415f-bbc1-8379ccf04c0e" });

            migrationBuilder.CreateIndex(
                name: "IX_BreedPet_PetsId",
                table: "BreedPet",
                column: "PetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BreedPet");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020ae868-c87b-429e-bf53-91a164c95bd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b36e6fc-8886-4224-91bb-8b0cfc744627");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ddd0a343-5d90-46cb-a020-7c2910d436e9", "33896ccc-d260-415f-bbc1-8379ccf04c0e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd0a343-5d90-46cb-a020-7c2910d436e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33896ccc-d260-415f-bbc1-8379ccf04c0e");

            migrationBuilder.DropColumn(
                name: "Location_PlaceId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Location_Point",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
