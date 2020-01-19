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
    [Authorize(Roles = "Administrator")]
    public class MainAdminController : Controller
    {

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        

        public MainAdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this._userManager = userManager;
            
            this._context = context;
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Institutions()
        {
            var users = await _userManager.GetUsersInRoleAsync("Institution");
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            foreach (ApplicationUser applicationUser in users)
            {
                if (applicationUser.Status == Status.UNVALIDATED) applicationUsers.Add(applicationUser);
            }

            ViewData["users"] = applicationUsers;

            return View();
        }

        public IActionResult Band()
        {
            return View();
        }

        public IActionResult Budget()
        {
            return View();
        }






    }


}

