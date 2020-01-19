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
    public class InternshipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InternshipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Internships/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<Internship> ByDepartment([FromRoute] int id)
        {
            return _context.Internships.Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/Internships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInternship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internship = await _context.Internships.FindAsync(id);

            if (internship == null)
            {
                return NotFound();
            }

            return Ok(internship);
        }

        // PUT: api/Internships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternship([FromRoute] int id, [FromBody] Internship internship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internship.InternshipId)
            {
                return BadRequest();
            }

            _context.Entry(internship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternshipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            internship = _context.Internships.Include(e => e.Department).FirstOrDefault(e => e.InternshipId == internship.InternshipId);
            return Ok(internship);
        }

        // POST: api/Internships
        [HttpPost]
        public async Task<IActionResult> PostInternship([FromBody] Internship internship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Internships.Add(internship);
            await _context.SaveChangesAsync();
            internship = _context.Internships.Include(e => e.Department).FirstOrDefault(e => e.InternshipId == internship.InternshipId);
            return CreatedAtAction("GetInternship", new { id = internship.InternshipId }, internship);
        }

        // DELETE: api/Internships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternship([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internship = await _context.Internships.FindAsync(id);
            if (internship == null)
            {
                return NotFound();
            }

            _context.Internships.Remove(internship);
            await _context.SaveChangesAsync();

            return Ok(internship);
        }

        private bool InternshipExists(int id)
        {
            return _context.Internships.Any(e => e.InternshipId == id);
        }
    }
}