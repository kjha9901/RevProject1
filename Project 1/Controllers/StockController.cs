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
    public class StockController : ControllerBase
    {
        private readonly ShoppingApidbContext _context = new ShoppingApidbContext();

        //public StockController(ShoppingApidbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDetail>>> GetStockDetails()
        {
            return await _context.StockDetails.ToListAsync();
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockDetail>> GetStockDetail(int id)
        {
            var stockDetail = await _context.StockDetails.FindAsync(id);

            if (stockDetail == null)
            {
                return NotFound();
            }

            return stockDetail;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockDetail(int id, StockDetail stockDetail)
        {
            if (id != stockDetail.StockId)
            {
                return BadRequest();
            }

            _context.Entry(stockDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockDetailExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockDetail>> PostStockDetail(StockDetail stockDetail)
        {
            _context.StockDetails.Add(stockDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockDetailExists(stockDetail.StockId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStockDetail", new { id = stockDetail.StockId }, stockDetail);
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockDetail(int id)
        {
            var stockDetail = await _context.StockDetails.FindAsync(id);
            if (stockDetail == null)
            {
                return NotFound();
            }

            _context.StockDetails.Remove(stockDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockDetailExists(int id)
        {
            return _context.StockDetails.Any(e => e.StockId == id);
        }
    }
}
