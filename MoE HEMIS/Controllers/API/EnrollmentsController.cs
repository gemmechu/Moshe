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
    public class EnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrollments
        [HttpGet]
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _context.Enrollments.Include(e => e.Department);
        }
        
        // GET: api/Enrollments/ByCollege/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<Enrollment> ByDepartment([FromRoute] int id)
        {
            return _context.Enrollments.Where(e => e.Department.DepartmentId == id).Include(e => e.Department);
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        // GET: api/Enrollments/ByInstitutionStudyprogramLevel/5/1/3/4
        [HttpGet]
        [Route("ByInstitutionStudyprogramLevel/{ida}/{idb}/{idc}")]
        public IEnumerable<Enrollment> ByInstitutionCollegeStudyprogramLevel([FromRoute] int ida, [FromRoute] int idb, [FromRoute] int idc)
        {
            return _context.Enrollments.Where(
                e =>e.Department.College.InstitutionId == ida && e.Program == (StudyProgram)idb && e.Level == (StudyLevel) idc).Include(e => e.Department).Include(e=> e.Department.College.Band);
        }

        // PUT: api/Enrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment([FromRoute] int id, [FromBody] Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollment.EnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            enrollment = _context.Enrollments.Include(e => e.Department).FirstOrDefault(e => e.EnrollmentId == enrollment.EnrollmentId);
            return Ok(enrollment);
        }

        // POST: api/Enrollments
        [HttpPost]
        public async Task<IActionResult> PostEnrollment([FromBody] Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            enrollment = _context.Enrollments.Include(e => e.Department).FirstOrDefault(e => e.EnrollmentId == enrollment.EnrollmentId);
            return CreatedAtAction("GetEnrollment", new { id = enrollment.EnrollmentId }, enrollment);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return Ok(enrollment);
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentId == id);
        }
    }
}