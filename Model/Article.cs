using Auction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public decimal startingPrice { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }

        [ForeignKey(nameof(Aukcija))]
        public int? AuctionId { get; set;}
        public Aukcija? aukcija { get; set; }

        public ICollection<Pic>? Images { get; set; } = new List<Pic>();
    }
}
