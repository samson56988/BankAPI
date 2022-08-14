using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class UpdateAccountModel
    {
        [Key]
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]\d{4}$", ErrorMessage = "Pin must not be more than 4 digits")]
        public string Pin { get; set; }

        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public string ConfirmPin { get; set; }

        public DateTime DateLastUpdate { get; set; }
    }
}
