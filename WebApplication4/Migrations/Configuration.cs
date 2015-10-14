namespace WebApplication4.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication4.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication4.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication4.Models.ApplicationDbContext context)
        {
             var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "keith.sturzenbecker@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                    {
                        UserName = "keith.sturzenbecker@gmail.com",
                        Email = "keith.sturzenbecker@gmail.com",
                        FirstName = "Keith",
                        LastName = "Sturzenbecker",
                        DisplayName = "Ksturz"
                    },
                        "sturze");
            }

            var userId = userManager.FindByEmail("keith.sturzenbecker@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Roles.Any(r => r.Name == "Mod"))
            {
                roleManager.Create(new IdentityRole { Name = "Mod" });
            }

            var userMod = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userMod.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry.com",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "Coder",
                    LastName = "Foundry",
                    DisplayName = "CoderFnd"
                },
                        "Password-1");
            }

            var userModId = userMod.FindByEmail("moderator@coderfoundry.com").Id;
            userMod.AddToRole(userModId, "Mod");
        
        }
    }
}
