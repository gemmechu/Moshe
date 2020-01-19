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
    public class PostGraduateResearchPublicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostGraduateResearchPublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PostGraduateResearchPublications
        [HttpGet]
        public IEnumerable<PostGraduateResearchPublication> GetPostGraduateResearchPublication()
        {
            return _context.PostGraduateResearchPublication;
        }
        [HttpGet("ByDepartment/{id}")]
        public IEnumerable<PostGraduateResearchPublication> ByDepartment(int id)
        {
            return _context.PostGraduateResearchPublication.Where(e => e.DepartmentId == id);
        }

        // GET: api/PostGraduateResearchPublications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostGraduateResearchPublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postGraduateResearchPublication = await _context.PostGraduateResearchPublication.FindAsync(id);

            if (postGraduateResearchPublication == null)
            {
                return NotFound();
            }

            return Ok(postGraduateResearchPublication);
        }

        // PUT: api/PostGraduateResearchPublications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostGraduateResearchPublication([FromRoute] int id, [FromBody] PostGraduateResearchPublication postGraduateResearchPublication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postGraduateResearchPublication.PostGraduateResearchPublicationId)
            {
                return BadRequest();
            }

            _context.Entry(postGraduateResearchPublication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostGraduateResearchPublicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(postGraduateResearchPublication);
        }

        // POST: api/PostGraduateResearchPublications
        [HttpPost]
        public async Task<IActionResult> PostPostGraduateResearchPublication([FromBody] PostGraduateResearchPublication postGraduateResearchPublication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostGraduateResearchPublication.Add(postGraduateResearchPublication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostGraduateResearchPublication", new { id = postGraduateResearchPublication.PostGraduateResearchPublicationId }, postGraduateResearchPublication);
        }

        // DELETE: api/PostGraduateResearchPublications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostGraduateResearchPublication([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postGraduateResearchPublication = await _context.PostGraduateResearchPublication.FindAsync(id);
            if (postGraduateResearchPublication == null)
            {
                return NotFound();
            }

            _context.PostGraduateResearchPublication.Remove(postGraduateResearchPublication);
            await _context.SaveChangesAsync();

            return Ok(postGraduateResearchPublication);
        }

        private bool PostGraduateResearchPublicationExists(int id)
        {
            return _context.PostGraduateResearchPublication.Any(e => e.PostGraduateResearchPublicationId == id);
        }
    }
}