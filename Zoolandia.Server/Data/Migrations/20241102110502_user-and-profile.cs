using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoolandia.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class userandprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profile_Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_PhotoUrl",
                table: "AspNetUsers");
        }
    }
}
