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

        private List<Product> ProductList =  new List<Product>();

        public ProductService(TinyCrmContext ctx)
        {
            contex = ctx ?? throw new ArgumentNullException(nameof(ctx)); 
        }

        public bool AddProduct(AddProductOptions options)
        {

            if (options == null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.Id)) {
                return false;
            }
            // var product = ProductList.Where(s => s.Id.Equals(options.Id))
            //   .SingleOrDefault();
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
            var prod = new Product() {
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
                //log
            }
            return success;   
        }

        public Product GetProductById(string id)
        {
             if (string.IsNullOrWhiteSpace(id)) {
                 return null;
             }
             /*
             return ProductList.Where(s => s.Id.Equals(id))
                  .SingleOrDefault(); */

             return  contex.Set<Product>()
                           .SingleOrDefault(p => p.Id == id); 
        }

        public bool UpdateProduct(string productId,UpdateProductOptions options)
        {
            if (options == null) {
                return false;
            }
            var product = GetProductById(productId);
            if ( product == null) {
                product.Description = options.Description;
            }
            
            if (!string.IsNullOrWhiteSpace(options.Description)) {
                    
            }

            /*  if ( options.Price !=null && options.Price <= 0) {
                      return false;
              }
              */

            if (options.Price != null) {
                if(options.Price <= 0) {
                    return false;
                } else {
                    product.Price = options.Price.Value;
                }
            }

            if (options.Discount !=null &&options.Discount < 0) {
                    return false;
            }

            return true;
        }

        
    }
}
