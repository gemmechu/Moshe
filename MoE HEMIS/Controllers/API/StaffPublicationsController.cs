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
    public class StaffPublicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffPublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffPublications
        [HttpGet]
        public IEnumerable<StaffPublication> GetStaffPublication()
        {
            return _context.StaffPublication;
        }

        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<StaffPublication> ByDepartment(int id)
        {
            return _context.StaffPublication
                .Include(d => d.AcademicStaff)
                .Where(d => d.DepartmentId == id);
        }

        // GET: api/StaffPublications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffPublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffPublication = await _context.StaffPublication.FindAsync(id);

            if (staffPublication == null)
            {
                return NotFound();
            }

            return Ok(staffPublication);
        }

        // PUT: api/StaffPublications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffPublication([FromRoute] int id, [FromBody] StaffPublication staffPublication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffPublication.StaffPublicationId)
            {
                return BadRequest();
            }

            _context.Entry(staffPublication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffPublicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            staffPublication = _context.StaffPublication
                 .Include(d => d.AcademicStaff)
                .FirstOrDefault(e => e.StaffPublicationId == staffPublication.StaffPublicationId);
            return Ok(staffPublication);
        }

        // POST: api/StaffPublications
        [HttpPost]
        public async Task<IActionResult> PostStaffPublication([FromBody] StaffPublication staffPublication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffPublication.Add(staffPublication);
            await _context.SaveChangesAsync();
            staffPublication = _context.StaffPublication
                 .Include(d => d.AcademicStaff)
                .FirstOrDefault(e => e.StaffPublicationId == staffPublication.StaffPublicationId);

            return CreatedAtAction("GetStaffPublication", new { id = staffPublication.StaffPublicationId }, staffPublication);
        }

        // DELETE: api/StaffPublications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffPublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffPublication = await _context.StaffPublication.FindAsync(id);
            if (staffPublication == null)
            {
                return NotFound();
            }

            _context.StaffPublication.Remove(staffPublication);
            await _context.SaveChangesAsync();

            return Ok(staffPublication);
        }

        private bool StaffPublicationExists(int id)
        {
            return _context.StaffPublication.Any(e => e.StaffPublicationId == id);
        }
    }
}