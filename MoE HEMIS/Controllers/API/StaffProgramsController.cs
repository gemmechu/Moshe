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
    public class StaffProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffPrograms
        [HttpGet]
        public IEnumerable<StaffProgram> GetStaffPrograms()
        {
            return _context.StaffPrograms.Include(e=>e.College).Include(e=>e.Department);
        }
        // GET: api/StaffPrograms/ByCollege/5
        [HttpGet]
        [Route("ByCollege/{id}")]
        public IEnumerable<StaffProgram> ByCollege([FromRoute] int id)
        {
            return _context.StaffPrograms.Where(e => e.College.CollegeId == id).Include(e => e.College).Include(e=>e.Department);
        }


        // GET: api/StaffPrograms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffProgram = await _context.StaffPrograms.FindAsync(id);

            if (staffProgram == null)
            {
                return NotFound();
            }

            return Ok(staffProgram);
        }

        // PUT: api/StaffPrograms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffProgram([FromRoute] int id, [FromBody] StaffProgram staffProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffProgram.StaffProgramId)
            {
                return BadRequest();
            }

            _context.Entry(staffProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            staffProgram = _context.StaffPrograms.Include(e=>e.College).Include(e => e.Department).FirstOrDefault(e => e.CollegeId == staffProgram.CollegeId && e.DepartmentId == staffProgram.DepartmentId);
            return Ok(staffProgram);
        }

        // POST: api/StaffPrograms
        [HttpPost]
        public async Task<IActionResult> PostStaffProgram([FromBody] StaffProgram staffProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffPrograms.Add(staffProgram);
            await _context.SaveChangesAsync();
            staffProgram = _context.StaffPrograms.Include(e => e.College).Include(e => e.Department).FirstOrDefault(e => e.CollegeId == staffProgram.CollegeId && e.DepartmentId == staffProgram.DepartmentId);
            return CreatedAtAction("GetStaffProgram", new { id = staffProgram.StaffProgramId }, staffProgram);
        }

        // DELETE: api/StaffPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffProgram = await _context.StaffPrograms.FindAsync(id);
            if (staffProgram == null)
            {
                return NotFound();
            }

            _context.StaffPrograms.Remove(staffProgram);
            await _context.SaveChangesAsync();

            return Ok(staffProgram);
        }

        private bool StaffProgramExists(int id)
        {
            return _context.StaffPrograms.Any(e => e.StaffProgramId == id);
        }
    }
}