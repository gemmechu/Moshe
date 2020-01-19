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
    public class UnjustifiableExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnjustifiableExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UnjustifiableExpenses
        [HttpGet]
        public IEnumerable<UnjustifiableExpense> GetUnjustifiableExpense()
        {
            return _context.UnjustifiableExpense;
        }
        [HttpGet]
        [Route("ByInstitution/{id}")]
        public UnjustifiableExpense ByInstitution([FromRoute] int id)
        {
            return _context.UnjustifiableExpense.FirstOrDefault(e => e.InstitutionId == id);
        }
        // GET: api/UnjustifiableExpenses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnjustifiableExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unjustifiableExpense = await _context.UnjustifiableExpense.FindAsync(id);

            if (unjustifiableExpense == null)
            {
                return NotFound();
            }

            return Ok(unjustifiableExpense);
        }

        // PUT: api/UnjustifiableExpenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnjustifiableExpense([FromRoute] int id, [FromBody] UnjustifiableExpense unjustifiableExpense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unjustifiableExpense.UnjustifiableExpenseId)
            {
                return BadRequest();
            }

            _context.Entry(unjustifiableExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnjustifiableExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPut("AddOrUpdateCompletionRate/{universityId}")]
        public IActionResult AddOrUpdateCompletionRate([FromBody] UnjustifiableExpense unjustifiableExpense, [FromRoute] int universityId)
        {
            var exists = _context.UnjustifiableExpense.Where(f => f.InstitutionId == universityId).Any();
            if (!exists)
            {
                _context.Attach<UnjustifiableExpense>(unjustifiableExpense).State = EntityState.Added;
                _context.SaveChanges();
                return Ok(unjustifiableExpense);
            }
            else
            {
                var cr = _context.UnjustifiableExpense.Where(f => f.InstitutionId == universityId).First();
                _context.Update<UnjustifiableExpense>(cr).State = EntityState.Detached;

                unjustifiableExpense.UnjustifiableExpenseId = cr.UnjustifiableExpenseId;
                _context.Update<UnjustifiableExpense>(unjustifiableExpense).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(unjustifiableExpense);
            }

        }
        // POST: api/UnjustifiableExpenses
        [HttpPost]
        public async Task<IActionResult> PostUnjustifiableExpense([FromBody] UnjustifiableExpense unjustifiableExpense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UnjustifiableExpense.Add(unjustifiableExpense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnjustifiableExpense", new { id = unjustifiableExpense.UnjustifiableExpenseId }, unjustifiableExpense);
        }

        // DELETE: api/UnjustifiableExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnjustifiableExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unjustifiableExpense = await _context.UnjustifiableExpense.FindAsync(id);
            if (unjustifiableExpense == null)
            {
                return NotFound();
            }

            _context.UnjustifiableExpense.Remove(unjustifiableExpense);
            await _context.SaveChangesAsync();

            return Ok(unjustifiableExpense);
        }

        private bool UnjustifiableExpenseExists(int id)
        {
            return _context.UnjustifiableExpense.Any(e => e.UnjustifiableExpenseId == id);
        }
    }
}