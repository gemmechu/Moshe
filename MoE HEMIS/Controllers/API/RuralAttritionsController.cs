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
    public class RuralAttritionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RuralAttritionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RuralAttritions
        [HttpGet]
        public IEnumerable<RuralAttrition> GetRuralAttrition()
        {
            return _context.RuralAttrition.Include(e=>e.Department);
        }        
        // GET: api/StudentAttritions/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<RuralAttrition> ByDepartment([FromRoute] int id)
        {
            return _context.RuralAttrition.Include(e=>e.Department).Where(a => a.DepartmentId == id);
        }

        // GET: api/RuralAttritions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRuralAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralAttrition = await _context.RuralAttrition.FindAsync(id);

            if (ruralAttrition == null)
            {
                return NotFound();
            }
            return Ok(ruralAttrition);
        }

        // PUT: api/RuralAttritions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuralAttrition([FromRoute] int id, [FromBody] RuralAttrition ruralAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruralAttrition.RuralAttritionId)
            {
                return BadRequest();
            }

            _context.Entry(ruralAttrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuralAttritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ruralAttrition = _context.RuralAttrition.Include(e => e.Department).FirstOrDefault(e => e.RuralAttritionId == ruralAttrition.RuralAttritionId);
            return Ok(ruralAttrition);
        }

        // POST: api/RuralAttritions
        [HttpPost]
        public async Task<IActionResult> PostRuralAttrition([FromBody] RuralAttrition ruralAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RuralAttrition.Add(ruralAttrition);
            await _context.SaveChangesAsync();
            ruralAttrition = _context.RuralAttrition.Include(e => e.Department).FirstOrDefault(e => e.RuralAttritionId == ruralAttrition.RuralAttritionId);
            return CreatedAtAction("GetRuralAttrition", new { id = ruralAttrition.RuralAttritionId }, ruralAttrition);
        }

        // DELETE: api/RuralAttritions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuralAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralAttrition = await _context.RuralAttrition.FindAsync(id);
            if (ruralAttrition == null)
            {
                return NotFound();
            }

            _context.RuralAttrition.Remove(ruralAttrition);
            await _context.SaveChangesAsync();

            return Ok(ruralAttrition);
        }

        private bool RuralAttritionExists(int id)
        {
            return _context.RuralAttrition.Any(e => e.RuralAttritionId == id);
        }
    }
}