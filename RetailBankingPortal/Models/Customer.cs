using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class Customer
    {
        [Required]
        public int customerId { get; set; }


        public string customerName { get; set; }


        public string customerAddress { get; set; }


        public DateTime customerDOB { get; set; }


        public string customerPannumber { get; set; }


        public string customerAdhaarnumber { get; set; }

        public string customerAccountType { get; set; }
    }
}
