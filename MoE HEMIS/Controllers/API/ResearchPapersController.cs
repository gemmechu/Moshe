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
    public class ResearchPapersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResearchPapersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ResearchPapers
        [HttpGet]
        public IEnumerable<ResearchPaper> GetResearchPapers()
        {
            return _context.ResearchPapers.Include(e=>e.Department);
        }

        // GET: api/ResearchPapers/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<ResearchPaper> ByDepartment([FromRoute] int id)
        {
            return _context.ResearchPapers.Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/ResearchPapers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResearchPaper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var researchPaper = await _context.ResearchPapers.FindAsync(id);

            if (researchPaper == null)
            {
                return NotFound();
            }
            return Ok(researchPaper);
        }

        // PUT: api/ResearchPapers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchPaper([FromRoute] int id, [FromBody] ResearchPaper researchPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != researchPaper.ResearchPaperId)
            {
                return BadRequest();
            }

            _context.Entry(researchPaper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchPaperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            researchPaper = _context.ResearchPapers.Include(e => e.Department).FirstOrDefault(e => e.DepartmentId == researchPaper.DepartmentId);
            return Ok(researchPaper);
        }

        // POST: api/ResearchPapers
        [HttpPost]
        public async Task<IActionResult> PostResearchPaper([FromBody] ResearchPaper researchPaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ResearchPapers.Add(researchPaper);
            await _context.SaveChangesAsync();
            researchPaper = _context.ResearchPapers.Include(e => e.Department).FirstOrDefault(e => e.DepartmentId == researchPaper.DepartmentId);
            return CreatedAtAction("GetResearchPaper", new { id = researchPaper.ResearchPaperId }, researchPaper);
        }

        // DELETE: api/ResearchPapers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchPaper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var researchPaper = await _context.ResearchPapers.FindAsync(id);
            if (researchPaper == null)
            {
                return NotFound();
            }

            _context.ResearchPapers.Remove(researchPaper);
            await _context.SaveChangesAsync();

            return Ok(researchPaper);
        }

        private bool ResearchPaperExists(int id)
        {
            return _context.ResearchPapers.Any(e => e.ResearchPaperId == id);
        }
    }
}