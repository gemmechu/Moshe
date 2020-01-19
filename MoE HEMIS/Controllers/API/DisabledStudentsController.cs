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
    public class DisabledStudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DisabledStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DisabledStudents
        [HttpGet]
        public IEnumerable<DisabledStudent> GetDisabledStudents()
        {
            return _context.DisabledStudents;
        }
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<DisabledStudent> ByDepartment([FromRoute] int id)
        {
            return _context.DisabledStudents.Where(e => e.Department.DepartmentId == id);
        }
        // GET: api/DisabledStudents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisabledStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disabledStudent = await _context.DisabledStudents.FindAsync(id);

            if (disabledStudent == null)
            {
                return NotFound();
            }

            return Ok(disabledStudent);
        }

        // PUT: api/DisabledStudents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisabledStudent([FromRoute] int id, [FromBody] DisabledStudent disabledStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disabledStudent.DisabledStudentId)
            {
                return BadRequest();
            }

            _context.Entry(disabledStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisabledStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            disabledStudent = _context.DisabledStudents.Include(d => d.Department).FirstOrDefault(d => d.DisabledStudentId == disabledStudent.DisabledStudentId);
            return Ok(disabledStudent);
        }

        // POST: api/DisabledStudents
        [HttpPost]
        public async Task<IActionResult> PostDisabledStudent([FromBody] DisabledStudent disabledStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DisabledStudents.Add(disabledStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisabledStudent", new { id = disabledStudent.StudentId }, disabledStudent);
        }

        // DELETE: api/DisabledStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisabledStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disabledStudent = await _context.DisabledStudents.FindAsync(id);
            if (disabledStudent == null)
            {
                return NotFound();
            }

            _context.DisabledStudents.Remove(disabledStudent);
            await _context.SaveChangesAsync();

            return Ok(disabledStudent);
        }

        private bool DisabledStudentExists(int id)
        {
            return _context.DisabledStudents.Any(e => e.StudentId == id);
        }
    }
}