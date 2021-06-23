using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal
{
    public class CreateCustomerResponse
    {
        public string message { get; set; }

        public int customerId { get; set; }

        public int accountId { get; set; }
    }
}
