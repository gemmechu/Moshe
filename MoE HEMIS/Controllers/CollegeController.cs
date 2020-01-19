using System;
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
   
    [Authorize(Roles = "College")]
    public class CollegeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser>  _userManager;

        public CollegeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
           _userManager = userManager;
        }

        [Authorize(Roles = "College")]
        public IActionResult Index()
        {
            return View();
        }  
         

        public async Task<IActionResult> StaffPrograms()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Buildings()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Budget()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> InternalRevenue()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Investment()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> CostSharingReport()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            ViewData["file"] = _context.CostSharingReportFiles.FirstOrDefault(c => c.CollegeId == viewModel.College.CollegeId)?.FilePath;
            return View(viewModel);
        }


        public async Task<IActionResult> AdministrativeStaff()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> SupportiveStaff()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();
            
            return View(viewModel);
        }

        public async Task<IActionResult> StaffTrainings()
        {
            CollegeViewModel viewModel = await getCollegeViewModelAsync();

            return View(viewModel);
        }

        //For reusing purpose

        private College GetCollegeByUserId(string userId)
        {
            return  _context.College.FirstOrDefault(c => c.ApplicationUser.Id == userId);

        }



        private ICollection<Department> GetDepartmentsByCollegeId(int? collegeId)
        {
            return _context.Departments.Where(d => d.CollegeId == collegeId).ToList();
        }

        private async Task<CollegeViewModel> getCollegeViewModelAsync()
        {
            CollegeViewModel viewModel = new CollegeViewModel();
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            College college = GetCollegeByUserId(applicationUser.Id);
            viewModel.College = college;
            ICollection<Department> departments = GetDepartmentsByCollegeId(college.CollegeId);
            viewModel.Departments = departments;
            ICollection<BudgetDescription> budgetDescription = _context.BudgetDescription.ToList();
            viewModel.BudgetDescription = budgetDescription;
            return viewModel;
        }

       
    }
}