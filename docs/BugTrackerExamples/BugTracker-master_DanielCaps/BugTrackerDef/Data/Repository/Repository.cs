using BugTrackerDef.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly BT_DbContext _ctx;

        public Repository(BT_DbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddCompany(Company company)
        {
            _ctx.Companies.Add(company);
        }
        public void AddEmployee(Employee employee)
        {
            _ctx.Employees.Add(employee);
        }
        public void AddProject(Project project)
        {
            _ctx.Projects.Add(project);
        }
        public void AddTicket(int projId,int emplId, Ticket ticket) 
        {
            var project = GetProjectById(projId);
            var employee = GetEmployeeById(emplId);

            ticket.EmployeeID = emplId;
            ticket.Project_ID = projId;
            ticket.ProjectName = project.Name;
            ticket.Submitter = employee.UserName;
            ticket.CreatedDate = DateTime.Now;
            ticket.UpdatedDate = DateTime.Now;
            
            _ctx.Tickets.Add(ticket);
            SaveChangesAsync().GetAwaiter().GetResult();
            project.Tickets.Add(ticket);
        }
        public void AddComment(Comment comment)
        {
            _ctx.Comments.Add(comment);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _ctx.Companies.Include(c => c.Employees);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _ctx.Employees
                .Include(e => e.EmployeeProjects)
                .ThenInclude(e => e.Project);
        }
        public IEnumerable<Project> GetAllProjects()
        {
            return _ctx.Projects.Include(p => p.EmployeeProjects)
                .ThenInclude(p => p.Employee).Include(p => p.Tickets);
        }
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ctx.Tickets;
        }

        public Company GetCompanyById(int id)
        {
            return GetAllCompanies().FirstOrDefault(c => c.CompanyID == id);
        }
        public Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().FirstOrDefault(c => c.EmployeeID == id);

        }
        public Project GetProjectById(int id)
        {
            return GetAllProjects().FirstOrDefault(c => c.ProjectID == id);
        }
        public Ticket GetTicketById(int id)
        {
            return _ctx.Tickets.Include(t => t.Comments).FirstOrDefault(c => c.TicketID == id);

        }
        public Comment GetCommentById(int id)
        {
            return _ctx.Comments.FirstOrDefault(c => c.CommentId == id);
        }

        public void UpdateCompany(Company company)
        {
            _ctx.Companies.Update(company);
        }
        public void UpdateEmployee(Employee employee)
        {
            _ctx.Employees.Update(employee);
        }
        public void UpdateProject(Project project)
        {
            _ctx.Projects.Update(project);
        }
        public void UpdateTicket(Ticket ticket)
        {
            _ctx.Tickets.Update(ticket);
        }
        public void UpdateComment(Comment comment)
        {
            _ctx.Comments.Update(comment);
        }

        public void DeleteCompany(int id)
        {
            _ctx.Companies.Remove(_ctx.Companies.FirstOrDefault(c => c.CompanyID == id));
        }
        public void DeleteEmployee(int id)
        {
            _ctx.Employees.Remove(_ctx.Employees.FirstOrDefault(c => c.EmployeeID == id));
        }
        public void DeleteProject(int id)
        {
            _ctx.Projects.Remove(_ctx.Projects.FirstOrDefault(c => c.ProjectID == id));
        }
        public void DeleteTicket(int id)
        {
            _ctx.Tickets.Remove(_ctx.Tickets.FirstOrDefault(c => c.TicketID == id));
        }
        public void DeleteComment(int id)
        {
            var comment = _ctx.Comments.FirstOrDefault(c => c.CommentId == id);
            _ctx.Comments.Remove(comment);
        }

        public async Task AddNewProjectToEmployee(int employeeId, Project project)
        {
            var employee = GetEmployeeById(employeeId);
            if (project != null)
                _ctx.Projects.Add(project);
            await SaveChangesAsync();

            if (project.ProjectID != 0)
            {
                var employeeProjects = new EmployeeProjects
                {
                    EmployeeId = employee.EmployeeID,
                    Employee = employee,
                    ProjectId = project.ProjectID,
                    Project = project
                };
                employee.EmployeeProjects.Add(employeeProjects);
                GetProjectById(project.ProjectID).EmployeeProjects.Add(employeeProjects);
                await SaveChangesAsync();
            }
            else
            {
                throw new InvalidCastException();
            }
        }
        public async Task AddNewEmployeeToProject(int projectId, Employee employee)
        {
            var project = GetProjectById(projectId);
            if (employee != null)
                AddEmployee(employee);
            await SaveChangesAsync();
            if (employee.EmployeeID != 0)
            {
                var employeeProjects = new EmployeeProjects
                {
                    EmployeeId = employee.EmployeeID,
                    Employee = employee,
                    ProjectId = project.ProjectID,
                    Project = project
                };
                project.EmployeeProjects.Add(employeeProjects);
                await _ctx.SaveChangesAsync();
            }
            else
            {
                throw new InvalidCastException();
            }
        }
        public async Task AddExistingEmployeeToProject(int projId, int emplId)
        {
            var project = GetProjectById(projId);
            var employee = GetEmployeeById(emplId);
            if (employee != null && project != null)
            {
                var employeeProjects = new EmployeeProjects
                {
                    EmployeeId = employee.EmployeeID,
                    Employee = employee,
                    ProjectId = project.ProjectID,
                    Project = project,
                };
                project.EmployeeProjects.Add(employeeProjects);
                await SaveChangesAsync();
            }
            else
            {
                throw new InvalidCastException();
            }
        }
        public async Task RemoveEmployeeFromProject(int projId, int emplId)
        {
            var remEmpl = _ctx.EmployeeProjects.
                Where(x => x.EmployeeId == emplId && x.ProjectId == projId).FirstOrDefault();
            _ctx.EmployeeProjects.Remove(remEmpl);
            await SaveChangesAsync();
        }
        public IEnumerable<Employee> GetEmployeesInProject(int id)
        {
            var employeesInProj = _ctx.EmployeeProjects.Include(e => e.Employee)
                .Where(p => p.ProjectId == id);
            List<Employee> employees = new List<Employee>();
            foreach (var e in employeesInProj)
            {
                employees.Add(e.Employee);
            }
            return employees.ToList();
        }
        
        public List<IdentityUserRole<string>> GetUserRoles()
        {
            return _ctx.UserRoles.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
