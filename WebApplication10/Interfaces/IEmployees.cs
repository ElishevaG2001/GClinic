using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IEmployees
    {
        public Task<ActionResult<IEnumerable<TblEmployee>>> GetAllTblEmployees();
        public Task<ActionResult<TblEmployee>> GetTblEmployeeById(int id);
        public Task<ActionResult<TblEmployee>> UpdateTblEmployee(int id, TblEmployee employee);
        public  Task<ActionResult<TblEmployee>> AddTblEmployee(TblEmployee tblEmployee);
        public Task<ActionResult<TblEmployee>> DeleteTblEmployee(int id);
    }
}
