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
    public class TblWorkHoursController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblWorkHoursController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblWorkHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblWorkHour>>> GetTblWorkHours()
        {
            return await _context.TblWorkHours.ToListAsync();
        }

        // GET: api/TblWorkHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblWorkHour>> GetTblWorkHour(int id)
        {
            var tblWorkHour = await _context.TblWorkHours.FindAsync(id);

            if (tblWorkHour == null)
            {
                return NotFound();
            }

            return tblWorkHour;
        }

        // PUT: api/TblWorkHours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblWorkHour(int id, TblWorkHour tblWorkHour)
        {
            if (id != tblWorkHour.IdWorkHours)
            {
                return BadRequest();
            }

            _context.Entry(tblWorkHour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblWorkHourExists(id))
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

        // POST: api/TblWorkHours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblWorkHour>> PostTblWorkHour(TblWorkHour tblWorkHour)
        {
            _context.TblWorkHours.Add(tblWorkHour);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblWorkHourExists(tblWorkHour.IdWorkHours))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblWorkHour", new { id = tblWorkHour.IdWorkHours }, tblWorkHour);
        }

        // DELETE: api/TblWorkHours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblWorkHour(int id)
        {
            var tblWorkHour = await _context.TblWorkHours.FindAsync(id);
            if (tblWorkHour == null)
            {
                return NotFound();
            }

            _context.TblWorkHours.Remove(tblWorkHour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblWorkHourExists(int id)
        {
            return _context.TblWorkHours.Any(e => e.IdWorkHours == id);
        }
    }
}
