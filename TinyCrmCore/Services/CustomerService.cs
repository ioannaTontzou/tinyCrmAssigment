using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using System.Linq;
using TinyCrm.Core.Data;

namespace TinyCrmCore.Services
{

   public class CustomerService : ICustomerService
    {
     

        public readonly TinyCrmContext contex;

       

        public CustomerService(TinyCrmContext ctx)
        {
            contex = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public bool CreateCustomer(AddCustomerOptions options)
        {

            if (options == null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.FirstName)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.LastName)) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.Email)) {
                return false;
            }

            var cust = contex
                .Set<Customer>()
                .Where(s => s.VatNumber.Equals(options.VatNumber))
                .SingleOrDefault();

            if (string.IsNullOrWhiteSpace(options.VatNumber) || cust == null) {
                return false;
            }

            var newCustomer = new Customer()
            {
                Email = options.Email,
                Firstname = options.FirstName,
                Lastname = options.LastName,
                VatNumber = options.VatNumber,
                Created = DateTimeOffset.Now.Date,

            };
            cust = contex
              .Set<Customer>()
              .Find(newCustomer);

            if (cust != null) {
                return false;
            }
            contex.Add(newCustomer);
            var success = false;
            try {
                success = contex.SaveChanges() > 0;
            } catch (Exception) {
                Console.WriteLine("No Success !");
            }
            return success;
        }

        public ICollection<Customer> SearchCustomer(SearchCustomerOptions option)
        {
            
             var activeCustomerList = contex
                                      .Set<Customer>()
                                      .Where(c => c.Status == true)
                                      .ToList();
            if (option == null) {
                return null;
            }

            if (option.Id !=0) {
                activeCustomerList = contex
                                     .Set<Customer>()
                                     .Where(c => c.Status == true)
                                     .Where(c => c.Id.Equals(option.Id))
                                     .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.Phone)) {
                activeCustomerList = contex
                                     .Set<Customer>()
                                     .Where(c => c.Status == true)
                                     .Where(c => c.Phone.Equals(option.Phone))
                                     .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.Email)) {
                activeCustomerList = contex.Set<Customer>()
                                     .Where(c => c.Status == true)
                                     .Where(c => c.Email.Equals(option.Email))
                                     .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.LastName)) {
                activeCustomerList =   contex.Set<Customer>()
                                      .Where(c => c.Status == true)
                                      .Where(c => c.Lastname.Equals(option.LastName))
                                      .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.VatNumber)) {
                activeCustomerList = contex.Set<Customer>()
                                     .Where(c => c.Status == true)
                                     .Where(c => c.VatNumber.Equals(option.VatNumber))
                                     .ToList();
            }

            if (option.DateCreated != null) {
                activeCustomerList = contex.Set<Customer>()
                                   .Where(c => c.Status == true)
                                   .Where(c => c.Created == option.DateCreated)
                                   .ToList();
            }


            return activeCustomerList;
        }

        public bool UpdateCustomer(int customerId, UpdateCustomerOprions options)
        {
            if (options == null) {
                return false;
            }
            var customer = GetCustomerById(customerId);
            if (customer == null) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.Email)) {
                customer.Email = options.Email;
            }
            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                customer.Firstname = options.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                customer.Lastname = options.LastName;
            }
            if (options.VatNumber != null) {
                customer.VatNumber = options.VatNumber;
            }
            if (options.Status != null) {
                customer.Status = options.Status;
            }

            return true;
        }

        public Customer GetCustomerById( int id)
        {
            if ( id == 0) {
                return null;
            }
            return contex
                .Set<Customer>()
                .Where(s => s.Id == id)
                 .SingleOrDefault();
        }

       
    }
}
