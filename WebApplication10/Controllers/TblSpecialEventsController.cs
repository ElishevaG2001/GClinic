using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10.DataDB;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblSpecialEventsController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblSpecialEventsController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblSpecialEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSpecialEvent>>> GetTblSpecialEvents()
        {
            return await _context.TblSpecialEvents.ToListAsync();
        }

        // GET: api/TblSpecialEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSpecialEvent>> GetTblSpecialEvent(int id)
        {
            var tblSpecialEvent = await _context.TblSpecialEvents.FindAsync(id);

            if (tblSpecialEvent == null)
            {
                return NotFound();
            }

            return tblSpecialEvent;
        }

        // PUT: api/TblSpecialEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSpecialEvent(int id, TblSpecialEvent tblSpecialEvent)
        {
            if (id != tblSpecialEvent.IdSpecialEvents)
            {
                return BadRequest();
            }

            _context.Entry(tblSpecialEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSpecialEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblSpecialEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSpecialEvent>> PostTblSpecialEvent(TblSpecialEvent tblSpecialEvent)
        {
            _context.TblSpecialEvents.Add(tblSpecialEvent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblSpecialEventExists(tblSpecialEvent.IdSpecialEvents))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblSpecialEvent", new { id = tblSpecialEvent.IdSpecialEvents }, tblSpecialEvent);
        }

        // DELETE: api/TblSpecialEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSpecialEvent(int id)
        {
            var tblSpecialEvent = await _context.TblSpecialEvents.FindAsync(id);
            if (tblSpecialEvent == null)
            {
                return NotFound();
            }

            _context.TblSpecialEvents.Remove(tblSpecialEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSpecialEventExists(int id)
        {
            return _context.TblSpecialEvents.Any(e => e.IdSpecialEvents == id);
        }
    }
}
