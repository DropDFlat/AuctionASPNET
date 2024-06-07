using Microsoft.AspNetCore.Mvc;
using Model;

namespace Auction.Web.Models
{
    public class AuctionFilterModel
    {
        public Article article { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
