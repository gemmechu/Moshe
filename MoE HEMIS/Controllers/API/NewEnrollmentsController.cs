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
    public class NewEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NewEnrollments
        [HttpGet]
        public IEnumerable<NewEnrollment> GetNewEnrollments()
        {
            return _context.NewEnrollments.Include(e=>e.Department);
        }
        // GET: api/NewEnrollments/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<NewEnrollment> ByDepartment([FromRoute] int id)
        {
            return _context.NewEnrollments.Where(e => e.Department.DepartmentId == id);
        }
        // GET: api/NewEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEnrollment = await _context.NewEnrollments.FindAsync(id);

            if (newEnrollment == null)
            {
                return NotFound();
            }

            return Ok(newEnrollment);
        }

        // PUT: api/NewEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewEnrollment([FromRoute] int id, [FromBody] NewEnrollment newEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newEnrollment.NewEnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(newEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            newEnrollment = _context.NewEnrollments.Include(e => e.Department).FirstOrDefault(e => e.NewEnrollmentId == newEnrollment.NewEnrollmentId);

            return Ok(newEnrollment);
        }

        // POST: api/NewEnrollments
        [HttpPost]
        public async Task<IActionResult> PostNewEnrollment([FromBody] NewEnrollment newEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NewEnrollments.Add(newEnrollment);
            await _context.SaveChangesAsync();
            newEnrollment = _context.NewEnrollments.Include(e => e.Department).FirstOrDefault(e => e.NewEnrollmentId == newEnrollment.NewEnrollmentId);
            return CreatedAtAction("GetNewEnrollment", new { id = newEnrollment.NewEnrollmentId }, newEnrollment);
        }

        // DELETE: api/NewEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEnrollment = await _context.NewEnrollments.FindAsync(id);
            if (newEnrollment == null)
            {
                return NotFound();
            }

            _context.NewEnrollments.Remove(newEnrollment);
            await _context.SaveChangesAsync();

            return Ok(newEnrollment);
        }

        private bool NewEnrollmentExists(int id)
        {
            return _context.NewEnrollments.Any(e => e.NewEnrollmentId == id);
        }
    }
}