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
    public class Aukcija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [ForeignKey(nameof(Article))]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public ICollection<Bid>? Bids { get; set; }

        public string Status { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string? WinnerId { get; set; }

        public  ApplicationUser? Winner { get; set; }


    }
}
