using AutoMapper;
using BankAPI.Models;
using BankAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountServices _accountServices;
        IMapper _mapper;

        public AccountController(IAccountServices accountServices, IMapper mapper)
        {
            _mapper = mapper;
            _accountServices = accountServices;
        }

        [HttpPost]
        [Route("register_new_account")]
        public IActionResult RegisterNewAccount([FromBody] RegisterNewAccountModel newAccount)
        {
            if (!ModelState.IsValid)
                return BadRequest(newAccount);

            var account = _mapper.Map<Account>(newAccount);
            return Ok(_accountServices.Create(account, newAccount.Pin, newAccount.ConfirmPin));
        }
        [HttpGet]
        [Route("get_all_accounts")]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountServices.GetAllAccounts();
            var cleanedAccounts = _mapper.Map<IList<GetAccountModel>>(accounts);
            return Ok(cleanedAccounts);
        }
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            return Ok(_accountServices.Authenticate(model.AccountNumber, model.Pin));
        }
        [HttpGet]
        [Route("get_by_account_number")]
        public IActionResult GetByAccountNumber(string AccountNumber)
        {
            if (!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest("Account Number must be 10-digit");

            var account = _accountServices.GetByAccountNumber(AccountNumber);
            var cleanAccount = _mapper.Map<GetAccountModel>(account);
            return Ok(cleanAccount);  
        }
        [HttpGet]
        [Route("get_by_ID")]
        public IActionResult GetByAccountNumber(int iD)
        {


            var account = _accountServices.GetById(iD);
            var cleanAccount = _mapper.Map<GetAccountModel>(account);
            return Ok(cleanAccount);

        }
        [HttpPost]
        [Route("update_account")]
        public IActionResult UpdateAccount([FromBody]UpdateAccountModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var account = _mapper.Map<Account>(model);
            _accountServices.Update(account, model.Pin);
            return Ok();
        }

    }
}
