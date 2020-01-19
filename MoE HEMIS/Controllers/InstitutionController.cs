using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoE_HEMIS.Data;
using MoE_HEMIS.Models;
using MoE_HEMIS.Models.ViewModels;

namespace MoE_HEMIS.Controllers
{
    [Authorize(Roles = "Institution")]
    public class InstitutionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public InstitutionController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this._userManager = userManager;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Institution")]
        public async Task<IActionResult> College()
        {
            //Get Current User
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            if (applicationUser != null)
            {
                // Get The Institution linked with the current user
                Institution institution = _context.Institutions.ToList().FirstOrDefault(x => x?.ApplicationUser?.Id == applicationUser?.Id);
                // Get the users linked with this institution
                IEnumerable<ApplicationUser> users = _context.Users.ToList().Where(x => x.Institution == institution.InstitutionId);
                // Only show those that are not already linked with a band
                foreach (ApplicationUser user in users)
                {
                    if (user.Status == Status.UNVALIDATED) applicationUsers.Add(user);
                }

                ViewData["bands"] = (IEnumerable<Band>)_context.Bands.ToList();
                ViewData["institutionId"] = institution.InstanceId;



                ViewData["users"] = applicationUsers;
            }
            return View();
        }

        [Authorize(Roles = "Institution")]
        public IActionResult UgReport()
        {

            return View();

        }
        [Authorize(Roles = "Institution")]
        public IActionResult PgReport()
        {

            return View();

        }
 
        [Authorize(Roles = "Institution")]
        public async Task<IActionResult> ManagementDatas()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            Institution institution = _context.Institutions.FirstOrDefault(x => x.UserId == applicationUser.Id);
            InstitutionManagementDatasViewModel viewModel = new InstitutionManagementDatasViewModel();
            viewModel.Institution = institution;

            return View(viewModel);
        }
        [Authorize(Roles = "Institution")]
        public async Task<IActionResult> UnjustifiableExpense()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            Institution institution = _context.Institutions.FirstOrDefault(x => x.UserId == applicationUser.Id);
            ViewData["institutionId"] = institution.InstitutionId;

            return View();
        }
          

        public async Task<IActionResult> Department()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            InstitutionDepartmentsViewModel institutionDepartmentsViewModel = new InstitutionDepartmentsViewModel();

            if (applicationUser != null)
            {
                // Get The Institution linked with the current user
                Institution institution = _context.Institutions.ToList().FirstOrDefault(x => x?.ApplicationUser?.Id == applicationUser?.Id);
                institutionDepartmentsViewModel.Institution = institution;
                // Get the users linked with this institution
                IEnumerable<ApplicationUser> users = _context.Users.ToList().Where(x => x.Institution == institution.InstitutionId);
                // Only show those that are not already linked with a college
                foreach (ApplicationUser user in users)
                {
                    IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
                    foreach (string currentRole in roles)
                    {
                        if (user.Status == Status.UNVALIDATED && currentRole == "Department")
                        {
                            applicationUsers.Add(user);
                            break;
                        }
                    }
                }
                ViewData["colleges"] =_context.College.Where(c => c.Institution.UserId == applicationUser.Id).ToList();
                ViewData["users"] = applicationUsers;
            }
            return View(institutionDepartmentsViewModel);

        }


         
    }
}
