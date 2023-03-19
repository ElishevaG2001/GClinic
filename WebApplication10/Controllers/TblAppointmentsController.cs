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
    public class TblAppointmentsController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblAppointmentsController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAppointment>>> GetTblAppointments()
        {
            return await _context.TblAppointments.ToListAsync();
        }

        // GET: api/TblAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAppointment>> GetTblAppointment(int id)
        {
            var tblAppointment = await _context.TblAppointments.FindAsync(id);

            if (tblAppointment == null)
            {
                return NotFound();
            }

            return tblAppointment;
        }

        // PUT: api/TblAppointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAppointment(int id, TblAppointment tblAppointment)
        {
            if (id != tblAppointment.IdAppointment)
            {
                return BadRequest();
            }

            _context.Entry(tblAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAppointmentExists(id))
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

        // POST: api/TblAppointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAppointment>> PostTblAppointment(TblAppointment tblAppointment)
        {
            _context.TblAppointments.Add(tblAppointment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblAppointmentExists(tblAppointment.IdAppointment))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblAppointment", new { id = tblAppointment.IdAppointment }, tblAppointment);
        }

        // DELETE: api/TblAppointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAppointment(int id)
        {
            var tblAppointment = await _context.TblAppointments.FindAsync(id);
            if (tblAppointment == null)
            {
                return NotFound();
            }

            _context.TblAppointments.Remove(tblAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblAppointmentExists(int id)
        {
            return _context.TblAppointments.Any(e => e.IdAppointment == id);
        }
    }
}
