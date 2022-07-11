using BugTrackerDef.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTrackerDef.Data.Repository
{
    public interface IRepository
    {
        //Employee Crud
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);


        //Project Crud
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        void AddProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(Project project);

        //Company Crud
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void AddCompany(Company company);
        void DeleteCompany(int id);
        void UpdateCompany(Company company);

        //Ticket Crud
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void AddTicket(int projId, int emplId, Ticket ticket);
        void DeleteTicket(int id);
        void UpdateTicket(Ticket ticket);

        //Comments Crud
        public void AddComment(Comment comment);
        public void DeleteComment(int id);
        public void UpdateComment(Comment comment);
        public Comment GetCommentById(int id);

        Task<bool> SaveChangesAsync();
        
        //Other Tasks
        Task AddNewProjectToEmployee(int employeeId, Project project);
        Task AddNewEmployeeToProject(int projectId, Employee employee);
        Task AddExistingEmployeeToProject(int projectId, int employeeId);
        Task RemoveEmployeeFromProject(int projId, int emplId);
        IEnumerable<Employee> GetEmployeesInProject(int id);

        //Roles
        public List<IdentityUserRole<string>> GetUserRoles();


    }
}
