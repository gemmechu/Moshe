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
    public class StaffTrainingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffTrainingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffTrainings
        [HttpGet]
        public IEnumerable<StaffTraining> GetStaffTrainings()
        {
            return _context.StaffTrainings.Include(e => e.College).Include(e => e.Department);
        }
        // GET: api/StaffTrainings/ByCollege/5
        [HttpGet]
        [Route("ByCollege/{id}")]
        public IEnumerable<StaffTraining> ByCollege([FromRoute] int id)
        {
            return _context.StaffTrainings.Where(e => e.College.CollegeId == id).Include(e => e.College).Include(e => e.Department);
        }

        // GET: api/StaffTrainings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffTraining = await _context.StaffTrainings.FindAsync(id);

            if (staffTraining == null)
            {
                return NotFound();
            }

            return Ok(staffTraining);
        }

        // PUT: api/StaffTrainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffTraining([FromRoute] int id, [FromBody] StaffTraining staffTraining)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffTraining.StaffTrainingId)
            {
                return BadRequest();
            }

            _context.Entry(staffTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffTrainingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            staffTraining = _context.StaffTrainings.Include(e => e.College).Include(e => e.Department).FirstOrDefault(e => e.CollegeId == staffTraining.CollegeId && e.DepartmentId == staffTraining.DepartmentId);
            return Ok(staffTraining);
        }

        // POST: api/StaffTrainings
        [HttpPost]
        public async Task<IActionResult> PostStaffTraining([FromBody] StaffTraining staffTraining)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffTrainings.Add(staffTraining);
            await _context.SaveChangesAsync();
            staffTraining = _context.StaffTrainings.Include(e => e.College).Include(e => e.Department).FirstOrDefault(e => e.CollegeId == staffTraining.CollegeId && e.DepartmentId == staffTraining.DepartmentId);
            return CreatedAtAction("GetStaffTraining", new { id = staffTraining.StaffTrainingId }, staffTraining);
        }

        // DELETE: api/StaffTrainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffTraining = await _context.StaffTrainings.FindAsync(id);
            if (staffTraining == null)
            {
                return NotFound();
            }

            _context.StaffTrainings.Remove(staffTraining);
            await _context.SaveChangesAsync();

            return Ok(staffTraining);
        }

        private bool StaffTrainingExists(int id)
        {
            return _context.StaffTrainings.Any(e => e.StaffTrainingId == id);
        }
    }
}