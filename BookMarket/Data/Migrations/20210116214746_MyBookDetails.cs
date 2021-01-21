using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class MyBookDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MyBookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyBookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBookDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyBookDetails_MyBooks_MyBookId",
                        column: x => x.MyBookId,
                        principalTable: "MyBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyBookDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyBookDetails_MyBookId",
                table: "MyBookDetails",
                column: "MyBookId");

            migrationBuilder.CreateIndex(
                name: "IX_MyBookDetails_UserId",
                table: "MyBookDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyBookDetails");

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
    }
}
