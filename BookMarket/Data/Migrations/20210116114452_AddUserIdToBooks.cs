using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class AddUserIdToBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MyBooks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MyBooks_UserId",
                table: "MyBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyBooks_AspNetUsers_UserId",
                table: "MyBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyBooks_AspNetUsers_UserId",
                table: "MyBooks");

            migrationBuilder.DropIndex(
                name: "IX_MyBooks_UserId",
                table: "MyBooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MyBooks");
        }
    }
}
