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
    public class IntakeCapacitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IntakeCapacitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IntakeCapacities
        [HttpGet]
        public IEnumerable<IntakeCapacity> GetIntakeCapacity()
        {
            return _context.IntakeCapacity;
        }

        [HttpGet]
        [Route("ByDepartment/{id}")]
        public IntakeCapacity ByDepartment(int id)
        {
            return _context.IntakeCapacity.FirstOrDefault(e => e.DepartmentId == id);
        }

        // GET: api/IntakeCapacities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntakeCapacity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var intakeCapacity = await _context.IntakeCapacity.FindAsync(id);

            if (intakeCapacity == null)
            {
                return NotFound();
            }

            return Ok(intakeCapacity);
        }

        // PUT: api/IntakeCapacities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntakeCapacity([FromRoute] int id, [FromBody] IntakeCapacity intakeCapacity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intakeCapacity.IntakeCapacityId)
            {
                return BadRequest();
            }

            _context.Entry(intakeCapacity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeCapacityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPut("AddOrUpdateCompletionRate/{departmentID}")]
        public IActionResult AddOrUpdateCompletionRate([FromBody] IntakeCapacity intakeCapacity, [FromRoute] int departmentID)
        {
            var exists = _context.IntakeCapacity.Where(f => f.DepartmentId == departmentID).Any();
            if (!exists)
            {
                _context.Attach<IntakeCapacity>(intakeCapacity).State = EntityState.Added;
                _context.SaveChanges();
                return Ok(intakeCapacity);
            }
            else
            {
                var cr = _context.IntakeCapacity.Where(f => f.DepartmentId == departmentID).First();
                _context.Update<IntakeCapacity>(cr).State = EntityState.Detached;

                intakeCapacity.IntakeCapacityId = cr.IntakeCapacityId;
                _context.Update<IntakeCapacity>(intakeCapacity).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(intakeCapacity);
            }

        }
        // POST: api/IntakeCapacities
        [HttpPost]
        public async Task<IActionResult> PostIntakeCapacity([FromBody] IntakeCapacity intakeCapacity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IntakeCapacity.Add(intakeCapacity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntakeCapacity", new { id = intakeCapacity.IntakeCapacityId }, intakeCapacity);
        }

        // DELETE: api/IntakeCapacities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntakeCapacity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var intakeCapacity = await _context.IntakeCapacity.FindAsync(id);
            if (intakeCapacity == null)
            {
                return NotFound();
            }

            _context.IntakeCapacity.Remove(intakeCapacity);
            await _context.SaveChangesAsync();

            return Ok(intakeCapacity);
        }

        private bool IntakeCapacityExists(int id)
        {
            return _context.IntakeCapacity.Any(e => e.IntakeCapacityId == id);
        }
    }
}