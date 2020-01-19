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
    public class EmergingRegionEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmergingRegionEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmergingRegionEnrollments
        [HttpGet]
        public IEnumerable<EmergingRegionEnrollment> GetEmergingRegionEnrollments()
        {
            return _context.EmergingRegionEnrollments;
        }

        [HttpGet]
        [Route("ByInstitution/{id}")]
        public IEnumerable<EmergingRegionEnrollment> ByInstitution([FromRoute] int id)
        {
            return _context.EmergingRegionEnrollments.Where(e => e.Department.College.InstitutionId == id);
        }

        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<EmergingRegionEnrollment> ByDepartment([FromRoute] int id)
        {
            return _context.EmergingRegionEnrollments.Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/EmergingRegionEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmergingRegionEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emergingRegionEnrollment = await _context.EmergingRegionEnrollments.FindAsync(id);

            if (emergingRegionEnrollment == null)
            {
                return NotFound();
            }

            return Ok(emergingRegionEnrollment);
        }

        // PUT: api/EmergingRegionEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergingRegionEnrollment([FromRoute] int id, [FromBody] EmergingRegionEnrollment emergingRegionEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emergingRegionEnrollment.EmergingRegionEnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(emergingRegionEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergingRegionEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(emergingRegionEnrollment);
        }

        // POST: api/EmergingRegionEnrollments
        [HttpPost]
        public async Task<IActionResult> PostEmergingRegionEnrollment([FromBody] EmergingRegionEnrollment emergingRegionEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmergingRegionEnrollments.Add(emergingRegionEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmergingRegionEnrollment", new { id = emergingRegionEnrollment.EmergingRegionEnrollmentId }, emergingRegionEnrollment);
        }

        // DELETE: api/EmergingRegionEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergingRegionEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emergingRegionEnrollment = await _context.EmergingRegionEnrollments.FindAsync(id);
            if (emergingRegionEnrollment == null)
            {
                return NotFound();
            }

            _context.EmergingRegionEnrollments.Remove(emergingRegionEnrollment);
            await _context.SaveChangesAsync();

            return Ok(emergingRegionEnrollment);
        }

        private bool EmergingRegionEnrollmentExists(int id)
        {
            return _context.EmergingRegionEnrollments.Any(e => e.EmergingRegionEnrollmentId == id);
        }
    }
}