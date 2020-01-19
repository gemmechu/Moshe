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
    public class AdministrativeStaffsController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministrativeStaffsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: api/AdministrativeStaffs/ByCollege/5
        [HttpGet]
        [Route("ByCollege/{id}")] 
        public IEnumerable<AdministrativeStaff> ByCollege([FromRoute] int id)
        {
            return _context.AdministrativeStaffs.Include(e => e.College).Where(e => e.College.CollegeId == id);
        }

        // GET: api/AdministrativeStaffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministrativeStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var administrativeStaff = await _context.AdministrativeStaffs.FindAsync(id);

            if (administrativeStaff == null)
            {
                return NotFound();
            }

            return Ok(administrativeStaff);
        }

        // PUT: api/AdministrativeStaffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrativeStaff([FromRoute] int id, [FromBody] AdministrativeStaff administrativeStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrativeStaff.AdministrativeStaffId)
            {
                return BadRequest();
            }

            _context.Entry(administrativeStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrativeStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            administrativeStaff = _context.AdministrativeStaffs.Include(e => e.College).FirstOrDefault(e => e.AdministrativeStaffId == administrativeStaff.AdministrativeStaffId);
            return Ok(administrativeStaff);
        }

        // POST: api/AdministrativeStaffs
        [HttpPost]
        public async Task<IActionResult> PostAdministrativeStaff([FromBody] AdministrativeStaff administrativeStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            _context.AdministrativeStaffs.Add(administrativeStaff);
            await _context.SaveChangesAsync();
            administrativeStaff = _context.AdministrativeStaffs.Include(e => e.College).FirstOrDefault(e => e.AdministrativeStaffId == administrativeStaff.AdministrativeStaffId);
            return CreatedAtAction("GetAdministrativeStaff", new { id = administrativeStaff.AdministrativeStaffId }, administrativeStaff);
        }

        // DELETE: api/AdministrativeStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrativeStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var administrativeStaff = await _context.AdministrativeStaffs.FindAsync(id);
            if (administrativeStaff == null)
            {
                return NotFound();
            }

            _context.AdministrativeStaffs.Remove(administrativeStaff);
            await _context.SaveChangesAsync();

            return Ok(administrativeStaff);
        }

        private bool AdministrativeStaffExists(int id)
        {
            return _context.AdministrativeStaffs.Any(e => e.AdministrativeStaffId == id);
        }
    }
}