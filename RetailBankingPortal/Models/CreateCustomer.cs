using RetailBankingPortal.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class CreateCustomer
    {
        public int customerId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string customerName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string customerAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [DateOfBirthValidation(ErrorMessage = "Age Should be greater than 11")]
        public DateTime customerDOB { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Z]{5}[0-9]{4}[A-Z]{1}", ErrorMessage = "Invalid Pan number")]
        public string customerPannumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[0-9]{12}", ErrorMessage = "Invalid Aadhar number")]
        public string customerAdhaarnumber { get; set; }

        //[Required(ErrorMessage = "Required")]
        public string customerAccountType { get; set; }
    }
}
