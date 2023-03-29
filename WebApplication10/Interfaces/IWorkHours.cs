using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IWorkHours
    {
        public Task<ActionResult<IEnumerable<TblWorkHour>>> GetAllWorkHours();
        public Task<ActionResult<TblWorkHour>> DeleteWorkHour(int id);
        public Task<ActionResult<TblWorkHour>> AddWorkHour(TblWorkHour workHour);
        public Task<ActionResult<TblWorkHour>> UpdateWorkHour(int id, TblWorkHour workHour);
        public Task<ActionResult<TblWorkHour>> GetWorkHourById(int id);
    }
}
