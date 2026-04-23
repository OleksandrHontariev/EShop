using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrderedUtc { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<LineItem> LineItems { get; set; }

        public Order()
        {
            DateOrderedUtc = DateTime.UtcNow;
        }
    }
}
