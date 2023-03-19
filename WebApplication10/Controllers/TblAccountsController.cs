using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10.DataDB;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Policy = "1")]



    public class TblAccountsController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblAccountsController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblAccounts
        [HttpGet]

        public async Task<ActionResult<IEnumerable<TblAccount>>> GetTblAccounts()
        {
            //return await _context.TblAccounts.ToListAsync();
            return null;

        }

        // GET: api/TblAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAccount>> GetTblAccount(int id)
        {
            var tblAccount = await _context.TblAccounts.FindAsync(id);

            if (tblAccount == null)
            {
                return NotFound();
            }

            return tblAccount;
        }

        // PUT: api/TblAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAccount(int id, TblAccount tblAccount)
        {
            if (id != tblAccount.IdAccount)
            {
                return BadRequest();
            }

            _context.Entry(tblAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAccountExists(id))
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

        // POST: api/TblAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAccount>> PostTblAccount(TblAccount tblAccount)
        {
            _context.TblAccounts.Add(tblAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblAccountExists(tblAccount.IdAccount))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblAccount", new { id = tblAccount.IdAccount }, tblAccount);
        }

        // DELETE: api/TblAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAccount(int id)
        {
            var tblAccount = await _context.TblAccounts.FindAsync(id);
            if (tblAccount == null)
            {
                return NotFound();
            }

            _context.TblAccounts.Remove(tblAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblAccountExists(int id)
        {
            return _context.TblAccounts.Any(e => e.IdAccount == id);
        }
    }
}
