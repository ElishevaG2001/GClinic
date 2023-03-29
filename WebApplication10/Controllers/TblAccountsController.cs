using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10;
using Gproject.DataDB;
using Gproject.Interfaces;
using System.ComponentModel;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize (Policy = "1")]
        
    public class TblAccountsController : ControllerBase
    {
        private IAccounts _accountService;

        public TblAccountsController(IAccounts accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account  get all accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAccount>>> GetAccounts()
        {
            return Ok(await _accountService.GetAllAccounts());
        }

        // GET: api/Account/5   get account by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAccount>> GetAccountById(int id)
        {
            var account = await _accountService.GettAccountById(id);

            return account == null ? NotFound() : Ok(account);
        }

        //// PUT: api/Account/5 update the account by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, TblAccount account)
        {
            try
            {
                await _accountService.UpdateAccount(id, account);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new Exception("This it not upDate ");
            }
            return NoContent();
        }

        // POST: api/Account   add new account
        [HttpPost]
        public async Task<ActionResult<Contact>> AddAccount(TblAccount account)
        {
            try
            {
                ActionResult<TblAccount> accountRes = await _accountService.AddAccount(account);

                if (accountRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddAccount", new { id = account.IdAccount }, account);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/Account/5 delete by id 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccount(id);

            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }

        [HttpGet("{day}")]
        public   async Task<int> GetAccountTotalDay(DateTime day)
        {
            try
            {
                int totatl = await _accountService.GetAccountTotalDay(day);
                return totatl;
            }
            catch (DbUpdateException)
            {
                throw new Exception("eeeroooeeee");
            }
        }
    }
}
