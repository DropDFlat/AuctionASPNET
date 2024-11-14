using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BidFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_AuctionUserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AuctionUserId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "AuctionUserId",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "BidderId",
                table: "Bids",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidderId",
                table: "Bids",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_BidderId",
                table: "Bids",
                column: "BidderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_BidderId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_BidderId",
                table: "Bids");

            migrationBuilder.AlterColumn<string>(
                name: "BidderId",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AuctionUserId",
                table: "Bids",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionUserId",
                table: "Bids",
                column: "AuctionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_AuctionUserId",
                table: "Bids",
                column: "AuctionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
