using System.Threading.Tasks;
using BugTrackerAPI.Data.employees;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeesController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // routes

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(new {
                 employee = await _repo.GetEmployee(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(int id)
        {
            return Ok(new {
                 employees = await _repo.GetAllEmployees()
            });
        }

    }
}