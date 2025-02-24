using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class availabledatestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AnimalTypes_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "AnimalTypePost");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropColumn(
                name: "AvailableDates",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "AnimalTypeId",
                table: "Pets",
                newName: "AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AnimalTypeId",
                table: "Pets",
                newName: "IX_Pets_AnimalId");

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

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalPost_PostsId",
                table: "AnimalPost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_DateService_ServicesId",
                table: "DateService",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Animals_AnimalTypeId",
                table: "Breeds",
                column: "AnimalTypeId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Animals_AnimalId",
                table: "Pets",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Animals_AnimalTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Animals_AnimalId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "AnimalPost");

            migrationBuilder.DropTable(
                name: "DateService");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Pets",
                newName: "AnimalTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AnimalId",
                table: "Pets",
                newName: "IX_Pets_AnimalTypeId");

            migrationBuilder.AddColumn<string>(
                name: "AvailableDates",
                table: "Services",
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
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
