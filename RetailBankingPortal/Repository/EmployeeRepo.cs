using RetailBankingPortal.Models;
using RetailBankingPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {


       

        private readonly IEmployeeService _service;

        public EmployeeRepo(IEmployeeService service)
        {

            _service = service;
        }

        public async Task<string> loginEmployee(UserDTO user)
        {
            string jwtToken = await _service.loginEmployee(user);

            if (jwtToken == null)
            {
                return null;
            }
            return jwtToken;
        }

        public Customer getCustomerDetails(int id)
        {

            var data = _service.getCustomerDetails(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<CreateCustomerResponse> createCustomer(CreateCustomer createCustomer)
        {

            createCustomer.customerDOB = new DateTime(createCustomer.customerDOB.Year, createCustomer.customerDOB.Month, createCustomer.customerDOB.Day);
            CreateCustomerResponse response = await _service.createCustomer(createCustomer);
            if (response != null)
            {
                return response;
            }

            return null;
        }


    }
}
