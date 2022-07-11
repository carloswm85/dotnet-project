using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BugTrackerAPI.Data.auth;
using BugTrackerAPI.DTOS.auth;
using BugTrackerAPI.DTOS.employee;
using BugTrackerAPI.Models;
using DatingAppAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BugTrackerAPI.Controllers
{
    // www.domain.com/auth
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Injects IAuth methods
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        // routes
        [HttpPost("register")]
        public async Task<IActionResult> Register(EmployeeCreateDTO employeeDTO)
        {
            var validatedFname = employeeDTO.FirstName.FirstCharToUpper();
            var validatedLname = employeeDTO.LastName.FirstCharToUpper();
            var validatedFullName = validatedFname + ' ' + validatedLname;
            var validatedEmail = employeeDTO.Email.ToLower();

            if (await _repo.EmployeeExists(validatedFullName, validatedEmail))
                return BadRequest("Employee fullname or email already exists");

            // new employee schema
            var employeeToCreate = new Employee
            {
                FirstName = validatedFname,
                LastName = validatedLname,
                FullName = validatedFullName,
                Email = validatedEmail
            };

            var createdUser = await _repo.Register(employeeToCreate, employeeDTO.Password);

            // return CreatedAtRoute()
            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(EmployeeLoginDTO employeeDTO)
        {
            // queries Db for matching employee
            var employeeFromDb = await _repo.Login(employeeDTO.Email.ToLower(), employeeDTO.Password);

            if (employeeFromDb == null)
                return StatusCode(403, "Wrong email or password");

            var token = _repo.VerifyToken(employeeFromDb.Id.ToString(), employeeFromDb.FullName);

            // sends token back to client
            return Ok(new
            {
                access_token = token
            });
        }


        [HttpPost("refresh-access-token")]
        public IActionResult VerifyToken(TokenDTO token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token.Access_Token) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
            var name = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;

            var verifiedToken = _repo.VerifyToken(id, name);
            
            return Ok(new
            {
                access_token = verifiedToken
            });

        }
    }
}