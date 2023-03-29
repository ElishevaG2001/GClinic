using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gproject.DataDB;
using Gproject.Interfaces;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblTreatsController : ControllerBase
    {
        private ITreats _treatService;

        public TblTreatsController(ITreats treatService)
        {
            _treatService = treatService;
        }

        // GET: api/Contacts  get all treats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTreat>>> GetTreats()
        {
            return Ok(await _treatService.GetAllTreats());
        }

        // GET: api/Contacts/5   get treat by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTreat>> GetTreatById(int id)
        {
            var treat = await _treatService.GettTreatById(id);

            return treat == null ? NotFound() : Ok(treat);
        }

        //// PUT: api/Contacts/5 update the treat by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTreat(int id, TblTreat treat)
        {
            try
            {
                await _treatService.UpdateTreat(id, treat);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new Exception("This it not upDate ");
            }
            return NoContent();
        }

        // POST: api/Contacts   add new treat
        [HttpPost]
        public async Task<ActionResult<Contact>> AddTreat(TblTreat treat)
        {

            try
            {
                ActionResult<TblTreat> treattRes = await _treatService.AddTreat(treat);

                if (treattRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddTreat", new { id = treat.IdTreat }, treat);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/Contacts/5 delete by id 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreat(int id)
        {
            try
            {
                await _treatService.DeleteTreat(id);

            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
