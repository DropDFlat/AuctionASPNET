using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "auctionUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AuctionUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_auctionUsers_IdentityUserId",
                table: "auctionUsers",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_auctionUsers_AspNetUsers_IdentityUserId",
                table: "auctionUsers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_auctionUsers_AspNetUsers_IdentityUserId",
                table: "auctionUsers");

            migrationBuilder.DropIndex(
                name: "IX_auctionUsers_IdentityUserId",
                table: "auctionUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "auctionUsers");

            migrationBuilder.DropColumn(
                name: "AuctionUserId",
                table: "AspNetUsers");
        }
    }
}
