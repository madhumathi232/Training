using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VILT_AUGUST_DBFirstApp.DatabaseEntity;

namespace VILT_AUGUST_DBFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDepartmentsController : ControllerBase
    {
        private readonly StudentInfoDBContext _context;

        public TblDepartmentsController(StudentInfoDBContext context)
        {
            _context = context;
        }

        // GET: api/TblDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDepartment>>> GetTblDepartments()
        {
          if (_context.TblDepartments == null)
          {
              return NotFound();
          }
            return await _context.TblDepartments.ToListAsync();
        }

        // GET: api/TblDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDepartment>> GetTblDepartment(int id)
        {
          if (_context.TblDepartments == null)
          {
              return NotFound();
          }
            var tblDepartment = await _context.TblDepartments.FindAsync(id);

            if (tblDepartment == null)
            {
                return NotFound();
            }

            return tblDepartment;
        }

        // PUT: api/TblDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDepartment(int id, TblDepartment tblDepartment)
        {
            if (id != tblDepartment.DeptId)
            {
                return BadRequest();
            }

            _context.Entry(tblDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDepartmentExists(id))
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

        // POST: api/TblDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDepartment>> PostTblDepartment(TblDepartment tblDepartment)
        {
          if (_context.TblDepartments == null)
          {
              return Problem("Entity set 'StudentInfoDBContext.TblDepartments'  is null.");
          }
            _context.TblDepartments.Add(tblDepartment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblDepartmentExists(tblDepartment.DeptId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblDepartment", new { id = tblDepartment.DeptId }, tblDepartment);
        }

        // DELETE: api/TblDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDepartment(int id)
        {
            if (_context.TblDepartments == null)
            {
                return NotFound();
            }
            var tblDepartment = await _context.TblDepartments.FindAsync(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            _context.TblDepartments.Remove(tblDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDepartmentExists(int id)
        {
            return (_context.TblDepartments?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
