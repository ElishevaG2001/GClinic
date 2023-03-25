using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblLasersController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblLasersController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblLasers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLaser>>> GetTblLasers()
        {
            return await _context.TblLasers.ToListAsync();
        }

        // GET: api/TblLasers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLaser>> GetTblLaser(int id)
        {
            var tblLaser = await _context.TblLasers.FindAsync(id);

            if (tblLaser == null)
            {
                return NotFound();
            }

            return tblLaser;
        }

        // PUT: api/TblLasers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLaser(int id, TblLaser tblLaser)
        {
            if (id != tblLaser.IdLaser)
            {
                return BadRequest();
            }

            _context.Entry(tblLaser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLaserExists(id))
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

        // POST: api/TblLasers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLaser>> PostTblLaser(TblLaser tblLaser)
        {
            _context.TblLasers.Add(tblLaser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblLaserExists(tblLaser.IdLaser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblLaser", new { id = tblLaser.IdLaser }, tblLaser);
        }

        // DELETE: api/TblLasers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLaser(int id)
        {
            var tblLaser = await _context.TblLasers.FindAsync(id);
            if (tblLaser == null)
            {
                return NotFound();
            }

            _context.TblLasers.Remove(tblLaser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLaserExists(int id)
        {
            return _context.TblLasers.Any(e => e.IdLaser == id);
        }
    }
}
