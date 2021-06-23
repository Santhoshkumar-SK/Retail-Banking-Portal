using RetailBankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Services
{
    public interface IEmployeeService
    {
        public Task<string> loginEmployee(UserDTO user);
        public Customer getCustomerDetails(int id);
        public Task<CreateCustomerResponse> createCustomer(CreateCustomer createCustomer);
    }
}
