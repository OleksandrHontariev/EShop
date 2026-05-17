using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.DatabaseServices.Concrete
{
    public class ProductJson
    {
        public string name { get; set; }
        public string description { get; set; }
        public string manufacturer { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public int seller_id { get; set; }
        public string[] tags { get; set; }
        public double averageRating { get; set; }
        public int ratingsCount { get; set; }
    }
}
