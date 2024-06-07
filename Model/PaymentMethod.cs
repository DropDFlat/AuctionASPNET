using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bid>? Bids { get; set; }
    }
}
