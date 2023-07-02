using Gproject.DataDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gproject.Interfaces
{
    public interface IInquiries
    {
        public Task<ActionResult<IEnumerable<TblInquiry>>> GetAllInquirys();
        public Task<ActionResult<TblInquiry>> DeleteInquiry(int id);
        public Task<ActionResult<TblInquiry>> AddInquiry(TblInquiry room);
        public Task<ActionResult<TblInquiry>> UpdateInquiry(int id, TblInquiry room);
        public Task<ActionResult<TblInquiry>> GetInquiryById(int id);
    }
}
