using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class AfterTransaction
    {
        public string message { get; set; }

        public double sourceAccountBalance { get; set; }

        public double destinationBalance { get; set; }

    }
}
