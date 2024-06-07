using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Users2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_auctionUsers_SellerId",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_auctionUsers_AspNetUsers_IdentityUserId",
                table: "auctionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_auctionUsers_City_CityId",
                table: "auctionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_aukcijas_articles_ArticleId",
                table: "aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_auctionUsers_BidderId",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_aukcijas_AuctionId",
                table: "bids");

            migrationBuilder.DropForeignKey(
                name: "FK_bids_paymentMethods_paymentMethodId",
                table: "bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentMethods",
                table: "paymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bids",
                table: "bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_aukcijas",
                table: "aukcijas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_auctionUsers",
                table: "auctionUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_articles",
                table: "articles");

            migrationBuilder.RenameTable(
                name: "paymentMethods",
                newName: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "bids",
                newName: "Bids");

            migrationBuilder.RenameTable(
                name: "aukcijas",
                newName: "Aukcijas");

            migrationBuilder.RenameTable(
                name: "auctionUsers",
                newName: "AuctionUsers");

            migrationBuilder.RenameTable(
                name: "articles",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_bids_paymentMethodId",
                table: "Bids",
                newName: "IX_Bids_paymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_bids_BidderId",
                table: "Bids",
                newName: "IX_Bids_BidderId");

            migrationBuilder.RenameIndex(
                name: "IX_bids_AuctionId",
                table: "Bids",
                newName: "IX_Bids_AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_aukcijas_ArticleId",
                table: "Aukcijas",
                newName: "IX_Aukcijas_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_auctionUsers_IdentityUserId",
                table: "AuctionUsers",
                newName: "IX_AuctionUsers_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_auctionUsers_CityId",
                table: "AuctionUsers",
                newName: "IX_AuctionUsers_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_articles_SellerId",
                table: "Articles",
                newName: "IX_Articles_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aukcijas",
                table: "Aukcijas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuctionUsers",
                table: "AuctionUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AuctionUsers_SellerId",
                table: "Articles",
                column: "SellerId",
                principalTable: "AuctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionUsers_AspNetUsers_IdentityUserId",
                table: "AuctionUsers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionUsers_City_CityId",
                table: "AuctionUsers",
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
                name: "FK_Bids_AuctionUsers_BidderId",
                table: "Bids",
                column: "BidderId",
                principalTable: "AuctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Aukcijas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_PaymentMethods_paymentMethodId",
                table: "Bids",
                column: "paymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AuctionUsers_SellerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionUsers_AspNetUsers_IdentityUserId",
                table: "AuctionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AuctionUsers_City_CityId",
                table: "AuctionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aukcijas_Articles_ArticleId",
                table: "Aukcijas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AuctionUsers_BidderId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Aukcijas_AuctionId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_PaymentMethods_paymentMethodId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aukcijas",
                table: "Aukcijas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuctionUsers",
                table: "AuctionUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "paymentMethods");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "bids");

            migrationBuilder.RenameTable(
                name: "Aukcijas",
                newName: "aukcijas");

            migrationBuilder.RenameTable(
                name: "AuctionUsers",
                newName: "auctionUsers");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "articles");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_paymentMethodId",
                table: "bids",
                newName: "IX_bids_paymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_BidderId",
                table: "bids",
                newName: "IX_bids_BidderId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_AuctionId",
                table: "bids",
                newName: "IX_bids_AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_Aukcijas_ArticleId",
                table: "aukcijas",
                newName: "IX_aukcijas_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionUsers_IdentityUserId",
                table: "auctionUsers",
                newName: "IX_auctionUsers_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionUsers_CityId",
                table: "auctionUsers",
                newName: "IX_auctionUsers_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_SellerId",
                table: "articles",
                newName: "IX_articles_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentMethods",
                table: "paymentMethods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bids",
                table: "bids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_aukcijas",
                table: "aukcijas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auctionUsers",
                table: "auctionUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articles",
                table: "articles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_auctionUsers_SellerId",
                table: "articles",
                column: "SellerId",
                principalTable: "auctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_auctionUsers_AspNetUsers_IdentityUserId",
                table: "auctionUsers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_auctionUsers_City_CityId",
                table: "auctionUsers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_aukcijas_articles_ArticleId",
                table: "aukcijas",
                column: "ArticleId",
                principalTable: "articles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_auctionUsers_BidderId",
                table: "bids",
                column: "BidderId",
                principalTable: "auctionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_aukcijas_AuctionId",
                table: "bids",
                column: "AuctionId",
                principalTable: "aukcijas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bids_paymentMethods_paymentMethodId",
                table: "bids",
                column: "paymentMethodId",
                principalTable: "paymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
