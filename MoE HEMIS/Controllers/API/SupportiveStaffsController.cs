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
    public class SupportiveStaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SupportiveStaffsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/SupportiveStaffs/ByCollege/5
        [HttpGet]
        [Route("ByCollege/{id}")] 
        public IEnumerable<SupportiveStaff> ByCollege([FromRoute] int id)
        {
            return _context.SupportiveStaffs.Include(e => e.College).Where(e => e.College.CollegeId == id);
        }

        // GET: api/SupportiveStaffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportiveStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supportiveStaff = await _context.SupportiveStaffs.FindAsync(id);

            if (supportiveStaff == null)
            {
                return NotFound();
            }

            return Ok(supportiveStaff);
        }

        // PUT: api/SupportiveStaffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportiveStaff([FromRoute] int id, [FromBody] SupportiveStaff supportiveStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supportiveStaff.SupportiveStaffId)
            {
                return BadRequest();
            }

            _context.Entry(supportiveStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportiveStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            supportiveStaff = _context.SupportiveStaffs.Include(e => e.College).FirstOrDefault(e => e.SupportiveStaffId == supportiveStaff.SupportiveStaffId);
            return Ok(supportiveStaff); 
        }

        // POST: api/SupportiveStaffs
        [HttpPost]
        public async Task<IActionResult> PostSupportiveStaff([FromBody] SupportiveStaff supportiveStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            _context.SupportiveStaffs.Add(supportiveStaff);
            await _context.SaveChangesAsync();
            supportiveStaff = _context.SupportiveStaffs.Include(e => e.College).FirstOrDefault(e => e.SupportiveStaffId == supportiveStaff.SupportiveStaffId);
            return CreatedAtAction("GetSupportiveStaff", new { id = supportiveStaff.SupportiveStaffId }, supportiveStaff);
        }

        // DELETE: api/SupportiveStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportiveStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supportiveStaff = await _context.SupportiveStaffs.FindAsync(id);
            if (supportiveStaff == null)
            {
                return NotFound();
            }

            _context.SupportiveStaffs.Remove(supportiveStaff);
            await _context.SaveChangesAsync();

            return Ok(supportiveStaff);
        }

        private bool SupportiveStaffExists(int id)
        {
            return _context.SupportiveStaffs.Any(e => e.SupportiveStaffId == id);
        }
    }
}