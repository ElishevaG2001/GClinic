using Gproject.DataDB;
using Gproject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Gproject.Services
{
    public class RoomsService : IRoom
    {
            private readonly DataProjectContext _context;

            public RoomsService(DataProjectContext context)
            {
                _context = context;
            }

            // GET: api/TblEmployees 

            public async Task<ActionResult<IEnumerable<TblRoom>>> GetAllRooms()
            {
                return await _context.TblRooms.ToListAsync();
            }

            // GET: api/TblRooms/5  - by id 
            public async Task<ActionResult<TblRoom>> GetRoomById(int id)
            {
                TblRoom room = await _context.TblRooms.FirstOrDefaultAsync(c => c.IdRoom == id);

                if (room == null)
                {
                    throw new Exception("This Roon is not valid!");
                }
                return room;
            }

            // PUT: api/TblRoom/5  update ROOM by id 
            [HttpPut("{id}")]
            public async Task<ActionResult<TblRoom>> UpdateRoom(int id, TblRoom room)
            {
                if (id != room.IdRoom)
                {
                    throw new Exception("erro with the parameter Id");
                }

                if (GetRoomById(room.IdRoom) == null)
                {

                    throw new Exception("This Contact is not Exsit!");
                }

                _context.Entry(room).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return room;
            }

            // POST: api/TblEmployees  add new employee
            [HttpPost]
            public async Task<ActionResult<TblRoom>> AddRoom(TblRoom room)
            {

                _context.TblRooms.Add(room);

                await _context.SaveChangesAsync();

                if (!TblRoonExists(room.IdRoom))
                {
                    throw new Exception("the room not succfull to Add");
                }


                return room;
            }

            // DELETE: api/TblEmployees/5  delete employee by id
            public async Task<ActionResult<TblRoom>> DeleteRoom(int id)
            {
                var room = findRoom(id);
                if (room == null)
                {
                    throw new Exception("This Room is not valid!");
                }

                _context.TblRooms.Remove(room);
                await _context.SaveChangesAsync();

                return room;
            }

            private bool TblRoonExists(int id)
            {
                return _context.TblRooms.Any(e => e.IdRoom == id);
            }

            private TblRoom findRoom(int id)
            {
                return _context.TblRooms.FirstOrDefault(c => c.IdRoom == id);
            }
        }
    }


