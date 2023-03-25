using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;
//using Gproject.Bll_Dal;
using Gproject.Interfaces;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContacts _contactsService;

        public ContactsController(IContacts contactsService)
        {
           _contactsService = contactsService;
        }

        // GET: api/Contacts  get all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactsService.GetAllContacts());
        }

        // GET: api/Contacts/5   get contact by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact =  await _contactsService.GetContactById(id);

            return contact == null ? NotFound() : Ok(contact);
        }

        //// PUT: api/Contacts/5 update the contact by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            try
            {
                await _contactsService.UpdateContact(id, contact);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new Exception("This it not upDate ");
            }
            return NoContent();
        }

        // POST: api/Contacts   add new contact
        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Contact contact)
        {

            try
            { 
                ActionResult<Contact> contactRes = await _contactsService.AddContact(contact);
      
                if (contactRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddContact", new { id = contact.IdContacts }, contact);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/Contacts/5 delete by id 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactsService.DeleteContact(id);

            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }

    }
}
