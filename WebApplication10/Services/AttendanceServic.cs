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
    public class AttendanceServic : IAttendance
    {
        private readonly DataProjectContext _context;

        public AttendanceServic(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/Tblattendance 

        public async Task<ActionResult<IEnumerable<Tblattendance>>> GetAllAttendances()
        {
            return await _context.Tblattendance.ToListAsync();
        }

        // GET: api/Tblattendance/5  - by id 
        public async Task<ActionResult<Tblattendance>> GetAttendanceById(int id)
        {
            Tblattendance attendance = await _context.Tblattendance.FirstOrDefaultAsync(c => c.id_attendance == id);

            if (attendance == null)
            {
                throw new Exception("This attendance is not valid!");
            }
            return attendance;
        }

        // PUT: api/Tblattendance/5  update Tblattendance by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<Tblattendance>> UpdateAttendance(int id, Tblattendance attendance)
        {
            if (id != attendance.id_attendance)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetAttendanceById(attendance.id_attendance) == null)
            {

                throw new Exception("This attendance is not Exsit!");
            }

            _context.Entry(attendance).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return attendance;
        }

        // POST: api/Tblattendance  add new Tblattendance
        [HttpPost]
        public async Task<ActionResult<Tblattendance>> AddAttendance(Tblattendance attendance)
        {

            _context.Tblattendance.Add(attendance);

            await _context.SaveChangesAsync();

            if (!AttendanceExists(attendance.id_attendance))
            {
                throw new Exception("the attendance not succfull to Add");
            }


            return attendance;
        }

        // DELETE: api/Tblattendance/5  delete Tblattendance by id
        public async Task<ActionResult<Tblattendance>> DeleteAttendance(int id)
        {
            var attendance = findAttendance(id);
            if (attendance == null)
            {
                throw new Exception("This attendance is not valid!");
            }

            _context.Tblattendance.Remove(attendance);
            await _context.SaveChangesAsync();

            return attendance;
        }

        private bool AttendanceExists(int id)
        {
            return _context.Tblattendance.Any(e => e.id_attendance == id);
        }

        private Tblattendance findAttendance(int id)
        {
            return _context.Tblattendance.FirstOrDefault(c => c.id_attendance == id);
        }
    }
}
