using Auction.Model;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Web.Models
{
	public class AuctionEditViewModel : AuctionArticleViewModel
	{
		public int AuctionId { get; set; }
		public int ArticleId { get; set; }

		public ICollection<Pic>? Images { get; set; }
	}
}
