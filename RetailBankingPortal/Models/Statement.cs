using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class Statement
    {
        public int statementID { get; set; }


        public int accountID { get; set; }

        public DateTime date { get; set; }

        public string withdrawalOrDeposit { get; set; }

        public double closingBalance { get; set; }
    }
}
