using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoE_HEMIS.Data;
using MoE_HEMIS.Models;

namespace MoE_HEMIS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalRevenuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InternalRevenuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InternalRevenues
        [HttpGet]
        public IEnumerable<InternalRevenue> GetInternalRevenues()
        {
            return _context.InternalRevenues.Include(e => e.College);
        } 
        [HttpGet]
        [Route("ByCollege/{id}")]
        public IEnumerable<InternalRevenue> ByCollege([FromRoute] int id)
        {
            return _context.InternalRevenues.Include(e=>e.College).Where(x=>x.CollegeId==id);
        }
        // GET: api/InternalRevenues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInternalRevenue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalRevenue = await _context.InternalRevenues.FindAsync(id);

            if (internalRevenue == null)
            {
                return NotFound();
            }

            return Ok(internalRevenue);
        }

        // PUT: api/InternalRevenues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternalRevenue([FromRoute] int id, [FromBody] InternalRevenue internalRevenue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internalRevenue.InternalRevenueId)
            {
                return BadRequest();
            }

            _context.Entry(internalRevenue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalRevenueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            internalRevenue = _context.InternalRevenues.Include(e => e.College).FirstOrDefault(x => x.InternalRevenueId == internalRevenue.InternalRevenueId);
            return Ok(internalRevenue);
        }

        // POST: api/InternalRevenues
        [HttpPost]
        public async Task<IActionResult> PostInternalRevenue([FromBody] InternalRevenue internalRevenue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InternalRevenues.Add(internalRevenue);
            await _context.SaveChangesAsync();
            internalRevenue = _context.InternalRevenues.Include(e => e.College).FirstOrDefault(x => x.InternalRevenueId == internalRevenue.InternalRevenueId);
            return CreatedAtAction("GetInternalRevenue", new { id = internalRevenue.InternalRevenueId }, internalRevenue);
        }

        // DELETE: api/InternalRevenues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternalRevenue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalRevenue = await _context.InternalRevenues.FindAsync(id);
            if (internalRevenue == null)
            {
                return NotFound();
            }

            _context.InternalRevenues.Remove(internalRevenue);
            await _context.SaveChangesAsync();

            return Ok(internalRevenue);
        }

        private bool InternalRevenueExists(int id)
        {
            return _context.InternalRevenues.Any(e => e.InternalRevenueId == id);
        }
    }
}