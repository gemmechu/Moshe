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

namespace MoE_HEMIS.Controllers.API
{
    [Authorize(Roles = "Institution")]
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CollegesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Colleges
        [HttpGet]
        public IEnumerable<College> GetCollege()
        {
            return _context.College;
        }

        // GET: api/Colleges/ByInstitution
        [HttpGet("ByInstitution/{id}")]
        public IEnumerable<College> ByInstitution([FromRoute] int id)
        {
            return _context.College.Where(c => c.InstitutionId == id);
        }

        // GET: api/Colleges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollege([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var college = await _context.College.FindAsync(id);

            if (college == null)
            {
                return NotFound();
            }

            return Ok(college);
        }

        // PUT: api/Colleges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollege([FromRoute] int id, [FromBody] College college)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != college.CollegeId)
            {
                return BadRequest();
            }

            _context.Entry(college).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(college);
        }
        public class cleanData
        {
            public int band { get; set; }
            public string name { get; set; }
            public string username { get; set; }
        }


        // POST: api/Colleges
        [HttpPost]
        public async Task<IActionResult> PostCollege(cleanData cleanData)
        {
            var college = new College();
            ApplicationUser user= _context.Users.FirstOrDefault(x=>x.UserName == cleanData.username);
            if (user != null)
            {
                college.ApplicationUser = user;
                college.ApplicationUserId = user.Id;
                user.Status = Status.VALIDATED;
                college.Band = _context.Bands.FirstOrDefault(x => x.BandId == cleanData.band);
        
                college.Name = cleanData.name;
                ApplicationUser loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
                if (loggedInUser != null)
                {
                    Institution institution = _context.Institutions.FirstOrDefault(x => x.ApplicationUser.Id == loggedInUser.Id);
                    if (institution != null)
                    {
                        college.Institution = institution;
                        college.InstitutionId = institution.InstitutionId;
                        _context.College.Add(college);
                        await _context.SaveChangesAsync();

                        user.College = college.CollegeId;
                        _context.Entry<ApplicationUser>(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Ok(college);
                    }
                }
            }
            return BadRequest(ModelState);

        }

        // DELETE: api/Colleges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollege([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var college = await _context.College.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }

            _context.College.Remove(college);
            await _context.SaveChangesAsync();

            return Ok(college);
        }

        private bool CollegeExists(int id)
        {
            return _context.College.Any(e => e.CollegeId == id);
        }
    }
}