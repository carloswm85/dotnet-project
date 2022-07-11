using System.Collections.Generic;
using System.Threading.Tasks;
using BugTrackerAPI.Models;

namespace BugTrackerAPI.Data.employees
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int id);
        // Task<IEnumerable<Ticket>> GetAllTickets();
        Task<List<Employee>> GetAllEmployees();
    }
}