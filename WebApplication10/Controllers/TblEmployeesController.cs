using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gproject.DataDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblEmployeesController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblEmployeesController(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblEmployees 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> GetAllTblEmployees()
        { 
                 return await _context.TblEmployees.ToListAsync();
        }

        // GET: api/TblEmployees/5  - by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployee>> GetTblEmployeeById(int id)
        {
            var tblEmployee = await _context.TblEmployees.FindAsync(id);

            if (tblEmployee == null)
            {
                return NotFound();
            }

            return tblEmployee;
        }

        // PUT: api/TblEmployees/5  update employee by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTblEmployee(int id, TblEmployee tblEmployee)
        {
            if (id != tblEmployee.IdEmployee)
            {
                return BadRequest("no");
            }

            _context.Entry(tblEmployee).State = EntityState.Modified;

            try
            {
                //save the changes
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeExists(id))
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

        // POST: api/TblEmployees  add new employee
        [HttpPost]
        public async Task<ActionResult<TblEmployee>> AddTblEmployee(TblEmployee tblEmployee)
        {

            _context.TblEmployees.Add(tblEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblEmployeeExists(tblEmployee.IdEmployee))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("AddTblEmployee", new { id = tblEmployee.IdEmployee }, tblEmployee);
        }

        // DELETE: api/TblEmployees/5  delete employee by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEmployee(int id)
        {
            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            _context.TblEmployees.Remove(tblEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblEmployeeExists(int id)
        {
            return _context.TblEmployees.Any(e => e.IdEmployee == id);
        }
    }
}
