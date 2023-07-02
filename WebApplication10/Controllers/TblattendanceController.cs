using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Gproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblattendanceController : ControllerBase
    {

        private readonly IAttendance _attendanceService;

        public TblattendanceController(IAttendance attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/Tblattendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblattendance>>> GetAttendances()
        {
            return await _attendanceService.GetAllAttendances();
        }

        // GET: api/Tblattendance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblattendance>> GetATblattendance(int id)
        {
            var room = await _attendanceService.GetAttendanceById(id);
            return room == null ? NotFound() : Ok(room);

        }

        // PUT: api/Tblattendance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, Tblattendance attendance)
        {
            try
            {
                await _attendanceService.UpdateAttendance(id, attendance);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/Tblattendance
        [HttpPost]
        public async Task<ActionResult<Tblattendance>> AddAttendance(Tblattendance attendance)
        {
            try
            {
                ActionResult<Tblattendance> attendanceRes = await _attendanceService.AddAttendance(attendance);

                if (attendanceRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddAttendance", new { id = attendance.id_attendance }, attendance);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            try
            {
                await _attendanceService.DeleteAttendance(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
