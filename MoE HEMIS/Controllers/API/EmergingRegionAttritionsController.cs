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
    public class EmergingRegionAttritionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmergingRegionAttritionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmergingRegionAttritions
        [HttpGet]
        public IEnumerable<EmergingRegionAttrition> GetEmergingRegionAttritions()
        {
            return _context.EmergingRegionAttritions.Include(e=>e.Department);
        }
        // GET: api/EmergingRegionAttritions/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<EmergingRegionAttrition> ByDepartment([FromRoute] int id)
        {
            return _context.EmergingRegionAttritions.Include(e=>e.Department).Where(a => a.DepartmentId == id);
        }

        // GET: api/EmergingRegionAttritions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmergingRegionAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emergingRegionAttrition = await _context.EmergingRegionAttritions.FindAsync(id);

            if (emergingRegionAttrition == null)
            {
                return NotFound();
            }

            return Ok(emergingRegionAttrition);
        }

        // PUT: api/EmergingRegionAttritions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergingRegionAttrition([FromRoute] int id, [FromBody] EmergingRegionAttrition emergingRegionAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emergingRegionAttrition.emergingRegionAttritionId)
            {
                return BadRequest();
            }

            _context.Entry(emergingRegionAttrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergingRegionAttritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            emergingRegionAttrition = _context.EmergingRegionAttritions.Include(e => e.Department).FirstOrDefault(e => e.emergingRegionAttritionId == emergingRegionAttrition.emergingRegionAttritionId);
            return Ok(emergingRegionAttrition);
        }

        // POST: api/EmergingRegionAttritions
        [HttpPost]
        public async Task<IActionResult> PostEmergingRegionAttrition([FromBody] EmergingRegionAttrition emergingRegionAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmergingRegionAttritions.Add(emergingRegionAttrition);
            await _context.SaveChangesAsync();
            emergingRegionAttrition = _context.EmergingRegionAttritions.Include(e => e.Department).FirstOrDefault(e => e.emergingRegionAttritionId == emergingRegionAttrition.emergingRegionAttritionId);

            return CreatedAtAction("GetEmergingRegionAttrition", new { id = emergingRegionAttrition.emergingRegionAttritionId }, emergingRegionAttrition);
        }

        // DELETE: api/EmergingRegionAttritions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergingRegionAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emergingRegionAttrition = await _context.EmergingRegionAttritions.FindAsync(id);
            if (emergingRegionAttrition == null)
            {
                return NotFound();
            }

            _context.EmergingRegionAttritions.Remove(emergingRegionAttrition);
            await _context.SaveChangesAsync();

            return Ok(emergingRegionAttrition);
        }

        private bool EmergingRegionAttritionExists(int id)
        {
            return _context.EmergingRegionAttritions.Any(e => e.emergingRegionAttritionId == id);
        }
    }
}