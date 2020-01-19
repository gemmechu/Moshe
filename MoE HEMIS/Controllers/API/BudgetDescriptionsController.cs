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
    public class BudgetDescriptionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BudgetDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BudgetDescriptions
        [HttpGet]
        public IEnumerable<BudgetDescription> GetBudgetDescription()
        {
            return _context.BudgetDescription;
        }

        // GET: api/BudgetDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetDescription = await _context.BudgetDescription.FindAsync(id);

            if (budgetDescription == null)
            {
                return NotFound();
            }

            return Ok(budgetDescription);
        }

        // PUT: api/BudgetDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgetDescription([FromRoute] int id, [FromBody] BudgetDescription budgetDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != budgetDescription.BudgetDescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(budgetDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetDescriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(budgetDescription);
        }

        // POST: api/BudgetDescriptions
        [HttpPost]
        public async Task<IActionResult> PostBudgetDescription([FromBody] BudgetDescription budgetDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BudgetDescription.Add(budgetDescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgetDescription", new { id = budgetDescription.BudgetDescriptionId }, budgetDescription);
        }

        // DELETE: api/BudgetDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetDescription = await _context.BudgetDescription.FindAsync(id);
            if (budgetDescription == null)
            {
                return NotFound();
            }

            _context.BudgetDescription.Remove(budgetDescription);
            await _context.SaveChangesAsync();

            return Ok(budgetDescription);
        }

        private bool BudgetDescriptionExists(int id)
        {
            return _context.BudgetDescription.Any(e => e.BudgetDescriptionId == id);
        }
    }
}