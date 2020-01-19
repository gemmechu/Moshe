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
    public class StudentAttritionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentAttritionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentAttritions
        [HttpGet]
        public IEnumerable<StudentAttrition> GetStudentAttritions()
        {
            return _context.StudentAttritions.Include(e => e.Department);
        }

        // GET: api/StudentAttritions/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<StudentAttrition> ByDepartment([FromRoute] int id)
        {
            return _context.StudentAttritions.Include(e => e.Department).Where(a => a.DepartmentId == id);
        }


        // GET: api/StudentAttritions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentAttrition = await _context.StudentAttritions.FindAsync(id);

            if (studentAttrition == null)
            {
                return NotFound();
            }
            return Ok(studentAttrition);
        }

        // PUT: api/StudentAttritions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttrition([FromRoute] int id, [FromBody] StudentAttrition studentAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentAttrition.StudentAttritionId)
            {
                return BadRequest();
            }

            _context.Entry(studentAttrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttritionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            studentAttrition = _context.StudentAttritions.Include(e => e.Department).FirstOrDefault(e => e.StudentAttritionId == studentAttrition.StudentAttritionId);
            return Ok(studentAttrition);
        }

        // POST: api/StudentAttritions
        [HttpPost]
        public async Task<IActionResult> PostStudentAttrition([FromBody] StudentAttrition studentAttrition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentAttritions.Add(studentAttrition);
            await _context.SaveChangesAsync();
            studentAttrition = _context.StudentAttritions.Include(e => e.Department).FirstOrDefault(e => e.StudentAttritionId == studentAttrition.StudentAttritionId);

            return CreatedAtAction("GetStudentAttrition", new { id = studentAttrition.StudentAttritionId }, studentAttrition);
        }

        // DELETE: api/StudentAttritions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAttrition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentAttrition = await _context.StudentAttritions.FindAsync(id);
            if (studentAttrition == null)
            {
                return NotFound();
            }

            _context.StudentAttritions.Remove(studentAttrition);
            await _context.SaveChangesAsync();

            return Ok(studentAttrition);
        }

        private bool StudentAttritionExists(int id)
        {
            return _context.StudentAttritions.Any(e => e.StudentAttritionId == id);
        }
    }
}