using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;
using Gproject.Interfaces;
using Gproject.Services;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblRoomsController : ControllerBase
    {
        private readonly IRoom  _roomService;

        public TblRoomsController(IRoom roomService)
        {
            _roomService = roomService;
        }

        // GET: api/TblRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRoom>>> GetTblRooms()
        {
            return await _roomService.GetAllRooms();
        }

        // GET: api/TblRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRoom>> GetTblRoom(int id)
        {
            var room = await _roomService.GetRoomById(id);
            return room == null ? NotFound() : Ok(room);

        }

        // PUT: api/TblRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, TblRoom room)
        {
            try
            {
                await _roomService.UpdateRoom(id, room);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/TblRooms
        [HttpPost]
        public async Task<ActionResult<TblRoom>> AddRoom(TblRoom room)
        {
            try
            {
                ActionResult<TblRoom> roomRes = await _roomService.AddRoom(room);

                if (roomRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddRoom", new { id = room.IdRoom }, room);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRoom(int id)
        {
            try
            {
                await _roomService.DeleteRoom(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
