using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorService.Data;
using AuthorService.Models;
using Microsoft.AspNetCore.Authorization;
using DigitalBook;

namespace AuthorService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserTablesController : ControllerBase
    {
        private readonly AuthorServiceContext _context;

        public UserTablesController(AuthorServiceContext context)
        {
            _context = context;
        }

        // GET: api/UserTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTable()
        {
          if (_context.UserTable == null)
          {
              return NotFound();
          }
            return await _context.UserTable.ToListAsync();
        }

        // GET: api/UserTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTable>> GetUserTable(int id)
        {
          if (_context.UserTable == null)
          {
              return NotFound();
          }
            var userTable = await _context.UserTable.FindAsync(id);

            if (userTable == null)
            {
                return NotFound();
            }

            return userTable;
        }

        // PUT: api/UserTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTable(int id, UserTable userTable)
        {
            if (id != userTable.UserId)
            {
                return BadRequest();
            }

            //_context.Entry(userTable).State = EntityState.Modified;
           
            try
            {
                var dbUsers = _context.UserTable
      .FirstOrDefault(s => s.UserId.Equals(id));
                dbUsers.UserName = userTable.UserName;
                dbUsers.EmailId = userTable.EmailId;
                dbUsers.Password = userTable.Password;
                dbUsers.FirstName = userTable.FirstName;
                dbUsers.LastName = userTable.LastName;
                dbUsers.Active = userTable.Active;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
          if (_context.UserTable == null)
          {

              return Problem("Entity set 'AuthorServiceContext.UserTable'  is null.");
          }
            userTable.Password = EncryptionDecryption.EncodePasswordToBase64(userTable.Password);
            _context.UserTable.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.UserId }, userTable);
        }

        // DELETE: api/UserTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTable(int id)
        {
            if (_context.UserTable == null)
            {
                return NotFound();
            }
            var userTable = await _context.UserTable.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }

            _context.UserTable.Remove(userTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTableExists(int id)
        {
            return (_context.UserTable?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
