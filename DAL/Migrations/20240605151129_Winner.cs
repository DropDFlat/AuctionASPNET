using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Winner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_SellerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aukcijas_Articles_ArticleId",
                table: "Aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Aukcijas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Aukcijas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WinnerId",
                table: "Aukcijas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aukcijas_ApplicationUserId",
                table: "Aukcijas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Aukcijas_WinnerId",
                table: "Aukcijas",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_SellerId",
                table: "Articles",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aukcijas_Articles_ArticleId",
                table: "Aukcijas",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aukcijas_AspNetUsers_ApplicationUserId",
                table: "Aukcijas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aukcijas_AspNetUsers_WinnerId",
                table: "Aukcijas",
                column: "WinnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Aukcijas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_SellerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Aukcijas_Articles_ArticleId",
                table: "Aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aukcijas_AspNetUsers_ApplicationUserId",
                table: "Aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aukcijas_AspNetUsers_WinnerId",
                table: "Aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Aukcijas_ApplicationUserId",
                table: "Aukcijas");

            migrationBuilder.DropIndex(
                name: "IX_Aukcijas_WinnerId",
                table: "Aukcijas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Aukcijas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Aukcijas");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Aukcijas");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

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
                name: "FK_Aukcijas_Articles_ArticleId",
                table: "Aukcijas",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Aukcijas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
