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
    public class SpecialNeedAttritionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpecialNeedAttritionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SpecialNeedAttritions
        [HttpGet]
        public IEnumerable<SpecialNeedAttrition> GetSpecialNeedAttrition()
        {
            return _context.SpecialNeedAttrition.Include(e => e.Department);
        }
        // GET: api/SpecialNeedAttrition/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<SpecialNeedAttrition> ByDepartment([FromRoute] int id)
        {
            return _context.SpecialNeedAttrition.Include(e => e.Department).Where(a => a.DepartmentId == id);
        }


        // GET: api/SpecialNeedAttritions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialNeedAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specialNeedAttrition = await _context.SpecialNeedAttrition.FindAsync(id);

            if (specialNeedAttrition == null)
            {
                return NotFound();
            }

            return Ok(specialNeedAttrition);
        }

        // PUT: api/SpecialNeedAttritions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialNeedAttrition([FromRoute] int id, [FromBody] SpecialNeedAttrition specialNeedAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specialNeedAttrition.specialNeedAttritionId)
            {
                return BadRequest();
            }

            _context.Entry(specialNeedAttrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialNeedAttritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            specialNeedAttrition = _context.SpecialNeedAttrition.Include(e => e.Department).FirstOrDefault(e => e.specialNeedAttritionId == specialNeedAttrition.specialNeedAttritionId);
            return Ok(specialNeedAttrition);
        }

        // POST: api/SpecialNeedAttritions
        [HttpPost]
        public async Task<IActionResult> PostSpecialNeedAttrition([FromBody] SpecialNeedAttrition specialNeedAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SpecialNeedAttrition.Add(specialNeedAttrition);
            await _context.SaveChangesAsync();
            specialNeedAttrition = _context.SpecialNeedAttrition.Include(e => e.Department).FirstOrDefault(e => e.specialNeedAttritionId == specialNeedAttrition.specialNeedAttritionId);
            return CreatedAtAction("GetSpecialNeedAttrition", new { id = specialNeedAttrition.specialNeedAttritionId }, specialNeedAttrition);
        }

        // DELETE: api/SpecialNeedAttritions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialNeedAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specialNeedAttrition = await _context.SpecialNeedAttrition.FindAsync(id);
            if (specialNeedAttrition == null)
            {
                return NotFound();
            }

            _context.SpecialNeedAttrition.Remove(specialNeedAttrition);
            await _context.SaveChangesAsync();

            return Ok(specialNeedAttrition);
        }

        private bool SpecialNeedAttritionExists(int id)
        {
            return _context.SpecialNeedAttrition.Any(e => e.specialNeedAttritionId == id);
        }
    }
}