using Auction.Model;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.ComponentModel.DataAnnotations;

namespace Auction.Web.Models
{
	public class BidViewModel
	{
		public Aukcija? Aukcija { get; set; }
		[Required]
		public int AuctionId { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		[Range(0.01, double.MaxValue, ErrorMessage = "The bid amount must be greater than zero.")]
		public decimal Amount { get; set; }

		[Required]
		public int PaymentId { get; set; }
        [DataType(DataType.Currency)]
        public decimal? MaxBidAmount { get; set; }

		public bool HasExistingBid { get; set; }
    }
}
