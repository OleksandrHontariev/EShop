using EShop.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using EShop.ServiceLayer.ProductServices.QueryObjects;
using EShop.DataLayer.QueryObjects;

namespace EShop.ServiceLayer.ProductServices.Concrete
{
    public class ListProductsService
    {
        private readonly EfDbContext _context;

        public ListProductsService(EfDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductListDto> SortFilterPage (SortFilterPageOptions options)
        {
            var productsQuery = _context.Products
                .AsNoTracking()
                .MapProductToDto()
                .OrderBooksBy(options.OrderByOptions)
                .FilterProductsBy(options.FilterBy, options.FilterValue);

            options.SetupRestOfDto(productsQuery);

            return productsQuery.Page<ProductListDto>(options.PageNum - 1, options.PageSize);
        }
    }
}
