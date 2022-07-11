using System.Globalization;
using System.Threading.Tasks;
using BugTrackerDef.Data.Repository;
using BugTrackerDef.Domain;
using BugTrackerDef.Models.AuthModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerDef.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
                var user = await _userManager.FindByNameAsync(vm.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This username doesn´t exist");
                    return View();
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    return View(vm);
                }
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                var isManager = await _userManager.IsInRoleAsync(user, "Manager");
                var isUser = await _userManager.IsInRoleAsync(user, "User");
                if (isAdmin)
                {
                    return RedirectToAction("GetAllEmployees", "AdminPanel");
                }
                else if (isManager)
                {
                    return RedirectToAction("GetAllProjects", "Manager");
                }
                else if (isUser)
                {
                    return RedirectToAction("GetUserProjects", "User");
                }
                else
                {
                    return View(vm);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return View(vm);
            }

            
        }

        public IActionResult ChangeUserPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await _userManager.ChangePasswordAsync(user, vm.CurrentPassword, vm.NewPassword);

                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        
                    }
                    return View(vm);
                }
                await _signInManager.RefreshSignInAsync(user);
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("DetailsEmployee", "AdminPanel", new { id = user.Employee_ID });
                }
                else if (User.IsInRole("Manager"))
                {
                    return RedirectToAction("DetailsEmployee", "Manager", new { id = user.Employee_ID });
                }
                else if (User.IsInRole("User"))
                {
                    return RedirectToAction("DetailsEmployee", "User", new { id = user.Employee_ID });
                }

            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }
    }
}
