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
    public class SpecialNeedGraduatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpecialNeedGraduatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SpecialNeedGraduates
        [HttpGet]
        public IEnumerable<SpecialNeedGraduate> GetSpecialNeedGraduate()
        {
            return _context.SpecialNeedGraduate;
        }

        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<SpecialNeedGraduate> ByDepartment(int id)
        {
            return _context.SpecialNeedGraduate.Where(e => e.DepartmentId == id);
        }

        // GET: api/SpecialNeedGraduates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialNeedGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specialNeedGraduate = await _context.SpecialNeedGraduate.FindAsync(id);

            if (specialNeedGraduate == null)
            {
                return NotFound();
            }

            return Ok(specialNeedGraduate);
        }

        // PUT: api/SpecialNeedGraduates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialNeedGraduate([FromRoute] int id, [FromBody] SpecialNeedGraduate specialNeedGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialNeedGraduate.SpecialNeedGraduateId)
            {
                return BadRequest();
            }

            _context.Entry(specialNeedGraduate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialNeedGraduateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(specialNeedGraduate);
        }

        // POST: api/SpecialNeedGraduates
        [HttpPost]
        public async Task<IActionResult> PostSpecialNeedGraduate([FromBody] SpecialNeedGraduate specialNeedGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SpecialNeedGraduate.Add(specialNeedGraduate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialNeedGraduate", new { id = specialNeedGraduate.SpecialNeedGraduateId }, specialNeedGraduate);
        }

        // DELETE: api/SpecialNeedGraduates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialNeedGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specialNeedGraduate = await _context.SpecialNeedGraduate.FindAsync(id);
            if (specialNeedGraduate == null)
            {
                return NotFound();
            }

            _context.SpecialNeedGraduate.Remove(specialNeedGraduate);
            await _context.SaveChangesAsync();

            return Ok(specialNeedGraduate);
        }

        private bool SpecialNeedGraduateExists(int id)
        {
            return _context.SpecialNeedGraduate.Any(e => e.SpecialNeedGraduateId == id);
        }
    }
}