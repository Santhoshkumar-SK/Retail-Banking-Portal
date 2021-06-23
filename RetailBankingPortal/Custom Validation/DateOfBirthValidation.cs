using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Custom_Validation
{
    public class DateOfBirthValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dob = Convert.ToDateTime(value);
            DateTime dateToday = DateTime.Now;
            if (dob < dateToday)
            {
                int age = new DateTime(dateToday.Subtract(dob).Ticks).Year - 1;

                if (age > 10)
                    return true;
            }
            return false;
        }
    }
}
