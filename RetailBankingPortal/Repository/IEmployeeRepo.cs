using RetailBankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Repository
{
    public interface IEmployeeRepo
    {
        public Task<string> loginEmployee(UserDTO user);
        public Customer getCustomerDetails(int id);
        public Task<CreateCustomerResponse> createCustomer(CreateCustomer createCustomer);
    }
}
