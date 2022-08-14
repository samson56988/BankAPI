using BankAPI.DAL;
using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class AccountService : IAccountServices
    {
        private YourBankDbContext _dbContext;
        

        public AccountService(YourBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account Authenticate(string AccountNumber, string Pin)
        {
            //let's make authenticate
            //does account exists for the number

            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).SingleOrDefault();
            if (account == null)
                return null;
            //ok so we have a match
            //verify pinHash
            if (!VerifyPinHash(Pin, account.PinHash, account.Pinsalt))
                return null;

            return account;
        }
        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin");

            using(var hmac  = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));

                for(int i = 0; i < computedPinHash.Length; i++)
                {
                    if (computedPinHash[i] != pinHash[i]) 
                        return false;
                }
            }

            return true;
        }

        public Account Create(Account account, string Pin, string ConfirmPin)
        {
            //this is to create a new account

            if(_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("An account already exists with email");

            //validate pin

            if (!Pin.Equals(ConfirmPin))
                throw new ArgumentException("Pins do not match", "Pin");

            //now all validation passes, lets create account

            byte[] pinHash, pinSalt;

            CreatePinHash(Pin, out pinHash, out pinSalt);

            account.PinHash = pinHash;
            account.Pinsalt = pinSalt;

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return account;  

  
        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using(var hmac =  new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public void Delete(int Id)
        {
            var account = _dbContext.Accounts.Find(Id);
            if(account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefault();
            if (account == null)
                return null;

            return account;
        }

        public Account GetById(int Id)
        {
            var account = _dbContext.Accounts.Where(x => x.ID == Id).FirstOrDefault();
            if (account == null)
                return null;

            return account;
        }

        public void Update(Account account, string Pin = null)
        {
            //Update is more tasky
            var accountToBeUpdated = _dbContext.Accounts.Where(x => x.Email == account.Email).SingleOrDefault();
            if (accountToBeUpdated == null)
                throw new ApplicationException
                    ("Account does not exists");
            //if it exists, let's listen for user wanting to change any of his properties
            if(!string.IsNullOrWhiteSpace(account.Email))
            {
                if(_dbContext.Accounts.Any(x => x.Email == account.Email))
                        throw new ApplicationException("This Email" + account.Email + " already exist");
                //else change email
                accountToBeUpdated.Email = account.Email;

            }

            if (!string.IsNullOrWhiteSpace(account.PhoneNumber))
            {
                if (_dbContext.Accounts.Any(x => x.Email == account.PhoneNumber))
                    throw new ApplicationException("This Phone" + account.PhoneNumber + " already exist");
                //else change email
                accountToBeUpdated.PhoneNumber = account.PhoneNumber;

            }
            if (!string.IsNullOrWhiteSpace(Pin))
            {
                byte[] pinHash, pinSalt;
                CreatePinHash(Pin, out pinHash, out pinSalt);

                accountToBeUpdated.PinHash = pinHash;
                accountToBeUpdated.Pinsalt = pinSalt;

            }

            accountToBeUpdated.DateLastUpdate = DateTime.Now;

            //now persist to this update to db

            _dbContext.Accounts.Update(accountToBeUpdated);

            _dbContext.SaveChanges();
        }
    }
}
