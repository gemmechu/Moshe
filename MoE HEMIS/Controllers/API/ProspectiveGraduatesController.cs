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
    public class ProspectiveGraduatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProspectiveGraduatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProspectiveGraduates
        [HttpGet]
        public IEnumerable<ProspectiveGraduate> GetProspectiveGraduates()
        {
            return _context.ProspectiveGraduates;
        }

        // GET: api/ProspectiveGraduates/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<ProspectiveGraduate> ByDepartment([FromRoute] int id)
        {
            return _context.ProspectiveGraduates.Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/ProspectiveGraduates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProspectiveGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prospectiveGraduate = await _context.ProspectiveGraduates.FindAsync(id);

            if (prospectiveGraduate == null)
            {
                return NotFound();
            }

            return Ok(prospectiveGraduate);
        }

        // PUT: api/ProspectiveGraduates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspectiveGraduate([FromRoute] int id, [FromBody] ProspectiveGraduate prospectiveGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prospectiveGraduate.ProspectiveGraduateId)
            {
                return BadRequest();
            }

            _context.Entry(prospectiveGraduate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectiveGraduateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            prospectiveGraduate = _context.ProspectiveGraduates.Include(p => p.Department).FirstOrDefault(p => p.ProspectiveGraduateId == prospectiveGraduate.ProspectiveGraduateId);
            return Ok(prospectiveGraduate);
        }

        // POST: api/ProspectiveGraduates
        [HttpPost]
        public async Task<IActionResult> PostProspectiveGraduate([FromBody] ProspectiveGraduate prospectiveGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProspectiveGraduates.Add(prospectiveGraduate);
            await _context.SaveChangesAsync();

            prospectiveGraduate = _context.ProspectiveGraduates.Include(p => p.Department).FirstOrDefault(p => p.ProspectiveGraduateId == prospectiveGraduate.ProspectiveGraduateId);

            return CreatedAtAction("GetProspectiveGraduate", new { id = prospectiveGraduate.ProspectiveGraduateId }, prospectiveGraduate);
        }

        // DELETE: api/ProspectiveGraduates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProspectiveGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prospectiveGraduate = await _context.ProspectiveGraduates.FindAsync(id);
            if (prospectiveGraduate == null)
            {
                return NotFound();
            }

            _context.ProspectiveGraduates.Remove(prospectiveGraduate);
            await _context.SaveChangesAsync();

            return Ok(prospectiveGraduate);
        }

        private bool ProspectiveGraduateExists(int id)
        {
            return _context.ProspectiveGraduates.Any(e => e.ProspectiveGraduateId == id);
        }
    }
}