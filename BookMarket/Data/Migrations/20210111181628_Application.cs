using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class Application : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "ApplicationDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProofId = table.Column<string>(nullable: false),
                    ProofAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationDetails_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "ApplicationDetails");
        }
    }
}
