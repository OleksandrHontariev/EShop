using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.ProductServices.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "sort by...")] SimpleOrder = 0,
        [Display(Name = "Votes ↑")] ByVotes,
        [Display(Name = "Price ↓")] ByPriceLowestFirst,
        [Display(Name = "Price ↑")] ByPriceHigestFirst
    }

    public static class ProductListDtoSort
    {
        public static IQueryable<ProductListDto> OrderBooksBy (this IQueryable<ProductListDto> products, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return products.OrderByDescending(x => x.ProductId);
                case OrderByOptions.ByVotes:
                    return products.OrderByDescending(x => x.ReviewsAverageVotes);
                case OrderByOptions.ByPriceLowestFirst:
                    return products.OrderBy(x => x.ActualPrice);
                case OrderByOptions.ByPriceHigestFirst:
                    return products.OrderByDescending(x => x.ActualPrice);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
