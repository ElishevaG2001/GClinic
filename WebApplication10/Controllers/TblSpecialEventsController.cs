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
    public class TblSpecialEventsController : ControllerBase
    {

        private  ISpecialEvents _specialEventService;

        public TblSpecialEventsController(ISpecialEvents specialEventService)
        {
            _specialEventService = specialEventService;
        }

        // GET: api/TblSpecialEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSpecialEvent>>> GetSpecialEvent()
        {
            return await _specialEventService.GetAllSpecialEvents();
        }

        // GET: api/TblSpecialEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSpecialEvent>> GetSpecialEventById(int id)
        {
            var specialEvent = await _specialEventService.GetSpecialEventById(id);
            return specialEvent == null ? NotFound() : Ok(specialEvent);

        }

        // PUT: api/TblSpecialEvent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialEvent(int id, TblSpecialEvent specialEvent)
        {
            try
            {
                await _specialEventService.UpdateSpecialEvent(id, specialEvent);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/TblSpecialEvent
        [HttpPost]
        public async Task<ActionResult<TblSpecialEvent>> AddSpecialEvent(TblSpecialEvent specialEvent)
        {
            try
            {
                ActionResult<TblSpecialEvent> specialEventRes = await _specialEventService.AddSpecialEvent(specialEvent);

                if (specialEvent == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddSpecialEvent", new { id =    specialEvent.IdSpecialEvents }, specialEvent);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblSpecialEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialEvent(int id)
        {
            try
            {
                await _specialEventService.DeleteSpecialEvent(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
