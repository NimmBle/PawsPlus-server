using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoolandia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PetType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetType",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Pets");
        }
    }
}
