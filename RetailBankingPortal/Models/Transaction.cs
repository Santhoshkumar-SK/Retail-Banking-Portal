using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class Transaction
    {
        [Required]
        public int sourceAccountId { get; set; }

        [Required]
        public int destinationAccountId { get; set; }

        [Required]
        public double amount { get; set; }
    }
}
