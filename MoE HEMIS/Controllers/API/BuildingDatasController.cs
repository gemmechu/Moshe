using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoE_HEMIS.Data;
using MoE_HEMIS.Models;

namespace MoE_HEMIS.Controllers.API
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BuildingDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BuildingDatas
        [HttpGet]
        public IEnumerable<BuildingData> GetBuildingDatas()
        {
            return _context.BuildingDatas.Include(e => e.College);
        }
        // GET: api/BuildingDatas/ByCollege/5
        [HttpGet]
        [Route("ByCollege/{id}")]
        public IEnumerable<BuildingData> ByCollege([FromRoute] int id)
        {
            return _context.BuildingDatas.Include(e=>e.College).Where(e => e.CollegeId == id);
        }

        // GET: api/BuildingDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildingData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buildingData = await _context.BuildingDatas.FindAsync(id);

            if (buildingData == null)
            {
                return NotFound();
            }

            return Ok(buildingData);
        }

        // PUT: api/BuildingDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingData([FromRoute] int id, [FromBody] BuildingData buildingData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buildingData.BuildingDataId)
            {
                return BadRequest();
            }

            _context.Entry(buildingData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            buildingData = _context.BuildingDatas.Include(e => e.College).FirstOrDefault(e => e.BuildingDataId == buildingData.BuildingDataId);
            return Ok(buildingData);
        }

        // POST: api/BuildingDatas
        [HttpPost]
        public async Task<IActionResult> PostBuildingData([FromBody] BuildingData buildingData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BuildingDatas.Add(buildingData);
            await _context.SaveChangesAsync();
            buildingData = _context.BuildingDatas.Include(e => e.College).FirstOrDefault(e => e.BuildingDataId == buildingData.BuildingDataId);
            return CreatedAtAction("GetBuildingData", new { id = buildingData.BuildingDataId }, buildingData);
        }

        // DELETE: api/BuildingDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var buildingData = await _context.BuildingDatas.FindAsync(id);
            if (buildingData == null)
            {
                return NotFound();
            }

            _context.BuildingDatas.Remove(buildingData);
            await _context.SaveChangesAsync();

            return Ok(buildingData);
        }

        private bool BuildingDataExists(int id)
        {
            return _context.BuildingDatas.Any(e => e.BuildingDataId == id);
        }
    }
}