using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_1.Models;

namespace Project_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ShoppingApidbContext _context = new ShoppingApidbContext();

        //public StoreController(ShoppingApidbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Store
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDetail>>> GetStoreDetails()
        {
            return await _context.StoreDetails.ToListAsync();
        }

        // GET: api/Store/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDetail>> GetStoreDetail(int id)
        {
            var storeDetail = await _context.StoreDetails.FindAsync(id);

            if (storeDetail == null)
            {
                return NotFound();
            }

            return storeDetail;
        }

        // PUT: api/Store/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreDetail(int id, StoreDetail storeDetail)
        {
            if (id != storeDetail.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(storeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreDetailExists(id))
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

        // POST: api/Store
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreDetail>> PostStoreDetail(StoreDetail storeDetail)
        {
            _context.StoreDetails.Add(storeDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StoreDetailExists(storeDetail.StoreId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStoreDetail", new { id = storeDetail.StoreId }, storeDetail);
        }

        // DELETE: api/Store/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreDetail(int id)
        {
            var storeDetail = await _context.StoreDetails.FindAsync(id);
            if (storeDetail == null)
            {
                return NotFound();
            }

            _context.StoreDetails.Remove(storeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreDetailExists(int id)
        {
            return _context.StoreDetails.Any(e => e.StoreId == id);
        }
    }
}
