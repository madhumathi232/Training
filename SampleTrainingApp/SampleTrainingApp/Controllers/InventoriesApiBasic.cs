using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleTrainingApp.Data;
using SampleTrainingApp.Models;

namespace SampleTrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesApiBasic : ControllerBase
    {
        private readonly SampleTrainingAppContext _context;

        public InventoriesApiBasic(SampleTrainingAppContext context)
        {
            _context = context;
        }

        // GET: api/InventoriesApiBasic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventory()
        {
          if (_context.Inventory == null)
          {
              return NotFound();
          }
            return await _context.Inventory.ToListAsync();
        }

        // GET: api/InventoriesApiBasic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
          if (_context.Inventory == null)
          {
              return NotFound();
          }
            var inventory = await _context.Inventory.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/InventoriesApiBasic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.ProdId)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/InventoriesApiBasic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
          if (_context.Inventory == null)
          {
              return Problem("Entity set 'SampleTrainingAppContext.Inventory'  is null.");
          }
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.ProdId }, inventory);
        }

        // DELETE: api/InventoriesApiBasic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            if (_context.Inventory == null)
            {
                return NotFound();
            }
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(int id)
        {
            return (_context.Inventory?.Any(e => e.ProdId == id)).GetValueOrDefault();
        }
    }
}
