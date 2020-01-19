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
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DepartmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.Include(a=>a.ApplicationUser).Include(e=>e.Institution).Include(e=>e.College);
        }
        [HttpGet]
        [Route("ByInstitution/{id}")]
        public IEnumerable<Department> ByInstitution([FromRoute] int id)
        {
            return _context.Departments
                .Include(a => a.ApplicationUser)
                .Include(e=>e.Institution)
                .Include(e=>e.College)
                .Where(e => e.InstitutionId == id);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment([FromRoute] int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            department = _context.Departments
                .Include(a => a.ApplicationUser)
                .Include(a=>a.Institution)
                .Include(a=>a.College)
                .FirstOrDefault(d => d.DepartmentId == department.DepartmentId);

            return Ok(department);
        }
        //public class cleanData
        //{
        //    public int departmentNameId { get; set; }
        //    public int collegeId { get; set; }
        //    public string username { get; set; }
        //}


        // POST: api/Departments
        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            department = _context.Departments
                .Include(a=>a.ApplicationUser).
                Include(a => a.Institution)
                .Include(a => a.College)
                .FirstOrDefault(d => d.DepartmentId == department.DepartmentId);

            ApplicationUser user = _context.Users.FirstOrDefault(e => e.Id == department.ApplicationUserId);
            user.Status = 0;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);

        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return Ok(department);
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}