using System.Linq;
using EShop.DataLayer.EfClasses;

namespace EShop.ServiceLayer.ProductServices.QueryObjects
{
    public static class ProductListDtoSelect
    {
        public static IQueryable<ProductListDto> MapProductToDto (this IQueryable<Product> products)
        {
            return products.Select(product => new ProductListDto
            {
                ProductId = product.Id,
                Title = product.Name,
                Price = product.Price,
                ActualPrice = product.Promotion == null ? product.Price : product.Promotion.NewPrice,
                SellerName = $"{product.Seller.FirstName} {product.Seller.LastName}",
                PromotionPromotionalText = product.Promotion == null ? null : product.Promotion.PromotionalText,
                ReviewsCount = product.Reviews.Count,
                ReviewsAverageVotes = product.Reviews.Select(review => (double?)review.StarsNumber).Average(),
                TagStrings = product.Tags.Select(tag => tag.TagId).ToArray()
            });
        }
    }
}
