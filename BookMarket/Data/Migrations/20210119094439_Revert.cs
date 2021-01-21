using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofAddress",
                table: "SellApplicationDetails");

            migrationBuilder.DropColumn(
                name: "ProofId",
                table: "SellApplicationDetails");

            migrationBuilder.AddColumn<string>(
                name: "ProofAddress",
                table: "SellApplication",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProofId",
                table: "SellApplication",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofAddress",
                table: "SellApplication");

            migrationBuilder.DropColumn(
                name: "ProofId",
                table: "SellApplication");

            migrationBuilder.AddColumn<string>(
                name: "ProofAddress",
                table: "SellApplicationDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProofId",
                table: "SellApplicationDetails",
                nullable: false,
                defaultValue: "");
        }
    }
}
