using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class addProofsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellApplications");

            migrationBuilder.AddColumn<string>(
                name: "ProofOfAddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProofOfID",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofOfAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProofOfID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "SellApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProofOfAddress = table.Column<string>(nullable: false),
                    ProofOfID = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellApplications_UserId",
                table: "SellApplications",
                column: "UserId");
        }
    }
}
