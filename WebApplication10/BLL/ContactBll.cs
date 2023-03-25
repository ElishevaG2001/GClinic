//using Gproject.DataDB;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication10.Controllers;

//using System;
//using Microsoft.AspNetCore.Http;

//namespace Gproject.Bll_Dal
//{
//    public class ContactBll
//    {
//        private readonly DataProjectContext _context;

//        public ContactBll(DataProjectContext context)
//        {
//            _context = context;
//        }


//        // GET: api/Contacts  get all contacts
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
//        {
//            return await _context.Contacts.ToListAsync();
//        }

//        // GET: api/Contacts/5   get contact by id
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Contact>> GetContactById(int id)
//        {
//            return  await _context.Contacts.FirstOrDefaultAsync(u => u.IdContacts == id);
//        }

//        // PUT: api/Contacts/5 update the contact by id 
//        //        [HttpPut("{id}")]
//        //        public async Task<IActionResult> UpdateContact(int id, Contact contact)
//        //        {

//        //            _context.Entry(contact).State = EntityState.Modified;
//        //            try
//        //            {
//        //                await _context.SaveChangesAsync();
//        //            }
//        //            catch (DbUpdateConcurrencyException)
//        //            {
//        //                if (!ContactExists(id))
//        //                {
//        //                    return NotFound();
//        //                }
//        //                else
//        //                {
//        //                    throw;
//        //                }
//        //            }

//        //            return NoContent();
//        //        }

//        //        // POST: api/Contacts   add new contact
//        //        [HttpPost]
//        //        public async Task<ActionResult<Contact>> AddContact(Contact contact)
//        //        {
//        //            _context.Contacts.Add(contact);
//        //            try
//        //            {
//        //                await _context.SaveChangesAsync();
//        //            }
//        //            catch (DbUpdateException)
//        //            {
//        //                if (ContactExists(contact.IdContacts))
//        //                {
//        //                    return Conflict();
//        //                }
//        //                else
//        //                {
//        //                    throw;
//        //                }
//        //            }

//        //            return CreatedAtAction("GetContact", new { id = contact.IdContacts }, contact);
//        //        }

//        //        // DELETE: api/Contacts/5
//        //        [HttpDelete("{id}")]
//        //        public async Task<IActionResult> DeleteContact(int id)
//        //        {
//        //            var contact = await _context.Contacts.FindAsync(id);
//        //            if (contact == null)
//        //            {
//        //                return NotFound();
//        //            }

//        //            _context.Contacts.Remove(contact);
//        //            await _context.SaveChangesAsync();

//        //            return NoContent();
//        //        }

//        //        private bool ContactExists(int id)
//        //        {
//        //            return _context.Contacts.Any(e => e.IdContacts == id);
//        //        }
//    }
//}

