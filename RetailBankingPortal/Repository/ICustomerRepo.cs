using RetailBankingPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Repository
{
    public interface ICustomerRepo
    {
        public Task<string> loginCustomer(UserDTO user);
        public List<CustomerAccount> getCustomerDetails(int id);
        public List<TransactionHistory> getTransactionHistory();
        public Task<AfterTransaction> getTransaction(Transaction transaction);
        public List<Statement> GetStatements();
        public List<Statement> GetStatementsWithDate(StatementSearch search);
    }
}
