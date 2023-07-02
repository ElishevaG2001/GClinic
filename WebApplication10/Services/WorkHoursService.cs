using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Gproject.Interfaces;

namespace Gproject.Services
{
    public class WorkHoursService : IWorkHours
    {

        private readonly DataProjectContext _context;

        public WorkHoursService(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/WorkHour 

        public async Task<ActionResult<IEnumerable<TblWorkHour>>> GetAllWorkHours()
        {
            return await _context.TblWorkHours.ToListAsync();
        }

        // GET: api/TblWorkHours/5  - by id 
        public async Task<ActionResult<TblWorkHour>> GetWorkHourById(int id)
        {
            TblWorkHour workHour = await _context.TblWorkHours.FirstOrDefaultAsync(c => c.IdWorkHours == id);

            if (workHour == null)
            {
                throw new Exception("This workHour is not valid!");
            }
            return workHour;
        }

        // PUT: api/TblWorkHour/5  update WorkHour by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblWorkHour>> UpdateWorkHour(int id, TblWorkHour workHour)
        {
            if (id != workHour.IdWorkHours)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetWorkHourById(workHour.IdWorkHours) == null)
            {

                throw new Exception("This Work-Hour is not Exsit!");
            }

            _context.Entry(workHour).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return workHour;
        }

        // POST: api/TblWorkHour  add new employee
        [HttpPost]
        public async Task<ActionResult<TblWorkHour>> AddWorkHour(TblWorkHour workHour)
        {

            _context.TblWorkHours.Add(workHour);

            await _context.SaveChangesAsync();

            if (!TblWorkHourExists(workHour.IdWorkHours))
            {
                throw new Exception("the WorkHour not succfull to Add");
            }


            return workHour;
        }

        // DELETE: api/TblWorkHour/5  delete WorkHour by id
        public async Task<ActionResult<TblWorkHour>> DeleteWorkHour(int id)
        {
            var workHour = findWorkHour(id);
            if (workHour == null)
            {
                throw new Exception("This workHour is not valid!");
            }

            _context.TblWorkHours.Remove(workHour);
            await _context.SaveChangesAsync();

            return workHour;
        }

        private bool TblWorkHourExists(int id)
        {
            return _context.TblWorkHours.Any(e => e.IdWorkHours == id);
        }

        private TblWorkHour findWorkHour(int id)
        {
            return _context.TblWorkHours.FirstOrDefault(c => c.IdWorkHours == id);
        }
    }
}
