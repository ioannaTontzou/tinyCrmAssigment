using System;
using Xunit;

namespace TinyCrm.Tests
{
    public partial class ProductServiceTest
    {
        private readonly  TinyCrm.Core.Services.ProductService psvc_;

        public ProductServiceTest()
        {
            psvc_ = new Core.Services.ProductService(new Core.Data.TinyCrmContext());

        }
        [Fact]
        public void GetProductById_Success()
        {
           var prod = psvc_.GetProductById("123444");

           Assert.NotNull(prod);
           Assert.Equal(99.99M, prod.Price);
          
        }

        [Fact]
        public void GetProductById_FaiLure_Null_ProductId()
        {
            var prod = psvc_.GetProductById("  ");
            Assert.Null(prod);

            prod = psvc_.GetProductById(null);
            Assert.Null(prod);
          

        }


    }
}
