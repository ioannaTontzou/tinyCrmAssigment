using TinyCrm.Model;
using TinyCrm.Model.Options;

namespace TinyCrm.Services
{
    interface ICustomerService
    {
        bool AddCustomer(AddCustomerOptions options);

        bool UpdateCustomer(string customerId, UpdateCustomerOprions options);
    }
}
