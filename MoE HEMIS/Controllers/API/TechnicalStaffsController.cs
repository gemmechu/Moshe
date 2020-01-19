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
    public class TechnicalStaffsController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TechnicalStaffsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/TechnicalStaffs/ByDepartment/5
        [HttpGet]
        [Route("ByDepartment/{id}")] 
        public IEnumerable<TechnicalStaff> ByDepartment([FromRoute] int id)
        {
            return _context.TechnicalStaffs.Include(e => e.Department).Where(e => e.Department.DepartmentId == id);
        }

        // GET: api/TechnicalStaffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnicalStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technicalStaff = await _context.TechnicalStaffs.FindAsync(id);

            if (technicalStaff == null)
            {
                return NotFound();
            }

            return Ok(technicalStaff);
        }

        // PUT: api/TechnicalStaffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicalStaff([FromRoute] int id, [FromBody] TechnicalStaff technicalStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != technicalStaff.TechnicalStaffId)
            {
                return BadRequest();
            }

            _context.Entry(technicalStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            technicalStaff = _context.TechnicalStaffs.Include(e => e.Department).FirstOrDefault(e => e.TechnicalStaffId == technicalStaff.TechnicalStaffId);
            return Ok(technicalStaff);
        }

        // POST: api/TechnicalStaffs
        [HttpPost]
        public async Task<IActionResult> PostTechnicalStaff([FromBody] TechnicalStaff technicalStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TechnicalStaffs.Add(technicalStaff);
            await _context.SaveChangesAsync();
            technicalStaff = _context.TechnicalStaffs.Include(e => e.Department).FirstOrDefault(e => e.TechnicalStaffId == technicalStaff.TechnicalStaffId);
            return CreatedAtAction("GetTechnicalStaff", new { id = technicalStaff.TechnicalStaffId }, technicalStaff);
        }

        // DELETE: api/TechnicalStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technicalStaff = await _context.TechnicalStaffs.FindAsync(id);
            if (technicalStaff == null)
            {
                return NotFound();
            }

            _context.TechnicalStaffs.Remove(technicalStaff);
            await _context.SaveChangesAsync();

            return Ok(technicalStaff);
        }

        private bool TechnicalStaffExists(int id)
        {
            return _context.TechnicalStaffs.Any(e => e.TechnicalStaffId == id);
        }
    }
}