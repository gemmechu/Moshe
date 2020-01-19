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
    public class EnrollmentByAgesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentByAgesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EnrollmentByAges
        [HttpGet]
        public IEnumerable<EnrollmentByAge> GetEnrollmentByAges()
        {
            return _context.EnrollmentByAges;
        }

        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<EnrollmentByAge> ByDepartment([FromRoute] int id)
        {
            return _context.EnrollmentByAges.Where( e => e.Department.DepartmentId == id);
        }

        // GET: api/EnrollmentByAges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentByAge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentByAge = await _context.EnrollmentByAges.FindAsync(id);

            if (enrollmentByAge == null)
            {
                return NotFound();
            }

            return Ok(enrollmentByAge);
        }

        // PUT: api/EnrollmentByAges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollmentByAge([FromRoute] int id, [FromBody] EnrollmentByAge enrollmentByAge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollmentByAge.EnrollmentByAgeId)
            {
                return BadRequest();
            }

            _context.Entry(enrollmentByAge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentByAgeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(enrollmentByAge);
        }

        // POST: api/EnrollmentByAges
        [HttpPost]
        public async Task<IActionResult> PostEnrollmentByAge([FromBody] EnrollmentByAge enrollmentByAge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EnrollmentByAges.Add(enrollmentByAge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrollmentByAge", new { id = enrollmentByAge.EnrollmentByAgeId }, enrollmentByAge);
        }

        // DELETE: api/EnrollmentByAges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollmentByAge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentByAge = await _context.EnrollmentByAges.FindAsync(id);
            if (enrollmentByAge == null)
            {
                return NotFound();
            }

            _context.EnrollmentByAges.Remove(enrollmentByAge);
            await _context.SaveChangesAsync();

            return Ok(enrollmentByAge);
        }

        private bool EnrollmentByAgeExists(int id)
        {
            return _context.EnrollmentByAges.Any(e => e.EnrollmentByAgeId == id);
        }
    }
}