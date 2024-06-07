using Auction.Model;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Auction.Web.Models
{
	public class AuctionDetailsViewModel
	{
		public Aukcija Auction { get; set; }
		public decimal? MaxBidAmount { get; set; }

		public bool isUserOwner { get; set; }

	}
}
