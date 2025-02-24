using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MeetingPlacetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingPlaces",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PetTypes",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "MeetingPlaceType",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PetType",
                table: "Pets",
                newName: "AnimalTypeId");

            migrationBuilder.AddColumn<int>(
                name: "AnimalTypeId",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingPlaceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GooglePlaceId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
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
                name: "AnimalTypePost",
                columns: table => new
                {
                    AnimalTypesId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypePost", x => new { x.AnimalTypesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_AnimalTypePost_AnimalTypes_AnimalTypesId",
                        column: x => x.AnimalTypesId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalTypePost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
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
                table: "AnimalTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" }
                });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "10",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "100",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "101",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "102",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "103",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "104",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "105",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "106",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "107",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "108",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "109",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "11",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "110",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "111",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "112",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "113",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "114",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "115",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "116",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "117",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "118",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "119",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "12",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "120",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "121",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "122",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "123",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "124",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "125",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "126",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "127",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "128",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "129",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "13",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "130",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "131",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "132",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "133",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "134",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "135",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "136",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "137",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "138",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "139",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "14",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "140",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "141",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "142",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "143",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "144",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "145",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "146",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "147",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "148",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "149",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "15",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "150",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "151",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "152",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "153",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "154",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "155",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "156",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "157",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "158",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "159",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "16",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "160",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "161",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "162",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "163",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "164",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "165",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "166",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "167",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "168",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "169",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "17",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "170",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "171",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "172",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "173",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "174",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "175",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "176",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "177",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "178",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "179",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "18",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "180",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "181",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "182",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "183",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "184",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "185",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "186",
                column: "AnimalTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "19",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "20",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "21",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "22",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "23",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "24",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "25",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "26",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "27",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "28",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "29",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "3",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "30",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "31",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "32",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "33",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "34",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "35",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "36",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "37",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "38",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "39",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "40",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "41",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "42",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "43",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "44",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "45",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "46",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "47",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "48",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "49",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "50",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "51",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "52",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "53",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "54",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "55",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "56",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "57",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "58",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "59",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "60",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "61",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "62",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "63",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "64",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "65",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "66",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "67",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "68",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "69",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "70",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "71",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "72",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "73",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "74",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "75",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "76",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "77",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "78",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "79",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "80",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "81",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "82",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "83",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "84",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "85",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "86",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "87",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "88",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "89",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "90",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "91",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "92",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "93",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "94",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "95",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "96",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "97",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "98",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "99",
                column: "AnimalTypeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MeetingPlaceId",
                table: "Bookings",
                column: "MeetingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTypePost_PostsId",
                table: "AnimalTypePost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPlaceService_ServicesId",
                table: "MeetingPlaceService",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MeetingPlaces_MeetingPlaceId",
                table: "Bookings",
                column: "MeetingPlaceId",
                principalTable: "MeetingPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MeetingPlaces_MeetingPlaceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "AnimalTypePost");

            migrationBuilder.DropTable(
                name: "MeetingPlaceService");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "MeetingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MeetingPlaceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "GooglePlaceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "AnimalTypeId",
                table: "Pets",
                newName: "PetType");

            migrationBuilder.AddColumn<string>(
                name: "MeetingPlaces",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PetTypes",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PetType",
                table: "Breeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingPlaceId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MeetingPlaceType",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "1",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "10",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "100",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "101",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "102",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "103",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "104",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "105",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "106",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "107",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "108",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "109",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "11",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "110",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "111",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "112",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "113",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "114",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "115",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "116",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "117",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "118",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "119",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "12",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "120",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "121",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "122",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "123",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "124",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "125",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "126",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "127",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "128",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "129",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "13",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "130",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "131",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "132",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "133",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "134",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "135",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "136",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "137",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "138",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "139",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "14",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "140",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "141",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "142",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "143",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "144",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "145",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "146",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "147",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "148",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "149",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "15",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "150",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "151",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "152",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "153",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "154",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "155",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "156",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "157",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "158",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "159",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "16",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "160",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "161",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "162",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "163",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "164",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "165",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "166",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "167",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "168",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "169",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "17",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "170",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "171",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "172",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "173",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "174",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "175",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "176",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "177",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "178",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "179",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "18",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "180",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "181",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "182",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "183",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "184",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "185",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "186",
                column: "PetType",
                value: "Cat");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "19",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "20",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "21",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "22",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "23",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "24",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "25",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "26",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "27",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "28",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "29",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "3",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "30",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "31",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "32",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "33",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "34",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "35",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "36",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "37",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "38",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "39",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "40",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "41",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "42",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "43",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "44",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "45",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "46",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "47",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "48",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "49",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "50",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "51",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "52",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "53",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "54",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "55",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "56",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "57",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "58",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "59",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "60",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "61",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "62",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "63",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "64",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "65",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "66",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "67",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "68",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "69",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "70",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "71",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "72",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "73",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "74",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "75",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "76",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "77",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "78",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "79",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "80",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "81",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "82",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "83",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "84",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "85",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "86",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "87",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "88",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "89",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "90",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "91",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "92",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "93",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "94",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "95",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "96",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "97",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "98",
                column: "PetType",
                value: "Dog");

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "99",
                column: "PetType",
                value: "Dog");
        }
    }
}
