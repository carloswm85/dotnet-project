using System;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerDef.Data.FileManager;
using BugTrackerDef.Data.Repository;
using BugTrackerDef.Domain;
using BugTrackerDef.Models.AuthModels;
using BugTrackerDef.Models.RoleViewModels;
using BugTrackerDef.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerDef.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roles;
        private readonly IFileManager _fileManager;

        public AdminPanelController(IRepository repo,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roles,
            IFileManager fileManager)
        {
            _repo = repo;
            _userManager = userManager;
            _roles = roles;
            _fileManager = fileManager;
        }

        //Employee Crud
        //
        public IActionResult GetAllEmployees()
        {
            return View(_repo.GetAllEmployees());
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(RegisterViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    UserName = employee.UserName,
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                };
                _repo.AddEmployee(newEmployee);
                await _repo.SaveChangesAsync();

                var user = new ApplicationUser
                {
                    UserName = employee.UserName,
                    Email = employee.Email,
                    Employee_ID = newEmployee.EmployeeID
                };
                var result = await _userManager.CreateAsync(user, employee.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllEmployees");
                }
                else
                {
                    _repo.DeleteEmployee(newEmployee.EmployeeID);
                    await _repo.SaveChangesAsync();
                    ModelState.AddModelError(string.Empty, "Invalid Register Attempt");
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, e.Description);
                    }
                    return View(employee);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Register Attempt");
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            return View(_repo.GetEmployeeById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            _repo.UpdateEmployee(employee);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("DetailsEmployee", "AdminPanel", new { id = employee.EmployeeID });
            else
                return View(employee);
        }
        public IActionResult DetailsEmployee(int id)
        {
            return View(_repo.GetEmployeeById(id));
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Employee_ID == id);
            if(user.UserName == "admin")
            {
                throw new ArgumentException("Can't delete this user");
            }
            await _userManager.DeleteAsync(user);
            _repo.DeleteEmployee(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("GetAllEmployees");
        }
        [HttpGet]
        public IActionResult AddEmployeeToProject(int id)
        {
            var employeesInProject = _repo.GetEmployeesInProject(id);
            var employees = _repo.GetAllEmployees();
            var vm = employees.Except(employeesInProject).ToList();
            ViewData["ProjectID"] = id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeToProject(int projId, int emplId)
        {
            await _repo.AddExistingEmployeeToProject(projId, emplId);
            return RedirectToAction("DetailsProject", "AdminPanel", new { id = projId });
        }
        public async Task<IActionResult> RemoveEmployeeFromProject(int projId, int emplId)
        {
            await _repo.RemoveEmployeeFromProject(projId, emplId);
            return RedirectToAction("DetailsProject", "AdminPanel", new { id = projId });
        }

        //Projects Crud
        //
        public IActionResult GetAllProjects()
        {
            return View(_repo.GetAllProjects());
        }
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View(new Project());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            var user = _userManager.GetUserAsync(User).Result;
            project.CreatorName = user.UserName;
            await _repo.AddNewProjectToEmployee(user.Employee_ID, project);

            return RedirectToAction("DetailsProject", "AdminPanel", new { id = project.ProjectID });
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            _repo.DeleteProject(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }
        public IActionResult DetailsProject(int id)
        {
            var project = _repo.GetProjectById(id);
            return View(project);
        }
        [HttpGet]
        public IActionResult EditProject(int id)
        {
            return View(_repo.GetProjectById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {
            _repo.UpdateProject(project);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("DetailsProject", "AdminPanel", new { id = project.ProjectID });
            else
                return View(project);
        }

        //Tickets Crud
        //
        public IActionResult GetAllTickets()
        {
            return View(_repo.GetAllTickets());
        }
        [HttpGet]
        public IActionResult AddTicketToProject(int id)
        {
            ViewData["ProjectId"] = id;
            return View(new TicketViewModel
            {
                Employees = _repo.GetAllEmployees()
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddTicketToProject(int projId, TicketViewModel ticket)
        {
            ticket.EmployeeID = _userManager.GetUserAsync(User).Result.Employee_ID;
            ticket.Project_ID = projId;
            ticket.ProjectName = _repo.GetProjectById(projId).Name;
            ticket.Submitter = _userManager.GetUserAsync(User).Result.UserName;

            if (ModelState.IsValid)
            {
                var newTicket = new Ticket
                {
                    TicketID = ticket.TicketID,
                    AssignedDev = ticket.AssignedDev,
                    CreatedDate = ticket.CreatedDate,
                    EmployeeID = ticket.EmployeeID,
                    Description = ticket.Description,
                    Project_ID = ticket.Project_ID,
                    ProjectName = ticket.ProjectName,
                    Submitter = ticket.Submitter,
                    TicketPriority = ticket.TicketPriority,
                    TicketStatus = ticket.TicketStatus,
                    TicketType = ticket.TicketType,
                    UpdatedDate = ticket.UpdatedDate,
                    Project = _repo.GetProjectById(ticket.Project_ID),
                };
                var user = _userManager.GetUserAsync(User).Result;
                var emplId = user.Employee_ID;
                if (ticket.Image != null)
                {
                    newTicket.Image = await _fileManager.SaveImage(ticket.Image);

                }
                _repo.AddTicket(projId, emplId, newTicket);
                await _repo.SaveChangesAsync();
                return RedirectToAction("DetailsProject", "AdminPanel", new { id = projId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid ticket");
                ticket.Employees = _repo.GetAllEmployees();
                ViewData["ProjectId"] = projId;
                return View(ticket);
            }
        }
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = _repo.GetTicketById(id);
            _fileManager.RemoveImage(ticket.Image);
            _repo.DeleteTicket(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("GetAllTickets", "AdminPanel");
        }
        public IActionResult DetailsTicket(int id)
        {
            var ticket = _repo.GetTicketById(id);
            return View(ticket);
        }
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
        [HttpGet]
        public IActionResult EditTicket(int? id)
        {
            if (id == null)
            {
                return View(new TicketViewModel());
            }
            else
            {
                var ticket = _repo.GetTicketById((int)id);
                var vm = new TicketViewModel
                {
                    TicketID = ticket.TicketID,
                    AssignedDev = ticket.AssignedDev,
                    CreatedDate = ticket.CreatedDate,
                    UpdatedDate = ticket.UpdatedDate,
                    CurrentImage = ticket.Image,
                    Description = ticket.Description,
                    EmployeeID = ticket.EmployeeID,
                    ProjectName = ticket.ProjectName,
                    Project_ID = ticket.Project_ID,
                    Submitter = ticket.Submitter,
                    TicketPriority = ticket.TicketPriority,
                    TicketStatus = ticket.TicketStatus,
                    TicketType = ticket.TicketType,
                    Employees = _repo.GetAllEmployees()
                };
                return View(vm);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditTicket(TicketViewModel vm)
        {
            var ticket = new Ticket
            {
                TicketID = vm.TicketID,
                AssignedDev = vm.AssignedDev,
                CreatedDate = vm.CreatedDate,
                UpdatedDate = vm.UpdatedDate,
                Description = vm.Description,
                EmployeeID = vm.EmployeeID,
                ProjectName = vm.ProjectName,
                Project_ID = vm.Project_ID,
                Submitter = vm.Submitter,
                TicketPriority = vm.TicketPriority,
                TicketStatus = vm.TicketStatus,
                TicketType = vm.TicketType,
            };
            if (vm.Image == null)
            {
                ticket.Image = vm.CurrentImage;
            }
            else if (!string.IsNullOrEmpty(vm.CurrentImage))
            {
                _fileManager.RemoveImage(vm.CurrentImage);
                ticket.Image = await _fileManager.SaveImage(vm.Image);
            }
            else if (vm.Image != null && vm.CurrentImage == null)
            {
                ticket.Image = await _fileManager.SaveImage(vm.Image);
            }

            ticket.UpdatedDate = DateTime.Now;
            _repo.UpdateTicket(ticket);
            if (await _repo.SaveChangesAsync())
                return RedirectToAction("DetailsProject", "AdminPanel", new { id = ticket.Project_ID });
            else
                return View(ticket);
        }

        //Manage Roles
        //
        public IActionResult RolesIndex()
        {
            var roles = _roles.Roles.ToList();
            var users = _userManager.Users.ToList();
            var userRoles = _repo.GetUserRoles();

            var convertedUsers = users.Select(x => new UsersViewModel
            {
                Email = x.Email,
                Roles = roles
                        .Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
                        .Select(y => new UsersRole
                        {
                            Name = y.NormalizedName
                        })
            });

            return View(new DisplayViewModel
            {
                Roles = roles.Select(x => x.NormalizedName),
                Users = convertedUsers
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel vm)
        {
            await _roles.CreateAsync(new IdentityRole { Name = vm.Name });

            return RedirectToAction("RolesIndex");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel vm)
        {
            if (vm.Role != null && vm.UserEmail != null)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserEmail);

                if (vm.Delete)
                    await _userManager.RemoveFromRoleAsync(user, vm.Role);
                else
                    await _userManager.AddToRoleAsync(user, vm.Role);

                return RedirectToAction("RolesIndex");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You need to select both Role and User");
                return RedirectToAction("RolesIndex");
            }
        }
    }
}
