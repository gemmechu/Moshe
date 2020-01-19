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
    public class CompletionRatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompletionRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompletionRates
        [HttpGet]
        public IEnumerable<CompletionRate> GetCompletionRates()
        {
            return _context.CompletionRates.Include(e => e.Department);
        }


        [HttpGet]
        [Route("ByDepartment/{id}")]
        public CompletionRate ByDepartment([FromRoute] int id)
        {
            return _context.CompletionRates.FirstOrDefault(e => e.Department.DepartmentId == id);
        }

        // GET: api/CompletionRates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompletionRate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var completionRate = await _context.CompletionRates.FindAsync(id);

            if (completionRate == null)
            {
                return NotFound();
            }

            return Ok(completionRate);
        }

        // PUT: api/CompletionRates/5
        [HttpPut("AddOrUpdateCompletionRate/{departmentID}")]
        public IActionResult AddOrUpdateCompletionRate( [FromBody] CompletionRate completionRate, [FromRoute] int departmentID)
        {
            var compRateExists = _context.CompletionRates.Where(f => f.DepartmentId == departmentID).Any();
            if (!compRateExists)
            {
                _context.Attach<CompletionRate>(completionRate).State = EntityState.Added;
                _context.SaveChanges();
                return Ok(completionRate);
            }
            else
            {
                var cr = _context.CompletionRates.Where(f => f.DepartmentId == departmentID).First();
                _context.Update<CompletionRate>(cr).State = EntityState.Detached;

                completionRate.CompletionRateId = cr.CompletionRateId;
                _context.Update<CompletionRate>(completionRate).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(completionRate);
            }

        }
            
        // PUT: api/CompletionRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompletionRate([FromRoute] int id, [FromBody] CompletionRate completionRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != completionRate.CompletionRateId)
            {
                return BadRequest();
            }

            _context.Entry(completionRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompletionRateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            completionRate = _context.CompletionRates.Include(e => e.Department).FirstOrDefault(e => e.CompletionRateId == completionRate.CompletionRateId);
            return Ok(completionRate);
        }

        // POST: api/CompletionRates
        [HttpPost]
        public async Task<IActionResult> PostCompletionRate([FromBody] CompletionRate completionRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CompletionRates.Add(completionRate);
            await _context.SaveChangesAsync();
            completionRate = _context.CompletionRates.Include(e => e.Department).FirstOrDefault(e => e.CompletionRateId == completionRate.CompletionRateId);
            return CreatedAtAction("GetCompletionRate", new { id = completionRate.CompletionRateId }, completionRate);
        }

        // DELETE: api/CompletionRates
        [HttpDelete]
        public async Task<IActionResult> DeleteCompletionRate()
        {
           

            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [CompletionRates]");
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CompletionRateExists(int id)
        {
            return _context.CompletionRates.Any(e => e.CompletionRateId == id);
        }
    }
}