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
    public class EconomicalDisadvantagedAttritionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EconomicalDisadvantagedAttritionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EconomicalDisadvantagedAttritions
        [HttpGet]
        public IEnumerable<EconomicalDisadvantagedAttrition> GetEconomicalDisadvantagedAttrition()
        {
            return _context.EconomicalDisadvantagedAttrition.Include(e=>e.Department);
        }


        // GET: api/StudentAttritions/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<EconomicalDisadvantagedAttrition> ByDepartment([FromRoute] int id)
        {
            return _context.EconomicalDisadvantagedAttrition.Include(e=>e.Department).Where(a => a.DepartmentId == id);
        }

        // GET: api/EconomicalDisadvantagedAttritions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEconomicalDisadvantagedAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedAttrition = await _context.EconomicalDisadvantagedAttrition.FindAsync(id);

            if (economicalDisadvantagedAttrition == null)
            {
                return NotFound();
            }
            return Ok(economicalDisadvantagedAttrition);
        }

        // PUT: api/EconomicalDisadvantagedAttritions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEconomicalDisadvantagedAttrition([FromRoute] int id, [FromBody] EconomicalDisadvantagedAttrition economicalDisadvantagedAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != economicalDisadvantagedAttrition.economicalDisadvantagedAttritionId)
            {
                return BadRequest();
            }

            _context.Entry(economicalDisadvantagedAttrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomicalDisadvantagedAttritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            economicalDisadvantagedAttrition = _context.EconomicalDisadvantagedAttrition.Include(e => e.Department).FirstOrDefault(e => e.economicalDisadvantagedAttritionId == economicalDisadvantagedAttrition.economicalDisadvantagedAttritionId);

            return Ok(economicalDisadvantagedAttrition);
        }

        // POST: api/EconomicalDisadvantagedAttritions
        [HttpPost]
        public async Task<IActionResult> PostEconomicalDisadvantagedAttrition([FromBody] EconomicalDisadvantagedAttrition economicalDisadvantagedAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EconomicalDisadvantagedAttrition.Add(economicalDisadvantagedAttrition);
            await _context.SaveChangesAsync();
            economicalDisadvantagedAttrition = _context.EconomicalDisadvantagedAttrition.Include(e => e.Department).FirstOrDefault(e => e.economicalDisadvantagedAttritionId == economicalDisadvantagedAttrition.economicalDisadvantagedAttritionId);

            return CreatedAtAction("GetEconomicalDisadvantagedAttrition", new { id = economicalDisadvantagedAttrition.economicalDisadvantagedAttritionId }, economicalDisadvantagedAttrition);
        }

        // DELETE: api/EconomicalDisadvantagedAttritions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEconomicalDisadvantagedAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedAttrition = await _context.EconomicalDisadvantagedAttrition.FindAsync(id);
            if (economicalDisadvantagedAttrition == null)
            {
                return NotFound();
            }

            _context.EconomicalDisadvantagedAttrition.Remove(economicalDisadvantagedAttrition);
            await _context.SaveChangesAsync();

            return Ok(economicalDisadvantagedAttrition);
        }

        private bool EconomicalDisadvantagedAttritionExists(int id)
        {
            return _context.EconomicalDisadvantagedAttrition.Any(e => e.economicalDisadvantagedAttritionId == id);
        }
    }
}