using System.Threading.Tasks;
using BugTrackerAPI.Models;

namespace BugTrackerAPI.Data.auth
{
    /* 
    Repository Patterns allows all of your code to use objects without having to know how the objects are persisted.
    All of the knowledge of persistence, including mapping from tables to objects, is safely contained in the repository.
    */
    public interface IAuthRepository
    {
        // checks if email exists in DB
        Task<bool> EmployeeExists(string fullName, string email);
        // register method
        Task<Employee> Register(Employee employee, string password);
        // login method
        Task<Employee> Login(string email, string password);
        object VerifyToken(string employeeFromDbId, string employeeFromDbFullname);
    }
}