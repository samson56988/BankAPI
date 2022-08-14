using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        public Response CreateNewTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Response FindTransactionByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Response MakeDeposit(string AccountNumber, decimal Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }

        public Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }
    }
}
