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
    public class InvestmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvestmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Investments
        [HttpGet]
        public IEnumerable<Investment> GetInvestments()
        {
            return _context.Investments;
        }
        [HttpGet]
        [Route("ByCollege/{id}")]
        public IEnumerable<Investment> ByCollege([FromRoute] int id)
        {
            return _context.Investments.Where(x => x.CollegeId == id);
        }
        // GET: api/Investments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvestment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investment = await _context.Investments.FindAsync(id);

            if (investment == null)
            {
                return NotFound();
            }

            return Ok(investment);
        }

        // PUT: api/Investments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestment([FromRoute] int id, [FromBody] Investment investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investment.InvestmentId)
            {
                return BadRequest();
            }

            _context.Entry(investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            investment = _context.Investments.Include(e => e.College).FirstOrDefault(x => x.InvestmentId == investment.InvestmentId);
            return Ok(investment);
        }

        // POST: api/Investments
        [HttpPost]
        public async Task<IActionResult> PostInvestment([FromBody] Investment investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
            investment = _context.Investments.Include(e => e.College).FirstOrDefault(x => x.InvestmentId == investment.InvestmentId);
            return CreatedAtAction("GetInvestment", new { id = investment.InvestmentId }, investment);
        }

        // DELETE: api/Investments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                return NotFound();
            }

            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();

            return Ok(investment);
        }

        private bool InvestmentExists(int id)
        {
            return _context.Investments.Any(e => e.InvestmentId == id);
        }
    }
}