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
    public class EconomicalDisadvantagedGraduatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EconomicalDisadvantagedGraduatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EconomicalDisadvantagedGraduates
        [HttpGet]
        public IEnumerable<EconomicalDisadvantagedGraduate> GetEconomicalDisadvantagedGraduate()
        {
            return _context.EconomicalDisadvantagedGraduate;
        }

        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<EconomicalDisadvantagedGraduate> ByDepartment(int id)
        {
            return _context.EconomicalDisadvantagedGraduate.Where(g => g.DepartmentId == id);
        }

        // GET: api/EconomicalDisadvantagedGraduates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEconomicalDisadvantagedGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedGraduate = await _context.EconomicalDisadvantagedGraduate.FindAsync(id);

            if (economicalDisadvantagedGraduate == null)
            {
                return NotFound();
            }

            return Ok(economicalDisadvantagedGraduate);
        }

        // PUT: api/EconomicalDisadvantagedGraduates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEconomicalDisadvantagedGraduate([FromRoute] int id, [FromBody] EconomicalDisadvantagedGraduate economicalDisadvantagedGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != economicalDisadvantagedGraduate.EconomicalDisadvantagedGraduateId)
            {
                return BadRequest();
            }

            _context.Entry(economicalDisadvantagedGraduate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomicalDisadvantagedGraduateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(economicalDisadvantagedGraduate);
        }

        // POST: api/EconomicalDisadvantagedGraduates
        [HttpPost]
        public async Task<IActionResult> PostEconomicalDisadvantagedGraduate([FromBody] EconomicalDisadvantagedGraduate economicalDisadvantagedGraduate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EconomicalDisadvantagedGraduate.Add(economicalDisadvantagedGraduate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEconomicalDisadvantagedGraduate", new { id = economicalDisadvantagedGraduate.EconomicalDisadvantagedGraduateId }, economicalDisadvantagedGraduate);
        }

        // DELETE: api/EconomicalDisadvantagedGraduates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEconomicalDisadvantagedGraduate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedGraduate = await _context.EconomicalDisadvantagedGraduate.FindAsync(id);
            if (economicalDisadvantagedGraduate == null)
            {
                return NotFound();
            }

            _context.EconomicalDisadvantagedGraduate.Remove(economicalDisadvantagedGraduate);
            await _context.SaveChangesAsync();

            return Ok(economicalDisadvantagedGraduate);
        }

        private bool EconomicalDisadvantagedGraduateExists(int id)
        {
            return _context.EconomicalDisadvantagedGraduate.Any(e => e.EconomicalDisadvantagedGraduateId == id);
        }
    }
}