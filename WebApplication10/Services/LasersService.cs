using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Gproject.Interfaces;
using System.Linq;

namespace Gproject.Services
{
    public class LasersService : ILasers
    {
        private readonly DataProjectContext _context;

        public LasersService(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblEmployees 

        public async Task<ActionResult<IEnumerable<TblLaser>>> GetAllLasers()
        {
            return await _context.TblLasers.ToListAsync();
        }

        // GET: api/TblLaser/5  - by id 
        public async Task<ActionResult<TblLaser>> GetLaserById(int id)
        {
            TblLaser laser = await _context.TblLasers.FirstOrDefaultAsync(c => c.IdLaser == id);

            if (laser == null)
            {
                throw new Exception("This laser is not valid!");
            }
            return laser;
        }

        // PUT: api/TblLaser/5  update laser by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblLaser>> UpdateLaser(int id, TblLaser laser)
        {
            if (id != laser.IdLaser)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetLaserById(laser.IdLaser) == null)
            {

                throw new Exception("This Laser is not Exsit!");
            }

            _context.Entry(laser).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return laser;
        }

        // POST: api/TblLaser  add new TblLaser
        [HttpPost]
        public async Task<ActionResult<TblLaser>> AddLaser(TblLaser laser)
        {

            _context.TblLasers.Add(laser);

            await _context.SaveChangesAsync();

            if (!laserExists(laser.IdLaser))
            {
                throw new Exception("the laser not succfull to Add");
            }


            return laser;
        }

        // DELETE: api/TblLaser/5  delete laser by id
        public async Task<ActionResult<TblLaser>> DeleteLaser(int id)
        {
            var laser = findLaser(id);
            if (laser == null)
            {
                throw new Exception("This Room is not valid!");
            }

            _context.TblLasers.Remove(laser);
            await _context.SaveChangesAsync();

            return laser;
        }

        private bool laserExists(int id)
        {
            return _context.TblLasers.Any(e => e.IdLaser == id);
        }

        private TblLaser findLaser(int id)
        {
            return _context.TblLasers.FirstOrDefault(c => c.IdLaser == id);
        }
    }
}
