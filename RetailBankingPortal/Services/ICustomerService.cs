using RetailBankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Services
{
    public interface ICustomerService
    {
        public Task<string> loginCustomer(UserDTO user);
        public List<CustomerAccount> getCustomerDetails(int id);
        public List<TransactionHistory> getTransactionHistory();
        public Task<AfterTransaction> getTransaction(Transaction transaction);
        public List<Statement> getStatements();
        public List<Statement> GetStatementsWithDate(StatementSearch search);
    }
}
