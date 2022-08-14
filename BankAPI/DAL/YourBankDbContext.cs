﻿using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DAL
{
    public class YourBankDbContext:DbContext
    {
        public YourBankDbContext(DbContextOptions<YourBankDbContext> options):base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
