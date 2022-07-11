using System.Collections.Generic;
using System.Threading.Tasks;
using BugTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerAPI.Data.employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        // queries db for employee matching the id
        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(foundEmployee => foundEmployee.Id == id);
            
            // will return null if no ticket is found in db
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}