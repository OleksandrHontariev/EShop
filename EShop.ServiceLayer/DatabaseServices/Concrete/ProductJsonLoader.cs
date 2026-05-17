using EShop.DataLayer.EfClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EShop.ServiceLayer.DatabaseServices.Concrete
{
    public static class ProductJsonLoader
    {
        public static IEnumerable<Product> LoadProducts (string fileDir, string fileSearchString)
        {
            var filePath = GetJsonFilePath(fileDir, fileSearchString);
            var jsonDecoded = JsonConvert.DeserializeObject<ProductInfoJson>(File.ReadAllText(filePath));
            return CreateProductsWithRefs(jsonDecoded);
        }

        private static string GetJsonFilePath(string fileDir, string searchPattern)
        {
            var files = new DirectoryInfo(fileDir).GetFiles(searchPattern);

            if (files.Length == 0)
                throw new FileNotFoundException(
                    $"Could not find a file with the search name of {searchPattern} in directory {fileDir}");

            //If there are many then we take the most recent
            return files.OrderByDescending(x => x.LastWriteTimeUtc).First().FullName;
        }

        private static IEnumerable<Product> CreateProductsWithRefs (ProductInfoJson productsInfo)
        {
            List<Product> products = new List<Product>();
            Dictionary<int, Seller> sellers = new Dictionary<int, Seller>();
            Dictionary<string, Tag> tags = new Dictionary<string, Tag>();

            foreach (var product in productsInfo.products)
            {
                foreach (var tag in product.tags)
                {
                    if (!tags.ContainsKey(tag))
                    {
                        tags.Add(tag, new Tag { TagId = tag });
                    }
                }
            }

            foreach (var seller in productsInfo.sellers)
            {
                sellers.Add(seller.id, new Seller
                {
                    FirstName = seller.first_name,
                    LastName = seller.last_name,
                    Phone = seller.phone,
                    Email = seller.email
                });
            }
            foreach (var productInfo in productsInfo.products)
            {
                Product product = new Product();

                product.Name = productInfo.name;
                product.Description = productInfo.description;
                product.Manufacturer = productInfo.manufacturer;
                product.Brand = productInfo.brand;
                product.Price = productInfo.price;
                product.Reviews = CalculateReviewsToMatch(productInfo.averageRating, productInfo.ratingsCount);
                product.Seller = sellers[productInfo.seller_id];

                product.Tags = new List<Tag>();

                foreach (var tag in productInfo.tags)
                {
                    product.Tags.Add(tags[tag]);
                }
                products.Add(product);
            }
            return products;
        }

        internal static ICollection<Review> CalculateReviewsToMatch (double averageRating, int ratingCount)
        {
            List<Review> reviews = new List<Review>();
            double currentAverage = averageRating;
            for (int i = 0; i < ratingCount; i++)
            {
                int starsNum = (int)(currentAverage > averageRating ? Math.Ceiling(averageRating) : Math.Truncate(averageRating));
                reviews.Add(new Review
                {
                    VoterName = "Anonimus",
                    StarsNumber = starsNum,
                    Comment = "The best product"
                });
                currentAverage = reviews.Average(p => p.StarsNumber);
            }
            return reviews;
        }
    }
}
