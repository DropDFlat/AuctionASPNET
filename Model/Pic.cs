using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Auction.Model
{
	public class Pic
	{
		[Key]
		public int ID { get; set; }

		public string FilePath
		{ get; set; }
		[ForeignKey(nameof(Article))]
		public int ArticleId { get; set; }
		public Article article { get; set; }



	}
}
