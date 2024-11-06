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
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }

        [ForeignKey(nameof(Model.Aukcija))]
        public int? AuctionId { get; set;}
        public Aukcija? Aukcija { get; set; }

        public ICollection<Pic>? Images { get; set; } = new List<Pic>();
    }
}
