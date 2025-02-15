using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ServicemeetingPlaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeetingPlaces",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingPlaces",
                table: "Services");
        }
    }
}
