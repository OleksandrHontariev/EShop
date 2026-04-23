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
        public short NumBooks { get; set; }
        public decimal BookPrice { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }

        // relationships

        public Product Product { get; set; }
    }
}
