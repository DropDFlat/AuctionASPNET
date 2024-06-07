using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AuctionUsers_SellerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AuctionUsers_BidderId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "AuctionUsers");

            migrationBuilder.DropIndex(
                name: "IX_Bids_BidderId",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "BidderId",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AuctionUserId",
                table: "Bids",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionUserId",
                table: "Bids",
                column: "AuctionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_SellerId",
                table: "Articles",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_AuctionUserId",
                table: "Bids",
                column: "AuctionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_SellerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_AuctionUserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AuctionUserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuctionUserId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BidderId",
                table: "Bids",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "AuctionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionUsers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionUsers_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidderId",
                table: "Bids",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUsers_CityId",
                table: "AuctionUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUsers_IdentityUserId",
                table: "AuctionUsers",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AuctionUsers_SellerId",
                table: "Articles",
                column: "SellerId",
                principalTable: "AuctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AuctionUsers_BidderId",
                table: "Bids",
                column: "BidderId",
                principalTable: "AuctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
