using BankAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BankAPI.Profiles
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap <RegisterNewAccountModel, Account>();

            CreateMap<UpdateAccountModel, Account>();

            CreateMap<Account, GetAccountModel>();

        }
    }
}
