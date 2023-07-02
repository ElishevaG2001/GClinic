using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IAccounts
    {
        public Task<ActionResult<IEnumerable<TblAccount>>> GetAllAccounts();
        public Task<ActionResult<TblAccount>> GettAccountById(int id);
        public Task<ActionResult<TblAccount>> AddAccount(TblAccount account);
        public Task<ActionResult<TblAccount>> DeleteAccount(int id);
        public Task<ActionResult<TblAccount>> UpdateAccount(int id, TblAccount account);
        public Task<int> GetAccountTotalDay(DateTime day);


    }
}
