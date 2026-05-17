using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int SellerId { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public bool SoftDeleted { get; set; }

        // relationships
        public ICollection<Review> Reviews { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public PriceOffer Promition { get; set; }
    }
}
