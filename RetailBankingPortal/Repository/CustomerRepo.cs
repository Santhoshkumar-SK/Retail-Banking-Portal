using RetailBankingPortal.Models;
using RetailBankingPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ICustomerService _service;



        public CustomerRepo(ICustomerService service)
        {
            _service = service;

        }



        public async Task<string> loginCustomer(UserDTO user)
        {
            string jwtToken = await _service.loginCustomer(user);

            if (jwtToken == null)
            {
                return null;
            }
            return jwtToken;
        }

        public List<CustomerAccount> getCustomerDetails(int id)
        {

            var data = _service.getCustomerDetails(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public List<TransactionHistory> getTransactionHistory()
        {
            var data = _service.getTransactionHistory();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<AfterTransaction> getTransaction(Transaction transaction)
        {

            AfterTransaction data = await _service.getTransaction(transaction);

            if (data == null)
            {
                return null;
            }

            return data;

        }


        public List<Statement> GetStatements()
        {
            List<Statement> data = _service.getStatements();
            if (data == null)
            {
                return null;
            }

            return data;
        }

        public List<Statement> GetStatementsWithDate(StatementSearch search)
        {
            List<Statement> data = _service.GetStatementsWithDate(search);
            if (data == null)
            {
                return null;
            }
            return data;
        }
    }
}
