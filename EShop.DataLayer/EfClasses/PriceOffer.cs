using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class PriceOffer
    {
        public int Id { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }

        // relationships
        public int ProductId { get; set; }
    }
}
