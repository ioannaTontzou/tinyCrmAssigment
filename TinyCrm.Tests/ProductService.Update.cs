using System;
using Xunit;

namespace TinyCrm.Tests
{
    public partial class ProductServiceTest
    {


        [Fact]
        public void UpdateProduct_Success()
        {
            var opt = new TinyCrm.Core.Model.Options.UpdateProductOptions() {
                Description = "apple",
                Price = 234.99M,
                Discount = 15.00M
                
           };

            var prod = psvc_.UpdateProduct("123554", opt);
            Assert.True(prod);

           /* var p = psvc_.GetProductById("123444");
            Assert.NotNull(p);

            Assert.Equal(opt.Price, p.Price);
            Assert.Equal(opt.Description, p.Description);
            Assert.Equal(opt.Discount, p.Discount);
            */
             
        }


    }
}
