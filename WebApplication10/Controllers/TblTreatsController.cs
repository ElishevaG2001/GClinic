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
    public class TblTreatsController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblTreatsController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblTreats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTreat>>> GetTblTreats()
        {
            return await _context.TblTreats.ToListAsync();
        }

        // GET: api/TblTreats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTreat>> GetTblTreat(int id)
        {
            var tblTreat = await _context.TblTreats.FindAsync(id);

            if (tblTreat == null)
            {
                return NotFound();
            }

            return tblTreat;
        }

        // PUT: api/TblTreats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTreat(int id, TblTreat tblTreat)
        {
            if (id != tblTreat.IdTreat)
            {
                return BadRequest();
            }

            _context.Entry(tblTreat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTreatExists(id))
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

        // POST: api/TblTreats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTreat>> PostTblTreat(TblTreat tblTreat)
        {
            _context.TblTreats.Add(tblTreat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblTreatExists(tblTreat.IdTreat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblTreat", new { id = tblTreat.IdTreat }, tblTreat);
        }

        // DELETE: api/TblTreats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTreat(int id)
        {
            var tblTreat = await _context.TblTreats.FindAsync(id);
            if (tblTreat == null)
            {
                return NotFound();
            }

            _context.TblTreats.Remove(tblTreat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTreatExists(int id)
        {
            return _context.TblTreats.Any(e => e.IdTreat == id);
        }
    }
}
