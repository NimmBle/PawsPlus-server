using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoolandia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b0ba5be-58ef-42f2-81e9-f4d33ce0cf0d", "2b0ba5be-58ef-42f2-81e9-f4d33ce0cf0d", "Owner", "OWNER" },
                    { "93b03a5b-a8a2-4b60-b45d-001ba14fb272", "93b03a5b-a8a2-4b60-b45d-001ba14fb272", "Administrator", "ADMINISTRATOR" },
                    { "bef80b50-fec5-4b8d-bf9d-0c8a01d098d6", "bef80b50-fec5-4b8d-bf9d-0c8a01d098d6", "Sitter", "SITTER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd8d3521-b974-49e3-aa19-3ee62626aa8c", 0, "5818ccc8-5063-4d5b-8717-3b4f162bdf0d", "User", "hristopanev20@gmail.com", true, false, null, "HRISTOPANEV20@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEC9OTxyhJU/eZfbsZs4Jq3tJB6qppop8TfhcCmcYR6v4s49AaZWqqOpdCv1e6q482Q==", null, false, "7f111ac8-311a-4348-977c-8a082f3f7068", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bef80b50-fec5-4b8d-bf9d-0c8a01d098d6", "cd8d3521-b974-49e3-aa19-3ee62626aa8c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0ba5be-58ef-42f2-81e9-f4d33ce0cf0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93b03a5b-a8a2-4b60-b45d-001ba14fb272");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bef80b50-fec5-4b8d-bf9d-0c8a01d098d6", "cd8d3521-b974-49e3-aa19-3ee62626aa8c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bef80b50-fec5-4b8d-bf9d-0c8a01d098d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd8d3521-b974-49e3-aa19-3ee62626aa8c");
        }
    }
}
