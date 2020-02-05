using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Model;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.Core.Data;
using System;

namespace TinyCrm.Core.Services
{
    public class ProductService : IProductService
    {
        public readonly TinyCrmContext contex;

        public ProductService(TinyCrmContext ctx)
        {
            contex = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public bool AddProduct(AddProductOptions options)
        {

            if (options == null) {
                return false;
            }
            if (options.Id == 0) {
                return false;
            }
           
            var product = GetProductById(options.Id);
            if (product != null) {
                return false;
            }
            if (GetProductById(options.Id) != null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }
            if (options.Price <= 0) {
                return false;
            }
            if (options.Category == Model.ProductCategory.Invalid) {
                return false;
            }
            var prod = new Product()
            {
                Id = options.Id,
                Name = options.Name,
                Price = options.Price,
                Category = options.Category
            };

            contex.Add(prod);
            var success = false;
            try {
                success = contex.SaveChanges() > 0;
            } catch (Exception) {
                Console.WriteLine("No Success !");
            }
            return success;
        }

        public Product GetProductById(int id)
        {
            if (id == 0) {
                return null;
            }
            var option = new TinyCrm.Core.Model.Options.SearchProductOption()
            {
                Id = id
            };

            return SearchProduct(option).SingleOrDefault();


        }

        public bool UpdateProduct(int productId, UpdateProductOptions options)
        {

            if (options == null) {
                return false;
            }
            var product = GetProductById(productId);
            if (product == null) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.Description)) {
                product.Description = options.Description;
            }
            if (options.Price != null &&
              options.Price <= 0) {
                return false;
            }
            if (options.Price != null) {
                if (options.Price <= 0) {
                    return false;
                } else {
                    product.Price = options.Price.Value;
                }
            }
            if (options.Discount != null &&
              options.Discount < 0) {
                return false;
            }
            return true;
        }

        public  ICollection<Product> SearchProduct(SearchProductOption option)
        {
            if (option == null) {
                return null;
            }
            if (option.Id != 0) {
                var prod = contex
                       .Set<Product>()
                       .Where(p => p.Id == option.Id)
                       .ToList();
                return prod;
            }
            if (!string.IsNullOrWhiteSpace(option.Name)) {
                var prod = contex
                          .Set<Product>()
                          .Where(p => p.Name == option.Name)
                          .ToList();
                return prod;
            }
            if (option.Category != ProductCategory.Invalid) {
                var prod = contex
                          .Set<Product>()
                          .Where(p => p.Category == option.Category)
                          .ToList();
                return prod;
            }
            return null;
        }
    }
}

