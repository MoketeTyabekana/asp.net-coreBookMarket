using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentApplication_AspNetUsers_UserId",
                table: "RentApplication");

            migrationBuilder.DropIndex(
                name: "IX_RentApplication_UserId",
                table: "RentApplication");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RentApplication");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RentApplication",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RentApplication_UserId",
                table: "RentApplication",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentApplication_AspNetUsers_UserId",
                table: "RentApplication",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
