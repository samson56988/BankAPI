using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccountName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        public AccountType AccountType { get; set; } // This will be an Enum to show if the account to be creared is "Savings" or "Current"
        public string AccountNumberGenerated { get; set; }

        //we'll also store the hash and salt of the account Transaction pin

        public byte[] PinHash { get; set; }

        public byte[] Pinsalt { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdate { get; set; }



        //now to generate an accountNumber, let's do that in the constructor

        Random rand = new Random();

        public Account() 
        {
            AccountNumberGenerated =  Convert.ToString((long) rand.NextDouble() * 9_000_000_000L + 1_000_000_000L);
            //also AccountName property = FirstName and Lastname
            AccountName = $"{Firstname} {Lastname}"; //e.g John

        }
       
    }

    public enum AccountType
    {
        Savings,
        Current,
        Corporate,
        Goverment
    }
}
