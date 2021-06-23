using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailBankingPortal.Models
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Role { get; set; }
    }
}
