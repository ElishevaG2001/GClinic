using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gproject.Services
{
    public class EmployeesService : IEmployees
    {
        private readonly DataProjectContext _context;

        public EmployeesService(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblEmployees 

        public async Task<ActionResult<IEnumerable<TblEmployee>>> GetAllTblEmployees()
        {
            return await _context.TblEmployees.ToListAsync();
        }

        // GET: api/TblEmployees/5  - by id 
        public async Task<ActionResult<TblEmployee>> GetTblEmployeeById(int id)
        {
            TblEmployee tblEmployee =  await _context.TblEmployees.FirstOrDefaultAsync(c => c.IdEmployee == id);

            if (tblEmployee == null)
            {
                 throw new Exception("This Employee is not valid!");
            }
            return tblEmployee;
        }

        // PUT: api/TblEmployees/5  update employee by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblEmployee>> UpdateTblEmployee(int id, TblEmployee employee)
        {
            if (id != employee.IdEmployee)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetTblEmployeeById(employee.IdEmployee) == null)
            {

                throw new Exception("This Contact is not Exsit!");
            }

            _context.Entry(employee).State = EntityState.Modified;

             await _context.SaveChangesAsync();
            
            return employee;
        }

        // POST: api/TblEmployees  add new employee
        [HttpPost]
        public async Task<ActionResult<TblEmployee>> AddTblEmployee(TblEmployee employee)
        {

            _context.TblEmployees.Add(employee);
           
             await _context.SaveChangesAsync();
            
            if (!TblEmployeeExists(employee.IdEmployee))
            {
                    throw new Exception("the emloyee not succfull to Add");
             }
               

            return employee;
        }

        // DELETE: api/TblEmployees/5  delete employee by id
        public async Task<ActionResult<TblEmployee>> DeleteTblEmployee(int id)
        {
            var employee = findContacts(id);
            if (employee == null)
            {
                throw new Exception("This Employee is not valid!");
            }

            _context.TblEmployees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool TblEmployeeExists(int id)
        {
            return _context.TblEmployees.Any(e => e.IdEmployee == id);
        }

        private TblEmployee findContacts(int id)
        {
            return _context.TblEmployees.FirstOrDefault(c => c.IdEmployee == id);
        }
    }
}
