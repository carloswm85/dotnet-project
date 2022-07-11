using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BugTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BugTrackerAPI.Data.auth
{
    // : tells class that your using x and its methods
    public class AuthRepository : IAuthRepository
    {
        // Db -- Context is the database
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public AuthRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        // Checks Db for employees matching the fullname and email
        public async Task<bool> EmployeeExists(string fullName, string email)
        {
            if (await _context.Employees.AnyAsync(foundEmployee => 
                foundEmployee.FullName == fullName || foundEmployee.Email == email))
                return true;

            return false;
        }

        public object VerifyToken(string employeeFromDbId, string employeeFromDbFullname)
        {
            // avoids unneccessary db calls for Id and fullname
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employeeFromDbId),
                new Claim(ClaimTypes.Name, employeeFromDbFullname)
            };

            // secured key for signing
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescripter);

            return tokenHandler.WriteToken(token);
        }

        // Checks Db for employee macthing the email then verfies the password
        public async Task<Employee> Login(string email, string password)
        {
            // checks database for an employee matching the email
            var employee = await _context.Employees
                .FirstOrDefaultAsync(foundEmployee => foundEmployee.Email == email);

            if (employee == null || !VerifyPasswordHash(password, employee.PasswordSalt, employee.PasswordHash)) 
                return null;

            return employee;
        }

        // Sets the employee hash and salts then asynchronously saves the employee
        public async Task<Employee> Register(Employee employee, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // sets the hash and salts to the employee
            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        // hashes && salts employee entered password
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                /*
                    sets employee passwordSalt to random generate key
                    then computes the passwordHash
                */
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }

        // verifies the user login password to the user found in Db
        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) {
                    // returns false on first string that doesnt match
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            };
            return true;
        }
    }
}