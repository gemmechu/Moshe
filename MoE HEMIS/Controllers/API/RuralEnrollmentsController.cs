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
    public class RuralEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RuralEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RuralEnrollments
        [HttpGet]
        public IEnumerable<RuralEnrollment> GetRuralEnrollment()
        {
            return _context.RuralEnrollment;
        }

        [HttpGet("Bydepartment/{id}")]
        public IEnumerable<RuralEnrollment> ByDepartment(int id)
        {
            return _context.RuralEnrollment.Where(r => r.DepartmentId == id).ToList();
        }

        // GET: api/RuralEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRuralEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralEnrollment = await _context.RuralEnrollment.FindAsync(id);

            if (ruralEnrollment == null)
            {
                return NotFound();
            }

            return Ok(ruralEnrollment);
        }

        // PUT: api/RuralEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuralEnrollment([FromRoute] int id, [FromBody] RuralEnrollment ruralEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruralEnrollment.RuralEnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(ruralEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuralEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ruralEnrollment);
        }

        // POST: api/RuralEnrollments
        [HttpPost]
        public async Task<IActionResult> PostRuralEnrollment([FromBody] RuralEnrollment ruralEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RuralEnrollment.Add(ruralEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuralEnrollment", new { id = ruralEnrollment.RuralEnrollmentId }, ruralEnrollment);
        }

        // DELETE: api/RuralEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuralEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruralEnrollment = await _context.RuralEnrollment.FindAsync(id);
            if (ruralEnrollment == null)
            {
                return NotFound();
            }

            _context.RuralEnrollment.Remove(ruralEnrollment);
            await _context.SaveChangesAsync();

            return Ok(ruralEnrollment);
        }

        private bool RuralEnrollmentExists(int id)
        {
            return _context.RuralEnrollment.Any(e => e.RuralEnrollmentId == id);
        }
    }
}