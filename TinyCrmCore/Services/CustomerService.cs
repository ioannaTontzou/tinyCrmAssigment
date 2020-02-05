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
        public static List<Customer> CustomerList = new List<Customer>();

        public readonly TinyCrmContext contex;

        private List<Product> ProductList = new List<Product>();

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
            if (string.IsNullOrWhiteSpace(options.VatNumber) || CustomerList.Where(s => s.VatNumber.Equals(options.VatNumber)) == null) {
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

            if (CustomerList.Contains(newCustomer)) {
                return false;
            }
            CustomerList.Add(newCustomer);
            return true;
        }

        public List<Customer> SearchCustomer(SearchCustomerOptions option)
        {
            var activeCustomerList = new List<Customer>(CustomerList);
            activeCustomerList = activeCustomerList
                .Where(c => c.Status == true).ToList();


            if (option == null) {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(option.Id)) {
                activeCustomerList = activeCustomerList
                                     .Where(c => c.Id.Equals(option.Id))
                                     .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.Phone)) {
                activeCustomerList = activeCustomerList
                                  .Where(c => c.Phone.Equals(option.Phone))
                                  .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.Email)) {
                activeCustomerList = activeCustomerList
                                     .Where(c => c.Email.Equals(option.Email))
                                     .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.LastName)) {
                activeCustomerList = activeCustomerList
                                      .Where(c => c.Lastname.Equals(option.LastName))
                                      .ToList();
            }

            if (!string.IsNullOrWhiteSpace(option.VatNumber)) {
                activeCustomerList = activeCustomerList
                                 .Where(c => c.VatNumber.Equals(option.VatNumber))
                                 .ToList();
            }

            if (option.DateCreated != null) {
                activeCustomerList = activeCustomerList
                                   .Where(c => c.Created == option.DateCreated)
                                   .ToList();
            }


            return activeCustomerList;
        }

        public bool UpdateCustomer(string customerId, UpdateCustomerOprions options)
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

        public Customer GetCustomerById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                return null;
            }
            return CustomerList.Where(s => s.Id.Equals(id))
                 .SingleOrDefault();
        }
    }
}
