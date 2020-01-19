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
    public class PastoralRegionEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PastoralRegionEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PastoralRegionEnrollments
        [HttpGet]
        public IEnumerable<PastoralRegionEnrollment> GetPastoralRegionEnrollments()
        {
            return _context.PastoralRegionEnrollments;
        }
        
        [HttpGet]
        [Route("ByInstitution/{id}")]
        public IEnumerable<PastoralRegionEnrollment> ByInstitution([FromRoute] int id)
        {
            return _context.PastoralRegionEnrollments.Where(e => e.Department.College.InstitutionId == id);
        }
                
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<PastoralRegionEnrollment> ByDepartment([FromRoute] int id)
        {
            return _context.PastoralRegionEnrollments.Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/PastoralRegionEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPastoralRegionEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pastoralRegionEnrollment = await _context.PastoralRegionEnrollments.FindAsync(id);

            if (pastoralRegionEnrollment == null)
            {
                return NotFound();
            }

            return Ok(pastoralRegionEnrollment);
        }

        // PUT: api/PastoralRegionEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastoralRegionEnrollment([FromRoute] int id, [FromBody] PastoralRegionEnrollment pastoralRegionEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pastoralRegionEnrollment.PastoralRegionEnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(pastoralRegionEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastoralRegionEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pastoralRegionEnrollment);
        }

        // POST: api/PastoralRegionEnrollments
        [HttpPost]
        public async Task<IActionResult> PostPastoralRegionEnrollment([FromBody] PastoralRegionEnrollment pastoralRegionEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PastoralRegionEnrollments.Add(pastoralRegionEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastoralRegionEnrollment", new { id = pastoralRegionEnrollment.PastoralRegionEnrollmentId }, pastoralRegionEnrollment);
        }

        // DELETE: api/PastoralRegionEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastoralRegionEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pastoralRegionEnrollment = await _context.PastoralRegionEnrollments.FindAsync(id);
            if (pastoralRegionEnrollment == null)
            {
                return NotFound();
            }

            _context.PastoralRegionEnrollments.Remove(pastoralRegionEnrollment);
            await _context.SaveChangesAsync();

            return Ok(pastoralRegionEnrollment);
        }

        private bool PastoralRegionEnrollmentExists(int id)
        {
            return _context.PastoralRegionEnrollments.Any(e => e.PastoralRegionEnrollmentId == id);
        }
    }
}