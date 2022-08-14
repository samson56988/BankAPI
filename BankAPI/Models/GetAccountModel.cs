using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    public class GetAccountModel
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccountName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal CurrentAccountBalance { get; set; } 
        public AccountType AccountType { get; set; }
        public string AccountNumberGenerated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
