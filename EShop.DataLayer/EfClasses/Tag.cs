using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class Tag
    {
        public string TagId { get; set; }

        // relationships
        public ICollection<Product> Products { get; set; }
    }
}
