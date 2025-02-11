using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Breed",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FearsDescription",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasEatingSchedule",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HasFears",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthProblems",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCastrated",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsTrained",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVaccinated",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsOld",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherDiateryNeeds",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TakesMedications",
                table: "Pets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperament",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOld",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "FearsDescription",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HasEatingSchedule",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HasFears",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HealthProblems",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsCastrated",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsVaccinated",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MonthsOld",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OtherDiateryNeeds",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "TakesMedications",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Temperament",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "YearsOld",
                table: "Pets");
        }
    }
}
