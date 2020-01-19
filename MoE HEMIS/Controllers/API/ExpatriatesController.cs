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
    public class ExpatriatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpatriatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Expatriates
        [HttpGet]
        public IEnumerable<Expatriate> GetExpatriates()
        {
            return _context.Expatriates;
        }

        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<Expatriate> ByDepartment([FromRoute] int id)
        {
            return _context.Expatriates.Include(e => e.Department).Where(e => e.DepartmentId == id);
        }

        // GET: api/Expatriates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpatriate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expatriate = await _context.Expatriates.FindAsync(id);

            if (expatriate == null)
            {
                return NotFound();
            }

            return Ok(expatriate);
        }

        // PUT: api/Expatriates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpatriate([FromRoute] int id, [FromBody] Expatriate expatriate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expatriate.ExpatriateId)
            {
                return BadRequest();
            }

            _context.Entry(expatriate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpatriateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            expatriate = _context.Expatriates.Include(e => e.Department).FirstOrDefault(e => e.ExpatriateId == expatriate.ExpatriateId);
            return Ok(expatriate);
        }

        // POST: api/Expatriates
        [HttpPost]
        public async Task<IActionResult> PostExpatriate([FromBody] Expatriate expatriate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Expatriates.Add(expatriate);
            await _context.SaveChangesAsync();

            expatriate = _context.Expatriates.Include(e => e.Department).FirstOrDefault(e => e.ExpatriateId == expatriate.ExpatriateId);
            return CreatedAtAction("GetExpatriate", new { id = expatriate.ExpatriateId }, expatriate);
        }

        // DELETE: api/Expatriates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpatriate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expatriate = await _context.Expatriates.FindAsync(id);
            if (expatriate == null)
            {
                return NotFound();
            }

            _context.Expatriates.Remove(expatriate);
            await _context.SaveChangesAsync();

            return Ok(expatriate);
        }

        private bool ExpatriateExists(int id)
        {
            return _context.Expatriates.Any(e => e.ExpatriateId == id);
        }
    }
}