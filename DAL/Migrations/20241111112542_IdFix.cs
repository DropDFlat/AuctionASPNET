using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_PaymentMethods_paymentMethodId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Aukcijas_ArticleId",
                table: "Aukcijas");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "PaymentMethods",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "paymentMethodId",
                table: "Bids",
                newName: "PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_paymentMethodId",
                table: "Bids",
                newName: "IX_Bids_PaymentMethodId");

            migrationBuilder.RenameColumn(
                name: "startingPrice",
                table: "Articles",
                newName: "StartingPrice");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Articles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Articles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Articles",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Aukcijas_ArticleId",
                table: "Aukcijas",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuctionId",
                table: "Articles",
                column: "AuctionId",
                unique: true,
                filter: "[AuctionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Aukcijas_AuctionId",
                table: "Articles",
                column: "AuctionId",
                principalTable: "Aukcijas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_PaymentMethods_PaymentMethodId",
                table: "Bids",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Aukcijas_AuctionId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_PaymentMethods_PaymentMethodId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Aukcijas_ArticleId",
                table: "Aukcijas");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AuctionId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaymentMethods",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Bids",
                newName: "paymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_PaymentMethodId",
                table: "Bids",
                newName: "IX_Bids_paymentMethodId");

            migrationBuilder.RenameColumn(
                name: "StartingPrice",
                table: "Articles",
                newName: "startingPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Articles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articles",
                newName: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Aukcijas_ArticleId",
                table: "Aukcijas",
                column: "ArticleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_PaymentMethods_paymentMethodId",
                table: "Bids",
                column: "paymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
