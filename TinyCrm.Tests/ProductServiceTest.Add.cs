using System;
using Xunit;

namespace TinyCrm.Tests
{
    public partial class ProductServiceTest
    {


        [Fact]
        public void AddProduct_Success()
        {
            var opt = new TinyCrm.Core.Model.Options.AddProductOptions() {
                Id = $"585897{DateTime.Now.Millisecond}",
                Name = "Lenovo",
                Category = Core.Model.ProductCategory.Computers,
                Price =700.00M
           };
           
            var prod = psvc_.AddProduct(opt);
            Assert.True(prod);

            var p = psvc_.GetProductById(opt.Id);
            Assert.NotNull(p);
            Assert.Equal(opt.Name, p.Name);
            Assert.Equal(opt.Price, p.Price);
            Assert.Equal(opt.Category, p.Category);
        }
        [Fact]
        public void AddProduct_Failure_InvalidCategory()
        {
            var opt = new TinyCrm.Core.Model.Options.AddProductOptions()
            {
                Id = $"585897{DateTime.Now.Millisecond}",
                Name = "Lenovo",
                Category = Core.Model.ProductCategory.Invalid,
                Price = 700.00M
            };

            var p = psvc_.AddProduct(opt);
            Assert.False(p);


        }
    }
}
