using System;
using System.Linq;
using BugTrackerDef.Data;
using BugTrackerDef.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BugTrackerDef
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<BT_DbContext>();
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                ctx.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                var managerRole = new IdentityRole("Manager");
                var userRole = new IdentityRole("User");
                if (!ctx.Roles.Any(r => r.Name == "Manager"))
                {
                    roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                    roleMgr.CreateAsync(managerRole).GetAwaiter().GetResult();
                    roleMgr.CreateAsync(userRole).GetAwaiter().GetResult();
                }
                if (!ctx.Users.Any(u => u.UserName == "admin"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@test.com",
                        Employee_ID = 37,
                    };
                    var result = userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
