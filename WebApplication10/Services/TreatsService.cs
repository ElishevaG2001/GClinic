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
    public class TreatsService : ITreats
    {       
            private readonly DataProjectContext _context;

            public TreatsService(DataProjectContext context)
            {

                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<TblTreat>>> GetAllTreats()
            {
                return await _context.TblTreats.ToListAsync();
            }

            // GET: api/Contacts/5   get contact by id
            public async Task<ActionResult<TblTreat>> GettTreatById(int id)
            {
                return await _context.TblTreats.FirstOrDefaultAsync(u => u.IdTreat == id);
            }

            // POST: api/Contacts   add new contact
            public async Task<ActionResult<TblTreat>> AddTreat(TblTreat treat)
            {
                _context.TblTreats.Add(treat);

                await _context.SaveChangesAsync();

                return findtreat(treat.IdTreat);
            }

            private bool treattExists(int id)
            {
                return _context.TblTreats.Any(e => e.IdTreat == id);
            }



            //find contact if exsists & rerun the contact or null 
            private TblTreat findtreat(int id)
            {
                return _context.TblTreats.FirstOrDefault(c => c.IdTreat == id);
            }

            // DELETE: api/Contacts/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<TblTreat>> DeleteTreat(int id)
            {

                TblTreat treat = findtreat(id);

                if (treat == null)
                {
                    throw new Exception("This Contact is not valid!");
                }

                _context.TblTreats.Remove(treat);
                await _context.SaveChangesAsync();

                return treat;
            }


            // PUT: api/Contacts/5 update the contact by id 
            public async Task<ActionResult<TblTreat>> UpdateTreat(int id, TblTreat treat)
            {
                if (id != treat.IdTreat)
                {
                    throw new Exception("erro with the parameter Id");
                }

                if (findtreat(treat.IdTreat) == null)
                {

                    throw new Exception("This Contact is not Exsit!");
                }

                _context.Entry(treat).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return treat;
            }


        }
    }

