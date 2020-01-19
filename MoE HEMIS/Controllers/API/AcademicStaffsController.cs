using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoE_HEMIS.Data;
using MoE_HEMIS.Models;

namespace MoE_HEMIS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicStaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 

        public AcademicStaffsController(ApplicationDbContext context)
        {
            _context = context; 
        }


        // GET: api/AcademicStaffs/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IEnumerable<AcademicStaff> ByDepartment([FromRoute] int id)
        {
            return _context.AcademicStaffs.Include(e=>e.Department).Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/AcademicStaffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcademicStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var academicStaff = await _context.AcademicStaffs.FindAsync(id);

            if (academicStaff == null)
            {
                return NotFound();
            }

            return Ok(academicStaff);
        }

        // PUT: api/AcademicStaffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicStaff([FromRoute] int id, [FromBody] AcademicStaff academicStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != academicStaff.AcademicStaffId)
            {
                return BadRequest();
            }

            _context.Entry(academicStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            academicStaff = _context.AcademicStaffs.Include(e => e.Department).FirstOrDefault(e => e.AcademicStaffId == academicStaff.AcademicStaffId);
            return Ok(academicStaff);
        }

        // POST: api/AcademicStaffs
        [HttpPost]
        public async Task<IActionResult> PostAcademicStaff([FromBody] AcademicStaff academicStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AcademicStaffs.Add(academicStaff);
            await _context.SaveChangesAsync();
            academicStaff = _context.AcademicStaffs.Include(e => e.Department).FirstOrDefault(e => e.AcademicStaffId == academicStaff.AcademicStaffId);
            return CreatedAtAction("GetAcademicStaff", new { id = academicStaff.AcademicStaffId }, academicStaff);
        }

        // DELETE: api/AcademicStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var academicStaff = await _context.AcademicStaffs.FindAsync(id);
            if (academicStaff == null)
            {
                return NotFound();
            }

            _context.AcademicStaffs.Remove(academicStaff);
            await _context.SaveChangesAsync();

            return Ok(academicStaff);
        }

        private bool AcademicStaffExists(int id)
        {
            return _context.AcademicStaffs.Any(e => e.AcademicStaffId == id);
        }
    }
}