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
    [Authorize(Roles = "Department")]
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DepartmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> Enrollments()
        {
            DepartmentViewModel viewModel = await getViewModelAsync(); 
            return View(viewModel);
        }

        
        public async Task<IActionResult> EconomicalDisadvantagedEnrollments()
        {
            DepartmentViewModel viewModel = await getViewModelAsync(); 
            return View(viewModel);
        }
                

        public async Task<IActionResult> RuralEnrollments()
        {
            DepartmentViewModel viewModel = await getViewModelAsync(); 
            return View(viewModel);
        }



        public async Task<IActionResult> EnrollmentByAge()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

          
        public async Task<IActionResult> Expatriate()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }


        public async Task<IActionResult> Graduates()
        {

            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }


        public async Task<IActionResult> EconomicalDisadvantagedGraduates()
        {

            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        

        public async Task<IActionResult> RuralGraduates()
        {

            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> SpecialNeedGraduates()
        {

            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> PostGraduateResearchPublications()
        {

            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }



        public async Task<IActionResult> ForeignerStudent()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> DisabledStudents()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> ForeignerStudents()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> StudentAttritions()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> CompletionRates()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> InTakeCapacities()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
         
        public async Task<IActionResult> EmergingRegionEnrollments()
        {
            ApplicationUser loggedInUser = await _userManager.GetUserAsync(HttpContext.User);

            Department department = _context.Departments.FirstOrDefault(d => d.ApplicationUserId == loggedInUser.Id);
            ViewData["departmentId"] = department.DepartmentId;
            return View();
        }
        public async Task<IActionResult> PastoralRegionEnrollments()
        {
            ApplicationUser loggedInUser = await _userManager.GetUserAsync(HttpContext.User);

            Department department = _context.Departments.FirstOrDefault(d => d.ApplicationUserId == loggedInUser.Id);
            ViewData["departmentId"] = department.DepartmentId;
            return View();
        }
         

        private async Task<DepartmentViewModel> getViewModelAsync()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel() { Department = department };
            return viewModel;
        }
        public async Task<IActionResult> Internships()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentInternshipsViewModel viewModel = new DepartmentInternshipsViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }
        public async Task<IActionResult> NewEnrollment()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentNewEnrollmentsViewModel viewModel = new DepartmentNewEnrollmentsViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }
        public async Task<IActionResult> ResearchPapers()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentResearchPapersViewModel viewModel = new DepartmentResearchPapersViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }

        public async Task<IActionResult> ProspectiveGraduate()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentProspectiveGraduatesViewModel viewModel = new DepartmentProspectiveGraduatesViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }

        public async Task<IActionResult> AcademicStaff()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }



        public async Task<IActionResult> AcademicStaffStudyLeave()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }
        public async Task<IActionResult> AcademicStaffUpgrading()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }

        public async Task<IActionResult> StaffAttrition()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            return View(viewModel);
        }
        public async Task<IActionResult> TechnicalStaff()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            return View(viewModel);
        } 

        public async Task<IActionResult> StaffPublications()
        {
            Department department = await GetDepartmentByUserId();
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Department = department;
            viewModel.AcademicStaffs = _context.AcademicStaffs.Where(d => d.departmentId == department.DepartmentId);
            return View(viewModel);
        } 

        private async Task<Department> GetDepartmentByUserId()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            Department department = _context.Departments.FirstOrDefault(c => c.ApplicationUserId == applicationUser.Id);
            return department;
        }

        public async Task<IActionResult> EmergingRegionAttritions()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> RuralAttritions()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> EconomicalDisadvantagedAttritions()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> SpecialNeedAttritions()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> GraduatesTotalExitExamination()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> GraduatesTotalExitExaminationByEconomy()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> GraduatesTotalExitExaminationByDisability()
        {
            DepartmentViewModel viewModel = await getViewModelAsync();
            return View(viewModel);
        }

    }
}