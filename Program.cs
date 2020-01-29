using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using TinyCrm.Model.Options;
using TinyCrm.Model;
using TinyCrm.Services;


namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Product prod1 = new Product();

             Console.WriteLine("Type the ID product");
             var pId = Console.ReadLine();

             Console.WriteLine("Type the Name product");
             var pName = Console.ReadLine();

             Console.WriteLine("Type the Price product");
             var pPrice = Console.ReadLine();
             var decPrice = decimal.Parse(pPrice);

             Console.WriteLine("Type the Category product");
             var pCategory = Console.ReadLine();
             var intCategory = int.Parse(pCategory);
             */

            var productService = new Services.ProductService();
            productService.AddProduct(
                new Model.Options.AddProductOptions()
                {
                    Id = "123",
                    Price = 13.33M,
                    Category = Model.ProductCategory.Cameras,
                    Name = "Camera 1"
                });
            productService.AddProduct(
                new Model.Options.AddProductOptions()
                {
                    Id = "124",
                    Price = 13.33M,
                    Category = Model.ProductCategory.Cameras,
                    Name = "camera 2"
                });
            productService.UpdateProduct("123",
                new Model.Options.UpdateProductOptions()
                {
                    Price = 22.22M
                });



        }
    }
}
