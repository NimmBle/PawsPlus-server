using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTypetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetTypes",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Breeds");

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

            migrationBuilder.AddColumn<int>(
                name: "AnimalTypeId1",
                table: "Breeds",
                type: "int",
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
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "104",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "105",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "106",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "107",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "108",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "109",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "110",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "111",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "112",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "113",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "114",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "115",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "116",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "117",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "118",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "119",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "120",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "121",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "122",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "123",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "124",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "125",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "126",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "127",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "128",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "129",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "130",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "131",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "132",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "133",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "134",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "135",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "136",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "137",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "138",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "139",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "140",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "141",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "142",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "143",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "144",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "145",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "146",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "147",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "148",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "149",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "15",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "150",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "151",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "152",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "153",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "154",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "155",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "156",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "157",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "158",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "159",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "16",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "160",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "161",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "162",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "163",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "164",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "165",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "166",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "167",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "168",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "169",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "17",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "170",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "171",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "172",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "173",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "174",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "175",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "176",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "177",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "178",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "179",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "18",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "180",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "181",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "182",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "183",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "184",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "185",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "186",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "20",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "21",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "22",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "23",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "24",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "25",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "26",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "27",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "28",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "29",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "30",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "31",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "32",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "33",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "34",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "35",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "36",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "37",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "38",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "39",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "40",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "41",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "42",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "43",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "44",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "45",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "46",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "47",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "48",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "49",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "50",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "51",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "52",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "53",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "54",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "55",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "56",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "57",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "58",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "59",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "60",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "61",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "62",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "63",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "64",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "65",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "66",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "67",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "68",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "69",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "70",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "71",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "72",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "73",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "74",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "75",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "76",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "77",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "78",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "79",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "80",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "81",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "82",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "83",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "84",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "85",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "86",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "87",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "88",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "89",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "90",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "91",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "92",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "93",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "94",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "95",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "96",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "97",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "98",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: "99",
                columns: new[] { "AnimalTypeId", "AnimalTypeId1" },
                values: new object[] { 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalTypeId1",
                table: "Breeds",
                column: "AnimalTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTypePost_PostsId",
                table: "AnimalTypePost",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId1",
                table: "Breeds",
                column: "AnimalTypeId1",
                principalTable: "AnimalTypes",
                principalColumn: "Id");

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
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId1",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "AnimalTypePost");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_AnimalTypeId1",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "AnimalTypeId1",
                table: "Breeds");

            migrationBuilder.RenameColumn(
                name: "AnimalTypeId",
                table: "Pets",
                newName: "PetType");

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
