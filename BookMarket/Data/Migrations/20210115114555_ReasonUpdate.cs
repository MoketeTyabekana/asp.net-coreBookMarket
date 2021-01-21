using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class ReasonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "SellApplication");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "SellApplicationDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "SellApplicationDetails");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "SellApplication",
                nullable: true);
        }
    }
}
