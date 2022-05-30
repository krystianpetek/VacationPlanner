using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.Controllers
{
    [ApiController]
    [ApiKey]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly VacationPlannerDbContext dbContext;

        public EmployeeController(VacationPlannerDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            return await dbContext.Employees.Select(q => new { imie = q.FirstName, nazwisko = q.LastName }).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(RestEmployee employee)
        {
            if (employee == null)
                return BadRequest();

            var exists = await dbContext.Employees.SingleOrDefaultAsync(q => q.UserLogin.Username == employee.Username);
            if (exists != null)
                return BadRequest("Users already exists!");

            var userLogin = Register(
                    new RestUserLogin()
                    {
                        Username = employee.Username,
                        Password = employee.Password
                    });

            if (userLogin == null)
                return BadRequest();

            var newEmployee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                NumberOfDays = employee.NumberOfDays,
                AvailableNumberOfDays = employee.AvailableNumberOfDays,
                UserLogin = userLogin,
                PasswordLastChanged = null
            };

            dbContext.Employees.Add(newEmployee);
            await dbContext.SaveChangesAsync();

            return Created(newEmployee.Id.ToString(), null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ChangePassword(Guid id, [FromBody] RestPasswordChange request)
        {
            if (request == null)
                return BadRequest();

            var user = await dbContext.UsersLogin.SingleOrDefaultAsync(q => q.Id == id);
            if (user == null)
                return BadRequest("User doesn't exists");

            CreatePasswordHash(request.OldPassword, out byte[] passwordHash, out byte[] passwordSalt);

            if (!VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong password.");

            if (request.NewPassword != request.RepeatPassword)
                return BadRequest("Password doesn't match, please type correct password!");

            CreatePasswordHash(request.NewPassword, out byte[] newPasswordHash, out byte[] newPasswordSalt);


            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        private UserLogin Register(RestUserLogin request)
        {
            if (request == null) return null;

            var exists = dbContext.UsersLogin.SingleOrDefaultAsync(q => q.Username == request.Username);
            if (exists == null)
                return null;

            CreatePasswordHash(request.Password, out byte[] userHash, out byte[] userSalt);

            return new UserLogin()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = userHash,
                PasswordSalt = userSalt,
                Role = Role.Employee
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
