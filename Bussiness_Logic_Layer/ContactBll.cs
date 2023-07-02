using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Controllers;

namespace Gproject.Bll_Dal
{
    public class ContactBll
    {
        private readonly DataProjectContext _context;
       
        public ContactBll(DataProjectContext context)
        {
            _context = context;
        }


        // GET: api/Contacts  get all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

    }
}
