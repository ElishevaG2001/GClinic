using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface ITreats
    {
        public Task<ActionResult<IEnumerable<TblTreat>>> GetAllTreats();
        public Task<ActionResult<TblTreat>> GettTreatById(int id);
        public Task<ActionResult<TblTreat>> AddTreat(TblTreat treat);
        public Task<ActionResult<TblTreat>> DeleteTreat(int id);
        public Task<ActionResult<TblTreat>> UpdateTreat(int id, TblTreat treat);
    }
}
