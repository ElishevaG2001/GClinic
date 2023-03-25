using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IContacts
    {
        public Task<ActionResult<IEnumerable<Contact>>> GetAllContacts();
        public Task<ActionResult<Contact>> GetContactById(int id);
        public Task<ActionResult<Contact>> AddContact(Contact contact);
        public Task<ActionResult<Contact>> DeleteContact(int id);
        public Task<ActionResult<Contact>> UpdateContact(int id, Contact contact);
    }
}
