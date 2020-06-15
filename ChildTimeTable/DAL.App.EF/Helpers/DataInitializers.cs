using System;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class DataInitializers
    {
        public static void MigrateDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
        public static bool DeleteDatabase(ApplicationDbContext context)
        {
            return context.Database.EnsureDeleted();
        }

        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            /*var user = new AppUser
            {
                UserName = "admin2@kide",
                FirstName = "Polina",
                LastName = "Khokhlacheva",
                Email = "admin@kide",
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(user, "aA@123").Result;
            if (!result.Succeeded)
            {
                throw new ApplicationException("User creation failed!");
            }
            var role = new AppRole();
            role.Name = "Admin";
            role.DisplayName = "Admin";
            roleManager.CreateAsync(role);
            result = userManager.AddToRoleAsync(user, "Admin").Result;*/
            
            
            var roles = new (string roleName, string roleDisplayName)[]
            {
                ("user", "User"),
                ("admin", "Admin")
            };

            foreach (var (roleName, roleDisplayName) in roles)
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new AppRole()
                    {
                        Name = roleName,
                        DisplayName = roleDisplayName
                    };

                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed!");
                    }
                }
            }


            var users = new (string name, string password, string firstName, string lastName, Guid Id)[]
            {
                ("admin3@kide", "aA@123", "Polina", "Khokhlacheva", new Guid("00000000-0000-0000-0000-000000000001")),
            };

            foreach (var userInfo in users)
            {
                var user = userManager.FindByEmailAsync(userInfo.name).Result;
                if (user == null)
                {
                    user = new AppUser()
                    {
                        Id = userInfo.Id,
                        Email = userInfo.name,
                        UserName = userInfo.name,
                        FirstName = userInfo.firstName,
                        LastName = userInfo.lastName,
                        EmailConfirmed = true
                    };
                    var result = userManager.CreateAsync(user, userInfo.password).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("User creation failed!");
                    }
                }

                var roleResult = userManager.AddToRoleAsync(user, "admin").Result;
                roleResult = userManager.AddToRoleAsync(user, "user").Result;
            }
        }
    
        public static void SeedData(ApplicationDbContext context)
        {
            
        }
        

    }
}