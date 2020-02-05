using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using System.Collections.Generic;

namespace TinyCrm.Core.Services
{
    interface ICustomerService
    {
        bool CreateCustomer(AddCustomerOptions options);

        //Update data of a customer
        bool UpdateCustomer(string customerId, UpdateCustomerOprions oprions);

        //Search for customers 
        List<Customer> SearchCustomer(SearchCustomerOptions option);
    }
}
