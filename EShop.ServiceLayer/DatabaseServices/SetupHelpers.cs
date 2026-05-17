using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DataLayer.EfCode;
using EShop.DataLayer.EfClasses;
using System.IO;
using EShop.ServiceLayer.DatabaseServices.Concrete;

namespace EShop.ServiceLayer.DatabaseServices
{
    public static class SetupHelpers
    {
        private const string SeedDataSearchName = "ProductList*.json";
        public const string SeedFileSubDirectory = "seedData";

        public static async Task<int> SeedDatabaseIfNoProductsAsync(this EfDbContext context, string dataDirectory)
        {
            var numProducts = context.Products.Count();
            if (numProducts == 0)
            {
                string fileDir = Path.Combine(dataDirectory, SeedFileSubDirectory);
                var products = ProductJsonLoader.LoadProducts(fileDir, SeedDataSearchName);
                numProducts = products.Count();
                context.AddRange(products);
                await context.SaveChangesAsync();
            }
            return numProducts;
        }
    }
}
