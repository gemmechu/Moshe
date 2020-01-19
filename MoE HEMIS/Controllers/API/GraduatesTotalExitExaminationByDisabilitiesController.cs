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
    public class GraduatesTotalExitExaminationByDisabilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GraduatesTotalExitExaminationByDisabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GraduatesTotalExitExaminationByDisabilities
        [HttpGet]
        public IEnumerable<GraduatesTotalExitExaminationByDisability> GetGraduatesTotalExitExaminationByDisability()
        {
            return _context.GraduatesTotalExitExaminationByDisability;
        }

        // GET: api/GraduatesTotalExitExaminationByDisabilities/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<GraduatesTotalExitExaminationByDisability> ByDepartment([FromRoute] int id)
        {
            return _context.GraduatesTotalExitExaminationByDisability.Include(e => e.Department).Where(a => a.DepartmentId == id);
        }


        // GET: api/GraduatesTotalExitExaminationByDisabilities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraduatesTotalExitExaminationByDisability([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExaminationByDisability = await _context.GraduatesTotalExitExaminationByDisability.FindAsync(id);

            if (graduatesTotalExitExaminationByDisability == null)
            {
                return NotFound();
            }

            return Ok(graduatesTotalExitExaminationByDisability);
        }

        // PUT: api/GraduatesTotalExitExaminationByDisabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduatesTotalExitExaminationByDisability([FromRoute] int id, [FromBody] GraduatesTotalExitExaminationByDisability graduatesTotalExitExaminationByDisability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graduatesTotalExitExaminationByDisability.GraduatesTotalExitExaminationByDisabilityId)
            {
                return BadRequest();
            }

            _context.Entry(graduatesTotalExitExaminationByDisability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduatesTotalExitExaminationByDisabilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            graduatesTotalExitExaminationByDisability = _context.GraduatesTotalExitExaminationByDisability.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationByDisabilityId == graduatesTotalExitExaminationByDisability.GraduatesTotalExitExaminationByDisabilityId);
            return Ok(graduatesTotalExitExaminationByDisability);
        }

        // POST: api/GraduatesTotalExitExaminationByDisabilities
        [HttpPost]
        public async Task<IActionResult> PostGraduatesTotalExitExaminationByDisability([FromBody] GraduatesTotalExitExaminationByDisability graduatesTotalExitExaminationByDisability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GraduatesTotalExitExaminationByDisability.Add(graduatesTotalExitExaminationByDisability);
            await _context.SaveChangesAsync();
            graduatesTotalExitExaminationByDisability = _context.GraduatesTotalExitExaminationByDisability.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationByDisabilityId == graduatesTotalExitExaminationByDisability.GraduatesTotalExitExaminationByDisabilityId);

            return CreatedAtAction("GetGraduatesTotalExitExaminationByDisability", new { id = graduatesTotalExitExaminationByDisability.GraduatesTotalExitExaminationByDisabilityId }, graduatesTotalExitExaminationByDisability);
        }

        // DELETE: api/GraduatesTotalExitExaminationByDisabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduatesTotalExitExaminationByDisability([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExaminationByDisability = await _context.GraduatesTotalExitExaminationByDisability.FindAsync(id);
            if (graduatesTotalExitExaminationByDisability == null)
            {
                return NotFound();
            }

            _context.GraduatesTotalExitExaminationByDisability.Remove(graduatesTotalExitExaminationByDisability);
            await _context.SaveChangesAsync();

            return Ok(graduatesTotalExitExaminationByDisability);
        }

        private bool GraduatesTotalExitExaminationByDisabilityExists(int id)
        {
            return _context.GraduatesTotalExitExaminationByDisability.Any(e => e.GraduatesTotalExitExaminationByDisabilityId == id);
        }
    }
}