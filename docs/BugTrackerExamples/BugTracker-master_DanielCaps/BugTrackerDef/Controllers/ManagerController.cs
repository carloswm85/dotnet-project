using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerDef.Data.FileManager;
using BugTrackerDef.Data.Repository;
using BugTrackerDef.Domain;
using BugTrackerDef.Models.AuthModels;
using BugTrackerDef.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerDef.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly IRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileManager _fileManager;

        public ManagerController(IRepository repo,
            UserManager<ApplicationUser> userManager,
            IFileManager fileManager)
        {
            _repo = repo;
            _userManager = userManager;
            _fileManager = fileManager;
        }

        //Project Crud
        //
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
            return RedirectToAction("DetailsProject", "Manager", new { id = project.ProjectID });
        }
        public IActionResult GetAllProjects()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var employee = _repo.GetEmployeeById(user.Employee_ID);
            var projects = new List<Project>();
            foreach (var p in employee.EmployeeProjects)
            {
                projects.Add(p.Project);
            }
            return View(projects);
        }
        public IActionResult DetailsProject(int id)
        {
            var project = _repo.GetProjectById(id);
            var user = _userManager.GetUserAsync(User).Result;

            if (project.CreatorName == user.UserName)
            {
                ViewData["isOwner"] = "true";
            }
            else
            {
                ViewData["isOwner"] = "false";
            }

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
                return RedirectToAction("DetailsProject", "Manager", new { id = project.ProjectID });
            else
                return View(project);
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            _repo.DeleteProject(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");

        }

        //Tickets Crud
        //
        [HttpGet]
        public IActionResult AddTicketToProject(int id)
        {
            ViewData["ProjectId"] = id;
            return View(new TicketViewModel
            {
                Employees = _repo.GetAllEmployees().ToList(),
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
                return RedirectToAction("DetailsProject", "Manager", new { id = projId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid ticket");
                ticket.Employees = _repo.GetAllEmployees();
                ViewData["ProjectId"] = projId;
                return View(ticket);
            }
        }
        public IActionResult GetUserTickets()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var tickets = _repo.GetAllTickets()
                .Where(t => t.EmployeeID == user.Employee_ID);
            return View(tickets);
        }
        public IActionResult DetailsTicket(int id)
        {
            var ticket = _repo.GetTicketById(id);
            var user = _userManager.GetUserAsync(User).Result;
            ViewData["EmployeeID"] = user.Employee_ID;
            if (ticket.EmployeeID == user.Employee_ID)
            {
                ViewData["isOwner"] = "true";
            }
            else
            {
                ViewData["isOwner"] = "false";
            }
            return View(ticket);
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
                    TicketType = ticket.TicketType
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
                return RedirectToAction("DetailsProject", "Manager", new { id = ticket.Project_ID });
            else
                return View(ticket);
        }
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = _repo.GetTicketById(id);
            _fileManager.RemoveImage(ticket.Image);
            _repo.DeleteTicket(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("DetailsProject", "Manager", new { id = ticket.Project_ID });
        }
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

        //Employee Crud
        //
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
            return RedirectToAction("DetailsProject", "Manager", new { id = projId });
        }
        [HttpGet]
        public IActionResult CreateEmployee(int id)
        {
            ViewData["ProjectID"] = id;
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(int id, RegisterViewModel employee)
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

                    return RedirectToAction("AddEmployeeToProject", "Manager", new { id = id });
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
        public IActionResult DetailsEmployee(int id)
        {
            return View(_repo.GetEmployeeById(id));
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
                return RedirectToAction("DetailsEmployee", new { id = employee.EmployeeID });
            else
                return View(employee);
        }
        public async Task<IActionResult> RemoveEmployeeFromProject(int projId, int emplId)
        {
            await _repo.RemoveEmployeeFromProject(projId, emplId);
            return RedirectToAction("DetailsProject", "Manager", new { id = projId });
        }

        //Comments
        public async Task<IActionResult> AddCommentToTicket(int id, Comment comment)
        {
            if (comment != null)
            {
                var ticket = _repo.GetTicketById(id);
                comment.TicketID = id;
                comment.EmployeeID = _userManager.GetUserAsync(User).Result.Employee_ID;
                comment.TimeStamp = DateTime.Now;
                comment.EmployeeName = User.Identity.Name;
                _repo.AddComment(comment);
                ticket.Comments.Add(comment);
                await _repo.SaveChangesAsync();
                return RedirectToAction("DetailsTicket", new { id = id });
            }
            return RedirectToAction("DetailsTicket", new { id = id });
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = _repo.GetCommentById(id);
            _repo.DeleteComment(id);
            await _repo.SaveChangesAsync();

            return RedirectToAction("DetailsTicket", new { id = comment.TicketID });
        }
    }
}
