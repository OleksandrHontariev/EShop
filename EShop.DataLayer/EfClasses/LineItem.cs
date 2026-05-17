using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class LineItem
    {
        public int Id { get; set; }
        public byte LineNum { get; set; }
        public short NumProducts { get; set; }
        public decimal ProductPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // relationships

        public Product Product { get; set; }
    }
}
