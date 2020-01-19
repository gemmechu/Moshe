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
    public class ForeignerStudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ForeignerStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ForeignerStudents
        [HttpGet]
        public IEnumerable<ForeignerStudent> GetForeignerStudents()
        {
            return _context.ForeignerStudents;
        }
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<ForeignerStudent> ByDepartment([FromRoute] int id)
        {
            return _context.ForeignerStudents.Where(e => e.Department.DepartmentId == id);
        }
        // GET: api/ForeignerStudents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetForeignerStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ForeignerStudent = await _context.ForeignerStudents.FindAsync(id);

            if (ForeignerStudent == null)
            {
                return NotFound();
            }

            return Ok(ForeignerStudent);
        }

        // PUT: api/ForeignerStudents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForeignerStudent([FromRoute] int id, [FromBody] ForeignerStudent ForeignerStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ForeignerStudent.ForeignerStudentId)
            {
                return BadRequest();
            }

            _context.Entry(ForeignerStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForeignerStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ForeignerStudent = _context.ForeignerStudents.Include(d => d.Department).FirstOrDefault(d => d.ForeignerStudentId == ForeignerStudent.ForeignerStudentId);
            return Ok(ForeignerStudent);
        }

        // POST: api/ForeignerStudents
        [HttpPost]
        public async Task<IActionResult> PostForeignerStudent([FromBody] ForeignerStudent ForeignerStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ForeignerStudents.Add(ForeignerStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForeignerStudent", new { id = ForeignerStudent.StudentId }, ForeignerStudent);
        }

        // DELETE: api/ForeignerStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForeignerStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ForeignerStudent = await _context.ForeignerStudents.FindAsync(id);
            if (ForeignerStudent == null)
            {
                return NotFound();
            }

            _context.ForeignerStudents.Remove(ForeignerStudent);
            await _context.SaveChangesAsync();

            return Ok(ForeignerStudent);
        }

        private bool ForeignerStudentExists(int id)
        {
            return _context.ForeignerStudents.Any(e => e.StudentId == id);
        }
    }
}