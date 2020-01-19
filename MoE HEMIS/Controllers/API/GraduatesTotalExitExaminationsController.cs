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
    public class GraduatesTotalExitExaminationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GraduatesTotalExitExaminationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GraduatesTotalExitExaminations
        [HttpGet]
        public IEnumerable<GraduatesTotalExitExamination> GetGraduatesTotalExitExamination()
        {
            return _context.GraduatesTotalExitExamination.Include(e=>e.Department);
        }
        // GET: api/GraduatesTotalExitExaminations/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<GraduatesTotalExitExamination> ByDepartment([FromRoute] int id)
        {
            return _context.GraduatesTotalExitExamination.Include(e => e.Department).Where(a => a.DepartmentId == id);
        }
        // GET: api/GraduatesTotalExitExaminations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraduatesTotalExitExamination([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExamination = await _context.GraduatesTotalExitExamination.FindAsync(id);

            if (graduatesTotalExitExamination == null)
            {
                return NotFound();
            }

            return Ok(graduatesTotalExitExamination);
        }

        // PUT: api/GraduatesTotalExitExaminations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduatesTotalExitExamination([FromRoute] int id, [FromBody] GraduatesTotalExitExamination graduatesTotalExitExamination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graduatesTotalExitExamination.GraduatesTotalExitExaminationId)
            {
                return BadRequest();
            }

            _context.Entry(graduatesTotalExitExamination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduatesTotalExitExaminationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            graduatesTotalExitExamination = _context.GraduatesTotalExitExamination.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationId == graduatesTotalExitExamination.GraduatesTotalExitExaminationId);
            return Ok(graduatesTotalExitExamination);
        }

        // POST: api/GraduatesTotalExitExaminations
        [HttpPost]
        public async Task<IActionResult> PostGraduatesTotalExitExamination([FromBody] GraduatesTotalExitExamination graduatesTotalExitExamination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GraduatesTotalExitExamination.Add(graduatesTotalExitExamination);
            await _context.SaveChangesAsync();
            graduatesTotalExitExamination = _context.GraduatesTotalExitExamination.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationId == graduatesTotalExitExamination.GraduatesTotalExitExaminationId);
            return CreatedAtAction("GetGraduatesTotalExitExamination", new { id = graduatesTotalExitExamination.GraduatesTotalExitExaminationId }, graduatesTotalExitExamination);
        }

        // DELETE: api/GraduatesTotalExitExaminations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduatesTotalExitExamination([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExamination = await _context.GraduatesTotalExitExamination.FindAsync(id);
            if (graduatesTotalExitExamination == null)
            {
                return NotFound();
            }

            _context.GraduatesTotalExitExamination.Remove(graduatesTotalExitExamination);
            await _context.SaveChangesAsync();

            return Ok(graduatesTotalExitExamination);
        }

        private bool GraduatesTotalExitExaminationExists(int id)
        {
            return _context.GraduatesTotalExitExamination.Any(e => e.GraduatesTotalExitExaminationId == id);
        }
    }
}