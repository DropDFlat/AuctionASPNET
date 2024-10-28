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
    public class Bid
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Auction))]
        public int AuctionId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string BidderId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal BidAmount { get; set; }
        public Aukcija Auction { get; set; }
        public ApplicationUser AuctionUser { get; set; }

        [ForeignKey(nameof(Model.PaymentMethod))]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
