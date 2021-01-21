using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMarket.Data.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDetails");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.CreateTable(
                name: "RentApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProofOfAddress = table.Column<string>(nullable: false),
                    ProofOfID = table.Column<string>(nullable: false),
                    NextOfKinId = table.Column<string>(nullable: false),
                    NextOfKinContacts = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentApplication_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProofId = table.Column<string>(nullable: false),
                    ProofAddress = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RentApplicationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentApplicationDetails_RentApplication_RentApplicationId",
                        column: x => x.RentApplicationId,
                        principalTable: "RentApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentApplicationDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SellApplicationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellApplicationDetails_SellApplication_SellApplicationId",
                        column: x => x.SellApplicationId,
                        principalTable: "SellApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellApplicationDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentApplication_UserId",
                table: "RentApplication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentApplicationDetails_RentApplicationId",
                table: "RentApplicationDetails",
                column: "RentApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RentApplicationDetails_UserId",
                table: "RentApplicationDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellApplicationDetails_SellApplicationId",
                table: "SellApplicationDetails",
                column: "SellApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellApplicationDetails_UserId",
                table: "SellApplicationDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentApplicationDetails");

            migrationBuilder.DropTable(
                name: "SellApplicationDetails");

            migrationBuilder.DropTable(
                name: "RentApplication");

            migrationBuilder.DropTable(
                name: "SellApplication");

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProofAddress = table.Column<string>(nullable: false),
                    ProofId = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_UserId",
                table: "ApplicationDetails",
                column: "UserId");
        }
    }
}
