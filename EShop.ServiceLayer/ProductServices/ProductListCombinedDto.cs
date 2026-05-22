using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.ProductServices
{
    public class ProductListCombinedDto
    {
        public ProductListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<ProductListDto> productList)
        {
            SortFilterPageData = sortFilterPageData;
            ProductList = productList;
        }

        public SortFilterPageOptions SortFilterPageData { get; private set; }
        public IEnumerable<ProductListDto> ProductList { get; private set; }
    }
}
