using Gproject.Controllers;
using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    // טבלה לרישום נכחות כניסה ויצאה של העובדים 
    public interface IAttendance
    {
        public Task<ActionResult<IEnumerable<Tblattendance>>> GetAllAttendances();
        public Task<ActionResult<Tblattendance>> DeleteAttendance(int id);
        public Task<ActionResult<Tblattendance>> AddAttendance(Tblattendance attendance);
        public Task<ActionResult<Tblattendance>> UpdateAttendance(int id, Tblattendance attendance);
        public Task<ActionResult<Tblattendance>> GetAttendanceById(int id);
    }
}
