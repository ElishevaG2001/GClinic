using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblEmployeesController : ControllerBase
    {

        private readonly IEmployees _employeeService;

        public TblEmployeesController(IEmployees employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/TblEmployees 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> GetAllTblEmployees()
        {
            return Ok(await _employeeService.GetAllTblEmployees());
        }

        // GET: api/TblEmployees/5  - by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployee>> GetTblEmployeeById(int id)
        {
            var employee = await _employeeService.GetTblEmployeeById(id);

            return employee == null ? NotFound() : Ok(employee);
        }

        // PUT: api/TblEmployees/5  update employee by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTblEmployee(int id, TblEmployee employee)
        {
            try
            {
                await _employeeService.UpdateTblEmployee(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("The Employee is not Update!!!");
            }
            return NoContent();
        }

        // POST: api/TblEmployees  add new employee
        [HttpPost]
        public async Task<ActionResult<TblEmployee>> AddEmployee(TblEmployee employee)
        {
            try
            {
                ActionResult<TblEmployee> employeeRes = await _employeeService.AddTblEmployee(employee);
                if (employeeRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddEmployee", new { id = employee.IdEmployee }, employee);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");

            }
        }

        // DELETE: api/TblEmployees/5  delete employee by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteTblEmployee(id);
            }

            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
