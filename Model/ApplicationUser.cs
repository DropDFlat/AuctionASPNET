using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model
{
    public class ApplicationUser : IdentityUser
    {

        public string? Address { get; set; }
        public ICollection<Bid>? bids { get; set; }
        public ICollection<Article>? articles { get; set; }

        public ICollection<Aukcija>? WonAuctions { get; set; }
    }
}
