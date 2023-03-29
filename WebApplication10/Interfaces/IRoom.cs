using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IRoom
    {
        public Task<ActionResult<IEnumerable<TblRoom>>> GetAllRooms();
        public Task<ActionResult<TblRoom>> DeleteRoom(int id);
        public Task<ActionResult<TblRoom>> AddRoom(TblRoom room);
        public Task<ActionResult<TblRoom>> UpdateRoom(int id, TblRoom room);
        public Task<ActionResult<TblRoom>> GetRoomById(int id);

    }
}
