using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoolandia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedtypoinPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherDiateryNeeds",
                table: "Pets",
                newName: "OtherDietaryNeeds");

            migrationBuilder.AlterColumn<int>(
                name: "YearsOld",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MonthsOld",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherDietaryNeeds",
                table: "Pets",
                newName: "OtherDiateryNeeds");

            migrationBuilder.AlterColumn<int>(
                name: "YearsOld",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthsOld",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
