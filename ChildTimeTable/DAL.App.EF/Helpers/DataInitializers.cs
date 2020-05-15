using System;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class DataInitializers
    {
        public static void MigrateDataBase(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
        
        public static bool DeleteDataBase(ApplicationDbContext context)
        {
            return context.Database.EnsureDeleted();
        }

        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roleNames = new string[]{"User", "Admin"};
            foreach (var roleName in roleNames)
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new AppRole();
                    role.Name = roleName;
                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed!");
                    }
                }
            }
            

            var userName = "admin@kide";
            var passWord = "aA@123";
            var firstName = "Polina";
            var lastName = "Khokhlacheva";
            var user = userManager.FindByNameAsync(userName).Result;
            if (user == null)
            {
                user = new AppUser();
                user.Email = userName;
                user.UserName = userName;
                user.FirstName = firstName;
                user.LastName = lastName;
                
                
                var result = userManager.CreateAsync(user, passWord).Result;
                if (!result.Succeeded)
                {
                    throw new ApplicationException("User creation failed!");
                }
            }

            var roleResult = userManager.AddToRoleAsync(user, "Admin").Result;
            roleResult = userManager.AddToRoleAsync(user, "User").Result;
        }
        public static void SeedData(ApplicationDbContext context)
        {
            
        }
    }
}