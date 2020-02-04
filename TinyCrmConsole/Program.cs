using System;
using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Data;
    


namespace TinyCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new TinyCrmContext();
            Console.WriteLine(context.Database.CanConnect());

            context.Database.EnsureCreated();

         /* var products=  context.Set<Product>()
                          .Where(p => p.Price > 100M);
            var p = products.ToList();
            Console.ReadKey(); */

            var p = new Product()
            {
               Id="ggg",
               Category = ProductCategory.Smartphones,
               Price=99.99M,
               Discount = 0
            };

            context.Add(p);
            context.SaveChanges();

            context.Remove(p);
            context.SaveChanges();


        }
    }
}
