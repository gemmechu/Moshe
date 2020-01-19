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
    public class EconomicalDisadvantagedEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EconomicalDisadvantagedEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EconomicalDisadvantagedEnrollments
        [HttpGet]
        public IEnumerable<EconomicalDisadvantagedEnrollment> GetEconomicalDisadvantagedEnrollment()
        {
            return _context.EconomicalDisadvantagedEnrollment;
        }

        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<EconomicalDisadvantagedEnrollment> ByDepartment(int id)
        {
            return _context.EconomicalDisadvantagedEnrollment.Where(e => e.DepartmentId == id).ToList();
        }

        // GET: api/EconomicalDisadvantagedEnrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEconomicalDisadvantagedEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedEnrollment = await _context.EconomicalDisadvantagedEnrollment.FindAsync(id);

            if (economicalDisadvantagedEnrollment == null)
            {
                return NotFound();
            }

            return Ok(economicalDisadvantagedEnrollment);
        }

        // PUT: api/EconomicalDisadvantagedEnrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEconomicalDisadvantagedEnrollment([FromRoute] int id, [FromBody] EconomicalDisadvantagedEnrollment economicalDisadvantagedEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != economicalDisadvantagedEnrollment.EconomicalDisadvantagedEnrollmentId)
            {
                return BadRequest();
            }

            _context.Entry(economicalDisadvantagedEnrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EconomicalDisadvantagedEnrollmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(economicalDisadvantagedEnrollment);
        }

        // POST: api/EconomicalDisadvantagedEnrollments
        [HttpPost]
        public async Task<IActionResult> PostEconomicalDisadvantagedEnrollment([FromBody] EconomicalDisadvantagedEnrollment economicalDisadvantagedEnrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EconomicalDisadvantagedEnrollment.Add(economicalDisadvantagedEnrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEconomicalDisadvantagedEnrollment", new { id = economicalDisadvantagedEnrollment.EconomicalDisadvantagedEnrollmentId }, economicalDisadvantagedEnrollment);
        }

        // DELETE: api/EconomicalDisadvantagedEnrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEconomicalDisadvantagedEnrollment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var economicalDisadvantagedEnrollment = await _context.EconomicalDisadvantagedEnrollment.FindAsync(id);
            if (economicalDisadvantagedEnrollment == null)
            {
                return NotFound();
            }

            _context.EconomicalDisadvantagedEnrollment.Remove(economicalDisadvantagedEnrollment);
            await _context.SaveChangesAsync();

            return Ok(economicalDisadvantagedEnrollment);
        }

        private bool EconomicalDisadvantagedEnrollmentExists(int id)
        {
            return _context.EconomicalDisadvantagedEnrollment.Any(e => e.EconomicalDisadvantagedEnrollmentId == id);
        }
    }
}