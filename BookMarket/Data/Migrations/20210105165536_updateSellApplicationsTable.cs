using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class updateSellApplicationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SellApplications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SellApplications");

            migrationBuilder.DropColumn(
                name: "ProofOfAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProofOfID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "SellApplications",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SellApplications",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_SellApplications_UserId",
                table: "SellApplications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellApplications_AspNetUsers_UserId",
                table: "SellApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellApplications_AspNetUsers_UserId",
                table: "SellApplications");

            migrationBuilder.DropIndex(
                name: "IX_SellApplications_UserId",
                table: "SellApplications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SellApplications",
                newName: "Surname");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "SellApplications",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SellApplications",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SellApplications",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProofOfAddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProofOfID",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
