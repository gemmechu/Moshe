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
    public class RuralGraduatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RuralGraduatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RuralGraduates
        [HttpGet]
        public IEnumerable<RuralGraduate> GetRuralGraduate()
        {
            return _context.RuralGraduate;
        }
        
        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<RuralGraduate> ByDepartment(int id)
        {
            return _context.RuralGraduate.Where(e => e.DepartmentId == id);
        }

        // GET: api/RuralGraduates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRuralGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralGraduate = await _context.RuralGraduate.FindAsync(id);

            if (ruralGraduate == null)
            {
                return NotFound();
            }

            return Ok(ruralGraduate);
        }

        // PUT: api/RuralGraduates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuralGraduate([FromRoute] int id, [FromBody] RuralGraduate ruralGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruralGraduate.RuralGraduateId)
            {
                return BadRequest();
            }

            _context.Entry(ruralGraduate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuralGraduateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ruralGraduate);
        }

        // POST: api/RuralGraduates
        [HttpPost]
        public async Task<IActionResult> PostRuralGraduate([FromBody] RuralGraduate ruralGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RuralGraduate.Add(ruralGraduate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuralGraduate", new { id = ruralGraduate.RuralGraduateId }, ruralGraduate);
        }

        // DELETE: api/RuralGraduates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuralGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralGraduate = await _context.RuralGraduate.FindAsync(id);
            if (ruralGraduate == null)
            {
                return NotFound();
            }

            _context.RuralGraduate.Remove(ruralGraduate);
            await _context.SaveChangesAsync();

            return Ok(ruralGraduate);
        }

        private bool RuralGraduateExists(int id)
        {
            return _context.RuralGraduate.Any(e => e.RuralGraduateId == id);
        }
    }
}