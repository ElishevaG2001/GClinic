using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface ISpecialEvents
    {
        public Task<ActionResult<IEnumerable<TblSpecialEvent>>> GetAllSpecialEvents();
        public Task<ActionResult<TblSpecialEvent>> DeleteSpecialEvent(int id);
        public Task<ActionResult<TblSpecialEvent>> AddSpecialEvent(TblSpecialEvent room);
        public Task<ActionResult<TblSpecialEvent>> UpdateSpecialEvent(int id, TblSpecialEvent room);
        public Task<ActionResult<TblSpecialEvent>> GetSpecialEventById(int id);
    }
}
