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
    public class GraduatesTotalExitExaminationByEconomiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GraduatesTotalExitExaminationByEconomiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GraduatesTotalExitExaminationByEconomies
        [HttpGet]
        public IEnumerable<GraduatesTotalExitExaminationByEconomy> GetGraduatesTotalExitExaminationByEconomy()
        {
            return _context.GraduatesTotalExitExaminationByEconomy;
        }

        // GET: api/GraduatesTotalExitExaminationByEconomies/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<GraduatesTotalExitExaminationByEconomy> ByDepartment([FromRoute] int id)
        {
            return _context.GraduatesTotalExitExaminationByEconomy.Include(e => e.Department).Where(a => a.DepartmentId == id);
        }


        // GET: api/GraduatesTotalExitExaminationByEconomies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraduatesTotalExitExaminationByEconomy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExaminationByEconomy = await _context.GraduatesTotalExitExaminationByEconomy.FindAsync(id);

            if (graduatesTotalExitExaminationByEconomy == null)
            {
                return NotFound();
            }

            return Ok(graduatesTotalExitExaminationByEconomy);
        }

        // PUT: api/GraduatesTotalExitExaminationByEconomies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduatesTotalExitExaminationByEconomy([FromRoute] int id, [FromBody] GraduatesTotalExitExaminationByEconomy graduatesTotalExitExaminationByEconomy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graduatesTotalExitExaminationByEconomy.GraduatesTotalExitExaminationByEconomyId)
            {
                return BadRequest();
            }

            _context.Entry(graduatesTotalExitExaminationByEconomy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduatesTotalExitExaminationByEconomyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            graduatesTotalExitExaminationByEconomy = _context.GraduatesTotalExitExaminationByEconomy.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationByEconomyId == graduatesTotalExitExaminationByEconomy.GraduatesTotalExitExaminationByEconomyId);
            return Ok(graduatesTotalExitExaminationByEconomy);
        }

        // POST: api/GraduatesTotalExitExaminationByEconomies
        [HttpPost]
        public async Task<IActionResult> PostGraduatesTotalExitExaminationByEconomy([FromBody] GraduatesTotalExitExaminationByEconomy graduatesTotalExitExaminationByEconomy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GraduatesTotalExitExaminationByEconomy.Add(graduatesTotalExitExaminationByEconomy);
            await _context.SaveChangesAsync();
            graduatesTotalExitExaminationByEconomy = _context.GraduatesTotalExitExaminationByEconomy.Include(e => e.Department).FirstOrDefault(e => e.GraduatesTotalExitExaminationByEconomyId == graduatesTotalExitExaminationByEconomy.GraduatesTotalExitExaminationByEconomyId);

            return CreatedAtAction("GetGraduatesTotalExitExaminationByEconomy", new { id = graduatesTotalExitExaminationByEconomy.GraduatesTotalExitExaminationByEconomyId }, graduatesTotalExitExaminationByEconomy);
        }

        // DELETE: api/GraduatesTotalExitExaminationByEconomies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduatesTotalExitExaminationByEconomy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduatesTotalExitExaminationByEconomy = await _context.GraduatesTotalExitExaminationByEconomy.FindAsync(id);
            if (graduatesTotalExitExaminationByEconomy == null)
            {
                return NotFound();
            }

            _context.GraduatesTotalExitExaminationByEconomy.Remove(graduatesTotalExitExaminationByEconomy);
            await _context.SaveChangesAsync();

            return Ok(graduatesTotalExitExaminationByEconomy);
        }

        private bool GraduatesTotalExitExaminationByEconomyExists(int id)
        {
            return _context.GraduatesTotalExitExaminationByEconomy.Any(e => e.GraduatesTotalExitExaminationByEconomyId == id);
        }
    }
}