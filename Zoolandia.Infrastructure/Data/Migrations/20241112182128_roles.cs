using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoolandia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09247778-70aa-4668-93c3-7d7e8e01b238", "09247778-70aa-4668-93c3-7d7e8e01b238", "Administrator", "ADMINISTRATOR" },
                    { "29781d47-7738-4588-9d69-98a9fc466477", "29781d47-7738-4588-9d69-98a9fc466477", "Sitter", "SITTER" },
                    { "6360401a-91de-4e52-858d-263b0999f0a0", "6360401a-91de-4e52-858d-263b0999f0a0", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ce87a78-7146-4702-be5a-5944e4592d50", 0, "130054d8-b926-4639-a65d-3425a6c5af5b", "User", "hristopanev20@gmail.com", true, false, null, "HRISTOPANEV20@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEBqkXGxRaEEeqb5f+sgzwxkwAz3oQsF3u2gKZxiA07clBiRXva702USiFfxqTsmoLA==", null, false, "1bf6766c-2193-44ed-b500-62b76d2369d1", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09247778-70aa-4668-93c3-7d7e8e01b238", "0ce87a78-7146-4702-be5a-5944e4592d50" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29781d47-7738-4588-9d69-98a9fc466477");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6360401a-91de-4e52-858d-263b0999f0a0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09247778-70aa-4668-93c3-7d7e8e01b238", "0ce87a78-7146-4702-be5a-5944e4592d50" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09247778-70aa-4668-93c3-7d7e8e01b238");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ce87a78-7146-4702-be5a-5944e4592d50");
        }
    }
}
