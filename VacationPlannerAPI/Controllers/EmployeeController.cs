using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VacationPlannerAPI.Authentication;
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
            return await dbContext.Employees.Select(q => new { imie=q.FirstName, nazwisko=q.LastName } ).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(RestEmployee employee)
        {
            if (employee == null)
                return BadRequest();

            var exists = await dbContext.Employees.SingleOrDefaultAsync(q => q.Login.Username == employee.Username);
            if(exists != null)
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
                Login = userLogin,
                PasswordLastChanged = DateTime.MinValue,
            };

            dbContext.Employees.Add(newEmployee);
            await dbContext.SaveChangesAsync();

            return Created(newEmployee.Id.ToString(), null);
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
    }
}
