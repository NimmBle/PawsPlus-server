using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookingstartandendTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToTime",
                table: "Bookings",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "ToDay",
                table: "Bookings",
                newName: "StartDay");

            migrationBuilder.RenameColumn(
                name: "FromTime",
                table: "Bookings",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "FromDay",
                table: "Bookings",
                newName: "EndDay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookings",
                newName: "ToTime");

            migrationBuilder.RenameColumn(
                name: "StartDay",
                table: "Bookings",
                newName: "ToDay");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Bookings",
                newName: "FromTime");

            migrationBuilder.RenameColumn(
                name: "EndDay",
                table: "Bookings",
                newName: "FromDay");
        }
    }
}
