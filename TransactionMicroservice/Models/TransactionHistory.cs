using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class TransactionHistory
    {
        [Key]
        public int HistoryId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int CounterpartyAccountId { get; set; }

        [Required]
        public Double TransferAmount { get; set; }

        [Required]
        public DateTime DateofTranasction { get; set; }

        [Required]
        public Double ClosingBalance { get; set; }
    }
}
