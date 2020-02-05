﻿using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using System.Collections.Generic;

namespace TinyCrm.Core.Services
{
   public interface ICustomerService
    {
        bool CreateCustomer(AddCustomerOptions options);

        //Update data of a customer
        bool UpdateCustomer(int customerId, UpdateCustomerOprions oprions);

        //Search for customers 
        ICollection<Customer> SearchCustomer(SearchCustomerOptions option);
    }
}
