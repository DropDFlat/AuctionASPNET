using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model
{
	public class AuctionDTO
	{
		public int Id { get; set; }
		public ArticleDTO Article { get; set; }
		public string Status { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
