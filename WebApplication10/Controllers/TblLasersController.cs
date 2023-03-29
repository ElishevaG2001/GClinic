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
    public class TblLasersController : ControllerBase
    {

        private readonly ILasers _laserService;

        public TblLasersController(ILasers laserService)
        {
            _laserService = laserService;
        }

        // GET: api/Laser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLaser>>> GetLasers()
        {
            return await _laserService.GetAllLasers();
        }

        // GET: api/TblLaser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLaser>> GetLaserByID(int id)
        {
            var laser = await _laserService.GetLaserById(id);
            return laser == null ? NotFound() : Ok(laser);

        }

        // PUT: api/TblLaser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaser(int id, TblLaser laser)
        {
            try
            {
                await _laserService.UpdateLaser(id, laser);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("This it not upDate ");
            }

            return NoContent();
        }

        // POST: api/TblLaser
        [HttpPost]
        public async Task<ActionResult<TblLaser>> AddLaser(TblLaser laser)
        {
            try
            {
                ActionResult<TblLaser> laserRes = await _laserService.AddLaser(laser);

                if (laserRes == null)
                {
                    return Conflict();
                }
                return CreatedAtAction("AddLaser", new { id = laser.IdLaser }, laser);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Not successful to Add");
            }
        }

        // DELETE: api/TblLaser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaser(int id)
        {
            try
            {
                await _laserService.DeleteLaser(id);
            }
            catch (DbUpdateException)
            {
                return BadRequest("not succefull to delete");
            }
            return NoContent();
        }
    }
}
