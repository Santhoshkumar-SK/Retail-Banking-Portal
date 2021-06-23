using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class TransactionHistory
    {
        
        public int HistoryId { get; set; }

        
        public int CustomerId { get; set; }

        
        public int AccountId { get; set; }

       
        public int CounterpartyAccountId { get; set; }

       
        public Double TransferAmount { get; set; }

       
        public DateTime DateofTranasction { get; set; }

        
        public Double ClosingBalance { get; set; }
    }
}
