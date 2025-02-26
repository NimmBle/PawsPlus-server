using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsPlus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class weightstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weights",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Pets",
                newName: "WeightId");

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostWeight",
                columns: table => new
                {
                    PostsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeightsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostWeight", x => new { x.PostsId, x.WeightsId });
                    table.ForeignKey(
                        name: "FK_PostWeight_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostWeight_Weights_WeightsId",
                        column: x => x.WeightsId,
                        principalTable: "Weights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_WeightId",
                table: "Pets",
                column: "WeightId");

            migrationBuilder.CreateIndex(
                name: "IX_PostWeight_WeightsId",
                table: "PostWeight",
                column: "WeightsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Weights_WeightId",
                table: "Pets",
                column: "WeightId",
                principalTable: "Weights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Weights_WeightId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "PostWeight");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropIndex(
                name: "IX_Pets_WeightId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "WeightId",
                table: "Pets",
                newName: "Weight");

            migrationBuilder.AddColumn<string>(
                name: "Weights",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
