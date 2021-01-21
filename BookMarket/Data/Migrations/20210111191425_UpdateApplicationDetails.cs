using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class UpdateApplicationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "ApplicationDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Application",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Application");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "ApplicationDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Application_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
