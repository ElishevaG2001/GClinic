using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;
using Gproject.Interfaces;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblWorkHoursController : ControllerBase
    {

        private readonly IWorkHours _WorkHoursService;

        public TblWorkHoursController(IWorkHours WorkHoursService)
        {
            _WorkHoursService = WorkHoursService;
        }

        // GET: api/TblWorkHour
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblWorkHour>>> GetWorkHours()
        {
            return await _WorkHoursService.GetAllWorkHours();
        }

        // GET: api/TblWorkHour/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblWorkHour>> GetWorkHour(int id)
        {
            var workHour = await _WorkHoursService.GetWorkHourById(id);
            return workHour == null ? NotFound() : Ok(workHour);

        }

        // PUT: api/TblWorkHour/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkHour(int id, TblWorkHour workHour)
        {
            try
            {
                await _WorkHoursService.UpdateWorkHour(id, workHour);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/TblWorkHour
        [HttpPost]
        public async Task<ActionResult<TblWorkHour>> AddWorkHour(TblWorkHour workHour)
        {
            try
            {
                ActionResult<TblWorkHour> workHourRes = await _WorkHoursService.AddWorkHour(workHour);

                if (workHourRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddWorkHour", new { id = workHour.IdWorkHours }, workHour);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblWorkHour/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkHour(int id)
        {
            try
            {
                await _WorkHoursService.DeleteWorkHour(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
