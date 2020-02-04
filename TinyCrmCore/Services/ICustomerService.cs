using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
    interface ICustomerService
    {
        bool AddCustomer(AddCustomerOptions options);

        bool UpdateCustomer(string customerId, UpdateCustomerOprions options);
    }
}
