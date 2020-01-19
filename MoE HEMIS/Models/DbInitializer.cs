using Microsoft.AspNetCore.Identity;
using MoE_HEMIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated(); 
            string role1 = "Administrator";
            string desc1 = "This is the administrator role";

            string role2 = "Institution";
            string desc2 = "This is the institution role";

            string role3 = "College";
            string desc3 = "This is the college role";
            string role4 = "Department";
            string desc4 = "This is the department role";

            string password = "P@$$w0rd";
            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role4) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role4, desc4, DateTime.Now));
            }
            if (await userManager.FindByNameAsync("admin@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0911111111",
                    Status = Status.VALIDATED,
                    Institution = null
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
            } 
        }
    }
}
