using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class CostSharingReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public CostSharingReportsController(ApplicationDbContext context, IHostingEnvironment appEnvironment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;

        }

        // GET: api/CostSharingReports
        [HttpGet]
        public IEnumerable<CostSharingReport> GetCostSharingReport()
        {
            return _context.CostSharingReport;
        }


        [HttpGet("ByCollege/{id}")]
        public IEnumerable<CostSharingReport> ByCollege(int id)
        {
            return _context.CostSharingReport.Where(e => e.CollegeId == id);
        }

        // GET: api/CostSharingReports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCostSharingReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costSharingReport = await _context.CostSharingReport.FindAsync(id);

            if (costSharingReport == null)
            {
                return NotFound();
            }

            return Ok(costSharingReport);
        }

        // PUT: api/CostSharingReports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostSharingReport([FromRoute] int id, [FromBody] CostSharingReport costSharingReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costSharingReport.CostSharingReportId)
            {
                return BadRequest();
            }

            _context.Entry(costSharingReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostSharingReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(costSharingReport);
        }

        // POST: api/CostSharingReports
        [HttpPost]
        public async Task<IActionResult> PostCostSharingReport([FromBody] CostSharingReport costSharingReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CostSharingReport.Add(costSharingReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostSharingReport", new { id = costSharingReport.CostSharingReportId }, costSharingReport);
        }

        // DELETE: api/CostSharingReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostSharingReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costSharingReport = await _context.CostSharingReport.FindAsync(id);
            if (costSharingReport == null)
            {
                return NotFound();
            }

            _context.CostSharingReport.Remove(costSharingReport);
            await _context.SaveChangesAsync();

            return Ok(costSharingReport);
        }

        private bool CostSharingReportExists(int id)
        {
            return _context.CostSharingReport.Any(e => e.CostSharingReportId == id);
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            //
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            var college = _context.College.Include(c => c.Institution).FirstOrDefault(c => c.ApplicationUserId == applicationUser.Id);
            Institution institution = college.Institution;

            // full path to file in temp location
            string webRoot = _appEnvironment.WebRootPath;
            var folder = Path.Combine("upload",institution.Name.Replace(" ",""));
            var fileName = Guid.NewGuid().ToString() + file.FileName.Replace(" ", "");
            var filePath = Path.Combine(webRoot,folder,fileName);

            System.IO.Directory.CreateDirectory(folder);
            if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

            var reportFile = _context.CostSharingReportFiles.FirstOrDefault(c => c.CollegeId == college.CollegeId);
            if(reportFile != null)
            {
                _context.CostSharingReportFiles.Remove(reportFile);
                _context.SaveChanges();
            }

            var newReportFile = new CostSharingReportFile { CollegeId = college.CollegeId, College = college, FilePath = "\\" + Path.Combine(folder, fileName) };
            _context.CostSharingReportFiles.Add(newReportFile);
            _context.SaveChanges();

            return Ok(new { filePath });
        }
    }
}