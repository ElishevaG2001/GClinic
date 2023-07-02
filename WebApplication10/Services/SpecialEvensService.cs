using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Gproject.Services
{
    public class SpecialEvensService : ISpecialEvents
    {
        private readonly DataProjectContext _context;

        public SpecialEvensService(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblSpecialEvent 

        public async Task<ActionResult<IEnumerable<TblSpecialEvent>>> GetAllSpecialEvents()
        {
            return await _context.TblSpecialEvents.ToListAsync();
        }

        // GET: api/TblSpecialEvent/5  - by id 
        public async Task<ActionResult<TblSpecialEvent>> GetSpecialEventById(int id)
        {
            TblSpecialEvent specialEvent = await _context.TblSpecialEvents.FirstOrDefaultAsync(c => c.IdSpecialEvents == id);

            if (specialEvent == null)
            {
                throw new Exception("This Event is not valid!");
            }
            return specialEvent;
        }

        // PUT: api/TblSpecialEvent/5  update Special Event by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblSpecialEvent>> UpdateSpecialEvent(int id, TblSpecialEvent specialEvent)
        {
            if (id != specialEvent.IdSpecialEvents)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetSpecialEventById(specialEvent.IdSpecialEvents) == null)
            {

                throw new Exception("This Event is not Exsit!");
            }

            _context.Entry(specialEvent).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return specialEvent;
        }

        // POST: api/TblSpecialEvent  add new Event
        [HttpPost]
        public async Task<ActionResult<TblSpecialEvent>> AddSpecialEvent(TblSpecialEvent specialEvent)
        {

            _context.TblSpecialEvents.Add(specialEvent);

            await _context.SaveChangesAsync();

            if (!SpecialEventExists(specialEvent.IdSpecialEvents))
            {
                throw new Exception("the Event not succfull to Add");
            }


            return specialEvent;
        }

        // DELETE: api/TblSpecialEvent/5  delete Event by id
        public async Task<ActionResult<TblSpecialEvent>> DeleteSpecialEvent(int id)
        {
            var specialEvent = findSpecialEvent(id);
            if (specialEvent == null)
            {
                throw new Exception("This Event is not valid!");
            }

            _context.TblSpecialEvents.Remove(specialEvent);
            await _context.SaveChangesAsync();

            return specialEvent;
        }

        private bool SpecialEventExists(int id)
        {
            return _context.TblSpecialEvents.Any(e => e.IdSpecialEvents == id);
        }

        private TblSpecialEvent findSpecialEvent(int id)
        {
            return _context.TblSpecialEvents.FirstOrDefault(c => c.IdSpecialEvents == id);
        }
    }
}
