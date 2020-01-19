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
    public class ManagementDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManagementDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManagementDatas
        [HttpGet]
        public IEnumerable<ManagementData> GetManagementData()
        {
            return _context.ManagementData.Include(e => e.Institution);
        }
        // GET: api/ManagementDatas/ByCollege/5
        [HttpGet]
        [Route("ByInstitution/{id}")]
        public IEnumerable<ManagementData> ByInstitution([FromRoute] int id)
        {
            return _context.ManagementData.Where(e => e.Institution.InstitutionId == id).Include(e => e.Institution);
        }

        // GET: api/ManagementDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManagementData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managementData = await _context.ManagementData.FindAsync(id);

            if (managementData == null)
            {
                return NotFound();
            }

            return Ok(managementData);
        }

        // PUT: api/ManagementDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagementData([FromRoute] int id, [FromBody] ManagementData managementData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != managementData.ManagementDataId)
            {
                return BadRequest();
            }

            _context.Entry(managementData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            managementData = _context.ManagementData.Include(e => e.Institution).FirstOrDefault(e => e.InstitutionId == managementData.InstitutionId);
            return Ok(managementData);
        }

        // POST: api/ManagementDatas
        [HttpPost]
        public async Task<IActionResult> PostManagementData([FromBody] ManagementData managementData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ManagementData.Add(managementData);
            await _context.SaveChangesAsync();
            managementData = _context.ManagementData.Include(e => e.Institution).FirstOrDefault(e => e.InstitutionId == managementData.InstitutionId);
            return CreatedAtAction("GetManagementData", new { id = managementData.ManagementDataId }, managementData);
        }

        // DELETE: api/ManagementDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagementData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managementData = await _context.ManagementData.FindAsync(id);
            if (managementData == null)
            {
                return NotFound();
            }

            _context.ManagementData.Remove(managementData);
            await _context.SaveChangesAsync();

            return Ok(managementData);
        }

        private bool ManagementDataExists(int id)
        {
            return _context.ManagementData.Any(e => e.ManagementDataId == id);
        }
    }
}