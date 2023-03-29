using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Gproject.Interfaces;

namespace Gproject.Services
{
    public class IinquiriesService  : IInquiries
    {
        private readonly DataProjectContext _context;

        public IinquiriesService(DataProjectContext context)
        {
            _context = context;
        }

        // GET: api/TblInquiry 

        public async Task<ActionResult<IEnumerable<TblInquiry>>> GetAllInquirys()
        {
            return await _context.TblInquiries.ToListAsync();
        }

        // GET: api/TblInquiry/5  - by id 
        public async Task<ActionResult<TblInquiry>> GetInquiryById(int id)
        {
            TblInquiry inquiry = await _context.TblInquiries.FirstOrDefaultAsync(c => c.IdInquirie == id);

            if (inquiry == null)
            {
                throw new Exception("This inqurty is not valid!");
            }
            return inquiry;
        }

        // PUT: api/TblInquiry/5  update Inquiry by id 
        [HttpPut("{id}")]
        public async Task<ActionResult<TblInquiry>> UpdateInquiry(int id, TblInquiry inquiry)
        {
            if (id != inquiry.IdInquirie)
            {
                throw new Exception("erro with the parameter Id");
            }

            if (GetInquiryById(inquiry.IdInquirie) == null)
            {

                throw new Exception("This Inquiry is not Exsit!");
            }

            _context.Entry(inquiry).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return inquiry;
        }

        // POST: api/TblInquiry  add new TblInquiry
        [HttpPost]
        public async Task<ActionResult<TblInquiry>> AddInquiry(TblInquiry inquiry)
        {

            _context.TblInquiries.Add(inquiry);

            await _context.SaveChangesAsync();

            if (!InquiryExists(inquiry.IdInquirie))
            {
                throw new Exception("the Inquiry not succfull to Add");
            }


            return inquiry;
        }

        // DELETE: api/TblInquiry/5  delete TblInquiry by id
        public async Task<ActionResult<TblInquiry>> DeleteInquiry(int id)
        {
            var inquiry = findInquiry(id);
            if (inquiry == null)
            {
                throw new Exception("This inquiry is not valid!");
            }

            _context.TblInquiries.Remove(inquiry);
            await _context.SaveChangesAsync();

            return inquiry;
        }

        private bool InquiryExists(int id)
        {
            return _context.TblInquiries.Any(e => e.IdInquirie == id);
        }

        private TblInquiry findInquiry(int id)
        {
            return _context.TblInquiries.FirstOrDefault(c => c.IdInquirie == id);
        }
    }
}
