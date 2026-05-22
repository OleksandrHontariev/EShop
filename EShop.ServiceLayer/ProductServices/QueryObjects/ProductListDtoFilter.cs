using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.ProductServices.QueryObjects
{
    public enum ProductsFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "By Votes...")] ByVotes,
        [Display(Name = "By Categories...")] ByTags
    }
    public static class ProductListDtoFilter
    {
        public static IQueryable<ProductListDto> FilterProductsBy(this IQueryable<ProductListDto> products, ProductsFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
            {
                return products;
            }

            switch (filterBy)
            {
                case ProductsFilterBy.NoFilter:
                    return products;
                case ProductsFilterBy.ByVotes:
                    var filterVote = int.Parse(filterValue);
                    return products.Where(x => x.ReviewsAverageVotes > filterVote);
                case ProductsFilterBy.ByTags:
                    return products.Where(x => x.TagStrings.Any(y => y == filterValue));
                default: throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
