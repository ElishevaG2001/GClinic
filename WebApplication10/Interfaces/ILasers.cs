using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface ILasers
    {
        public Task<ActionResult<IEnumerable<TblLaser>>> GetAllLasers();
        public Task<ActionResult<TblLaser>> DeleteLaser(int id);
        public Task<ActionResult<TblLaser>> AddLaser(TblLaser room);
        public Task<ActionResult<TblLaser>> UpdateLaser(int id, TblLaser laser);
        public Task<ActionResult<TblLaser>> GetLaserById(int id);
    }
}
