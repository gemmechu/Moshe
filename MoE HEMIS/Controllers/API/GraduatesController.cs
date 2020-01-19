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
    public class GraduatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GraduatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Graduates
        [HttpGet]
        public IEnumerable<Graduate> GetGraduates()
        {
            return _context.Graduates;
        }

        [HttpGet("{id}")]
        [Route("ByDepartment/{id}")]
        public IEnumerable<Graduate> ByDepartment([FromRoute] int id)
        {
            return _context.Graduates.Include(g => g.Department).Where(g => g.Department.DepartmentId == id);
        }

        // GET: api/Graduates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduate = await _context.Graduates.FindAsync(id);

            if (graduate == null)
            {
                return NotFound();
            }

            return Ok(graduate);
        }

        // PUT: api/Graduates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduate([FromRoute] int id, [FromBody] Graduate graduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != graduate.GraduateId)
            {
                return BadRequest();
            }

            _context.Entry(graduate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            graduate = _context.Graduates.Include(g => g.Department).FirstOrDefault(g => g.GraduateId == graduate.GraduateId);
            return Ok(graduate);
        }

        // POST: api/Graduates
        [HttpPost]
        public async Task<IActionResult> PostGraduate([FromBody] Graduate graduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Graduates.Add(graduate);
            await _context.SaveChangesAsync();

            graduate = _context.Graduates.Include(g => g.Department).FirstOrDefault(g => g.GraduateId == graduate.GraduateId);

            return CreatedAtAction("GetGraduate", new { id = graduate.GraduateId }, graduate);
        }

        // DELETE: api/Graduates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var graduate = await _context.Graduates.FindAsync(id);
            if (graduate == null)
            {
                return NotFound();
            }

            _context.Graduates.Remove(graduate);
            await _context.SaveChangesAsync();

            return Ok(graduate);
        }

        private bool GraduateExists(int id)
        {
            return _context.Graduates.Any(e => e.GraduateId == id);
        }
    }
}