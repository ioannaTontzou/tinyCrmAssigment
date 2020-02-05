using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Model;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace TinyCrm.Tests
{
   public partial class   CustomerServiceTest
    {
        private readonly TinyCrm.Core.Services.ICustomerService csvc_;

        public CustomerServiceTest()
        {
            csvc_ = new TinyCrmCore.Services.CustomerService(new Core.Data.TinyCrmContext());

        }

        [Fact]
        public void Customer_Order_Success_()
        {
            using(var context = new TinyCrm.Core.Data.TinyCrmContext()) {
                var customer = new Customer()
                {
                    VatNumber = "99997701",
                    Email = "pap5@gmail.com"
                };
                customer.Orders.Add(
                  new Order()
                  {
                      DeliveryAddress = "xaxaxaxa 17"
                  
                });
                context.Add(customer);
                context.SaveChanges();
            }


        }

        [Fact]
        public void Customer_Order_Retrieve()
        {
            using (var context = new TinyCrm.Core.Data.TinyCrmContext()) {
                var customer = context
                    .Set<Customer>()
                    .Include(c => c.Orders)
                    .Where(c => c.VatNumber == "99997701")
                    .FirstOrDefault();

                Assert.NotNull(customer);
            }
        }

        [Fact]
        public void AddCustomer_Success_()
        {
            var opt = new TinyCrm.Core.Model.Options.AddCustomerOptions()
            {
                Email = "pap@gmail.com",
                FirstName = "George",
                LastName = "Papadop",
            };

        }

        [Fact]
     public void Add_Customer_Contact_Success()
      {
            using (var context = new TinyCrm.Core.Data.TinyCrmContext()) {
                var customer = new Customer()
                {
                    VatNumber = "123345678",
                    Email = "papa2@gmail.com"
                };
                customer.Contacts.Add(
                  new TinyCrmCore.Model.ContactPerson()
                  {
                      LastName = "Papas",
                      FirstName = "Kostas",
                      Email = customer.Email,
                      Phone = "2340852963",
                      Position = TinyCrmCore.Model.PositionCategory.Junior
                 }); ;
                context.Add(customer);
                context.SaveChanges();
            }

        }
        [Fact]
        public void Customer_Contact_Retrieve()
        {
            using (var context = new TinyCrm.Core.Data.TinyCrmContext()) {
                var contacts = context
                    .Set<Customer>()
                    .Include(c => c.Contacts)
                    .Where(c => c.VatNumber == "123345678")
                    .Select(c =>c.Contacts)
                    .ToList();

                Assert.NotNull(contacts);
            }
        }













    }
}
