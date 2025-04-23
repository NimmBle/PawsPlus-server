using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Review_Reviewed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_ReviewedPostId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewedPostId",
                table: "Reviews",
                newName: "ReviewedId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewedPostId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewedId");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReviewDate",
                table: "Reviews",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PostId",
                table: "Reviews",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Profiles_ReviewedId",
                table: "Reviews",
                column: "ReviewedId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Posts_PostId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Profiles_ReviewedId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PostId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewedId",
                table: "Reviews",
                newName: "ReviewedPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewedId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewedPostId");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Posts_ReviewedPostId",
                table: "Reviews",
                column: "ReviewedPostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
