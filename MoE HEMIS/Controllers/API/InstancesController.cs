﻿using System;
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
    public class InstancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Instances
        [HttpGet]
        public IEnumerable<Instance> GetInstances()
        {
            return _context.Instances;
        }

        // GET: api/Instances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instance = await _context.Instances.FindAsync(id);

            if (instance == null)
            {
                return NotFound();
            }

            return Ok(instance);
        }

        // PUT: api/Instances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstance([FromRoute] int id, [FromBody] Instance instance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instance.InstanceId)
            {
                return BadRequest();
            }

            _context.Entry(instance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstanceExists(id))
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

        // POST: api/Instances
        [HttpPost]
        public async Task<IActionResult> PostInstance([FromBody] Instance instance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Instances.Add(instance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstance", new { id = instance.InstanceId }, instance);
        }

        // DELETE: api/Instances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instance = await _context.Instances.FindAsync(id);
            if (instance == null)
            {
                return NotFound();
            }

            _context.Instances.Remove(instance);
            await _context.SaveChangesAsync();

            return Ok(instance);
        }

        private bool InstanceExists(int id)
        {
            return _context.Instances.Any(e => e.InstanceId == id);
        }
    }
}