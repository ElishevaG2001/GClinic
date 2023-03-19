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
    public class TblInquiriesController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblInquiriesController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblInquiries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInquiry>>> GetTblInquiries()
        {
            return await _context.TblInquiries.ToListAsync();
        }

        // GET: api/TblInquiries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInquiry>> GetTblInquiry(int id)
        {
            var tblInquiry = await _context.TblInquiries.FindAsync(id);

            if (tblInquiry == null)
            {
                return NotFound();
            }

            return tblInquiry;
        }

        // PUT: api/TblInquiries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInquiry(int id, TblInquiry tblInquiry)
        {
            if (id != tblInquiry.IdInquirie)
            {
                return BadRequest();
            }

            _context.Entry(tblInquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInquiryExists(id))
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

        // POST: api/TblInquiries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblInquiry>> PostTblInquiry(TblInquiry tblInquiry)
        {
            _context.TblInquiries.Add(tblInquiry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblInquiryExists(tblInquiry.IdInquirie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblInquiry", new { id = tblInquiry.IdInquirie }, tblInquiry);
        }

        // DELETE: api/TblInquiries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblInquiry(int id)
        {
            var tblInquiry = await _context.TblInquiries.FindAsync(id);
            if (tblInquiry == null)
            {
                return NotFound();
            }

            _context.TblInquiries.Remove(tblInquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblInquiryExists(int id)
        {
            return _context.TblInquiries.Any(e => e.IdInquirie == id);
        }
    }
}
