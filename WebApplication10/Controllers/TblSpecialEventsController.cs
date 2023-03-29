using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblSpecialEventsController : ControllerBase
    {
        private readonly DataProjectContext _context;

        public TblSpecialEventsController(DataProjectContext context)
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
            TblSpecialEvent eventS = await _context.TblSpecialEvents.FirstOrDefaultAsync(c => c.IdSpecialEvents == id);

            if (eventS== null)
            {
                throw new Exception("This Special Event is not valid!");
            }
            return eventS;
        }

        // PUT: api/TblSpecialEvent/5  update SpecialEvent by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblSpecialEvent>> UpdateRoom(int id, TblSpecialEvent specialEvent)
        {
            if (id != specialEvent.IdSpecialEvents)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetSpecialEventById(specialEvent.IdSpecialEvents) == null)
            {

                throw new Exception("This Special Event is not Exsit!");
            }

            _context.Entry(specialEvent).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return specialEvent;
        }

        // POST: api/TblSpecialEvent  add new special Event
        [HttpPost]
        public async Task<ActionResult<TblSpecialEvent>> AddSpecialEvent(TblSpecialEvent specialEvent)
        {

            _context.TblSpecialEvents.Add(specialEvent);

            await _context.SaveChangesAsync();

            if (!SpecialEventExists(specialEvent.IdSpecialEvents))
            {
                throw new Exception("the specia lEvent not succfull to Add");
            }


            return specialEvent;
        }

        // DELETE: api/TblSpecialEvent/5  delete special Event by id
        public async Task<ActionResult<TblSpecialEvent>> DeleteSpecialEvent(int id)
        {
            var secialEvent = findSpecialEvent(id);
            if (secialEvent == null)
            {
                throw new Exception("This Room is not valid!");
            }

            _context.TblSpecialEvents.Remove(secialEvent);
            await _context.SaveChangesAsync();

            return secialEvent;
        }

        private bool SpecialEventExists(int id)
        {
            return _context.TblSpecialEvents.Any(e => e.IdSpecialEvents== id);
        }

        private TblSpecialEvent findSpecialEvent(int id)
        {
            return _context.TblSpecialEvents.FirstOrDefault(c => c.IdSpecialEvents == id);
        }
    }
}
