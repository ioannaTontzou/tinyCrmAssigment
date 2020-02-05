
using System.Collections.Generic;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;


namespace TinyCrm.Core.Services
{
    interface IProductService
    {
       
        bool AddProduct(AddProductOptions options);

        bool UpdateProduct(int productId,UpdateProductOptions options);

       Product GetProductById(int id);

        ICollection<Product> SearchProduct(SearchProductOption option);

        
    }
}
