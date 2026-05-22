using EShop.DataLayer.EfCode;
using EShop.ServiceLayer.ProductServices.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ServiceLayer.ProductServices.Concrete
{
    public class ProductFilterDropdownService
    {
        private readonly EfDbContext _context;

        public ProductFilterDropdownService(EfDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DropdownTuple> GetFilterDropDownValues (ProductsFilterBy filterBy)
        {
            switch (filterBy)
            {
                case ProductsFilterBy.NoFilter:
                    return new List<DropdownTuple>();
                case ProductsFilterBy.ByVotes:
                    return FormVotesDropDown();
                case ProductsFilterBy.ByTags:
                    return _context.Tag.Select(t => new DropdownTuple { Value = t.TagId, Text = t.TagId });
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }

        private static IEnumerable<DropdownTuple> FormVotesDropDown()
        {
            return new[]
            {
                new DropdownTuple { Value = "4", Text = "4 stars end up" },
                new DropdownTuple { Value = "3", Text = "3 stars end up" },
                new DropdownTuple { Value = "2", Text = "2 stars end up" },
                new DropdownTuple { Value = "1", Text = "1 star end up" },
            };
        }
    }
}
