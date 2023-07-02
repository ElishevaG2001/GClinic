using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.ComponentModel;

namespace Gproject.Services
{
    public class AccountsService :IAccounts
    {
      private readonly DataProjectContext _context;

      public AccountsService(DataProjectContext context)
      {
        _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<TblAccount>>> GetAllAccounts()
      {
        return await _context.TblAccounts.ToListAsync();
      }

     // GET: api/Acounts/5   get Account by id
      public async Task<ActionResult<TblAccount>> GettAccountById(int id)
      {
        return await _context.TblAccounts.FirstOrDefaultAsync(u => u.IdAccount == id);
      }

      // POST: api/Account   add new Account
      public async Task<ActionResult<TblAccount>> AddAccount(TblAccount account)
      {
        _context.TblAccounts.Add(account);

        await _context.SaveChangesAsync();

        return findAccount(account.IdAccount);
      }

      // DELETE: api/Account/5
      [HttpDelete("{id}")]
       public async Task<ActionResult<TblAccount>> DeleteAccount(int id)
       {

         TblAccount account = findAccount(id);

         if (account == null)
         {
           throw new Exception("This Account is not valid!");
         }

         _context.TblAccounts.Remove(account);
         await _context.SaveChangesAsync();

         return account;
       }


       // PUT: api/Account/5 update the account by id 
       public async Task<ActionResult<TblAccount>> UpdateAccount(int id, TblAccount account)
       {
            if (id != account.IdAccount)
            {
                 throw new Exception("erro with the parameter Id");
            }

            if (findAccount(account.IdAccount) == null)
            {
               throw new Exception("This Account is not Exsit!");
            }

             _context.Entry(account).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return account;
       }

        //
        private bool AccountExists(int id)
        {
            return _context.TblAccounts.Any(e => e.IdAccount == id);
        }


        //find account if exsists & rerun the coaccountntact or null 
        private TblAccount findAccount(int id)
        {
            return _context.TblAccounts.FirstOrDefault(c => c.IdAccount == id);
        }

        public async Task<int> GetAccountTotalDay(DateTime day)
        {
            var AllDay = await _context.TblAccounts.Where(d => d.DateTime == day).ToArrayAsync();

            int totalDay = 0;
            foreach (var t in AllDay)
            {
                totalDay = (int)(totalDay + t.Pay);
            }
            return totalDay;
        }
    }
}


