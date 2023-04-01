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
    public class TblInquiriesController : ControllerBase
    {

        private readonly IInquiries _inquriyService;

        public TblInquiriesController(IInquiries inquriyService)
        {
            _inquriyService = inquriyService;
        }

        // GET: api/TblInquiry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInquiry>>> GetInquirys()
        {
            return await _inquriyService.GetAllInquirys();
        }

        // GET: api/TblInquiry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInquiry>> GetTblInquiryById(int id)
        {
            var inquiry = await _inquriyService.GetInquiryById(id);
            return inquiry == null ? NotFound() : Ok(inquiry);

        }

        // PUT: api/TblInquiry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInquiry(int id, TblInquiry inquiry)
        {
            try
            {
                await _inquriyService.UpdateInquiry(id, inquiry);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/TblInquiry
        [HttpPost]
        public async Task<ActionResult<TblInquiry>> AddInquiry(TblInquiry inquiry)
        {
            try
            {
                ActionResult<TblInquiry> inquiryRes = await _inquriyService.AddInquiry(inquiry);

                if (inquiryRes== null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddInquiry", new { id = inquiry.IdInquirie }, inquiry);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblInquiry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquiry(int id)
        {
            try
            {
                await _inquriyService.DeleteInquiry(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
