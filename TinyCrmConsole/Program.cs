using System;
using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;

    


namespace TinyCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmContext()) {
                var prservice = new ProductService(context);
                prservice.AddProduct(




               new TinyCrm.Core.Model.Options.AddProductOptions()
                  {
                    Id = "15599",
                     Category = ProductCategory.Smartphones,
                     Price = 13.99M,
                     Name = "MAC BOOK"
                      }); 
            }



            /* var products=  context.Set<Product>()
                             .Where(p => p.Price > 100M);
               var p = products.ToList();
               Console.ReadKey(); */

            /*  var q = context.Set<Customer>()
                             .Where(c => c.Id == 2);
              var customer = q.SingleOrDefault();

             if(customer != null) {
                  context.Remove(customer);
                  context.SaveChanges();
              } */

            


       
          /*  var product1 = new Product()
            {
               Id="12399",
               Category = ProductCategory.Smartphones,
               Price=13.99M,
               Discount = 0
            };
            */

          /*  var customer1 = new Customer()
            {
                Lastname = "papadopouos",
                Firstname = "Kostas",
                Created = DateTimeOffset.Now
            };

            context.Add(customer1);
            
            context.SaveChanges();
            */
            









        }
    }
}
