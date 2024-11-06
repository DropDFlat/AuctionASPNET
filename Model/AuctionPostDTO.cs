using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model
{
	public class AuctionPostDTO
	{
		public int Id { get; set; }
		public int ArticleId { get; set; }
		
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
