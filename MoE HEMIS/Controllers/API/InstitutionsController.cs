using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoE_HEMIS.Data;
using MoE_HEMIS.Models;
using Newtonsoft.Json.Linq;

namespace MoE_HEMIS.Controllers.API
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InstitutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Institutions
        [HttpGet]
        public IEnumerable<Institution> GetInstitutions()
        {
            return _context.Institutions;
        }

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitution([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var institution = await _context.Institutions.FindAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return Ok(institution);
        }

        // PUT: api/Institutions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution([FromRoute] int id, [FromBody] Institution institution)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institution.InstitutionId)
            {
                return BadRequest();
            }
            var savedInstitution = _context.Institutions.FirstOrDefault(i => i.InstanceId == id);
            savedInstitution.Name = institution.Name;
            savedInstitution.Abbrivation = institution.Abbrivation;
            _context.Entry(savedInstitution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(institution);
        }

        public class cleanData
        {
            public string name { get; set; }
            public string abbrivation { get; set; }
            public string username { get; set; }
            public int instanceYear{ get; set; }
            public int instanceSemester { get; set; }
        }


        // POST: api/Institutions
        [HttpPost]
        public async Task<IActionResult> PostInstitution(cleanData cleanData)
        {
            var institution = new Institution();
            var instance = new Instance() { Year = cleanData.instanceYear, Semester = (Semester)cleanData.instanceSemester };
            institution.Name = cleanData.name;
            institution.Abbrivation = cleanData.abbrivation;
            institution.Instance = instance;
            string username = cleanData.username;


            var applicationUser = _context.Users.FirstOrDefault(x => x.UserName==username);
            if (applicationUser != null)
            {
                applicationUser.Status = Status.VALIDATED;
                institution.ApplicationUser = applicationUser;
                institution.UserId = applicationUser.Id;

                _context.Institutions.Add(institution);
                await _context.SaveChangesAsync();

                var ins = _context.Institutions.FirstOrDefault(i => i.UserId == applicationUser.Id);
                applicationUser.Institution = ins.InstitutionId;
                _context.Entry<ApplicationUser>(applicationUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetInstitution", new { id = institution.InstitutionId }, institution);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Institutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var institution = await _context.Institutions.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return Ok(institution);
        }

        private bool InstitutionExists(int id)
        {
            return _context.Institutions.Any(e => e.InstitutionId == id);
        }
    }
}