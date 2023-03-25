
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
    public class ContactsService : IContacts
    {

        private readonly DataProjectContext _context;

        public ContactsService(DataProjectContext context)
        {

            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/5   get contact by id
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(u => u.IdContacts == id);
        }

        // POST: api/Contacts   add new contact
        public async Task<ActionResult<Contact>> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);

            await _context.SaveChangesAsync();

            return findContacts(contact.IdContacts);
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.IdContacts == id);
        }



        //find contact if exsists & rerun the contact or null 
        private Contact findContacts(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.IdContacts == id);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {

            Contact contact =  findContacts(id);
           
            if (contact == null)
            {
                throw new Exception("This Contact is not valid!");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }


        // PUT: api/Contacts/5 update the contact by id 
        public async Task<ActionResult<Contact>> UpdateContact(int id, Contact contact)
        { 
            if (id != contact.IdContacts)
            {
                throw new Exception("erro with the parameter Id");
            }

            if(findContacts(contact.IdContacts) == null)
            {

                throw new Exception("This Contact is not Exsit!");
            }

            _context.Entry(contact).State = EntityState.Modified;

            await _context.SaveChangesAsync();
         
            return contact;
        }


    }
}
