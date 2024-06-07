using Microsoft.AspNetCore.Mvc;
using Model;

namespace Auction.Web.Models
{
    public class WonAuctionsViewModel : Controller
    {
        public List<Aukcija> WonAuctions { get; set; }
    }
}
