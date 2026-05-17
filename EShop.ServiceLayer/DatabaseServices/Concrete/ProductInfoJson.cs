using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.DatabaseServices.Concrete
{
    public class ProductInfoJson
    {
        public ICollection<ProductJson> products { get; set; }
        public ICollection<SellerJson> sellers { get; set; }
    }
}
