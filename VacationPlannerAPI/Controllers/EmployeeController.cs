using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Services;
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
        private readonly VacationPlannerDbContext context;
        private readonly IUserService userService;

        public EmployeeController(VacationPlannerDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        [HttpGet("ByCompany/{id}")]
        public async Task<ActionResult<IEnumerable<RestEmployeeResponse>>> GetEmployeeByCompany([FromRoute] Guid id)
        {
            var result = await context.Employees.Where(q=>q.CompanyId == id).Select(q => new RestEmployeeResponse() { FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays, NumberOfDays = q.NumberOfDays} ).ToListAsync();
            if (result is null)
                return NotFound(id);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RestEmployeeResponse>> GetEmployeeById([FromRoute] Guid id)
        {
            var result = await context.Employees.Where(q=>q.Id == id).Select(q => new RestEmployeeResponse() { FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays, NumberOfDays = q.NumberOfDays }).FirstOrDefaultAsync();
            if (result is null)
                return NotFound(id);
            return Ok(result);
        }
        
        [HttpGet("ByUser/{id}")]
        public async Task<ActionResult<RestEmployeeResponse>> GetEmployeeByUserId([FromRoute] Guid id)
        {
            var result = await context.Employees.Where(q=>q.UserLoginId == id).Select(q => new RestEmployeeResponse() { FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays, NumberOfDays = q.NumberOfDays }).FirstOrDefaultAsync();
            if (result is null)
                return NotFound(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromRoute] Guid CompanyId, [FromBody] RestEmployeeRequest request)
        {
            if (request is null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Wrong data from request.");

            if (await context.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username) != null)
                return BadRequest("User name already exist.");

            var newEmployee = RestEmployeeRegister(request);
            newEmployee.CompanyId = CompanyId;

            context.Employees.Add(newEmployee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), "Company", new { id = newEmployee.Id }, $"{newEmployee.UserLogin!.Username}, account created.");
        }

        [HttpPut("ChangePasswordByUser/{id}")]
        public async Task<ActionResult> ChangePasswordByUserId([FromRoute] Guid id, [FromBody] RestPasswordChange request)
        {
            if (request == null)
                return BadRequest();

            var user = await context.UsersLogin.SingleOrDefaultAsync(q => q.Id == id);
            if (user == null)
                return BadRequest("User doesn't exists");

            userService.CreatePasswordHash(request.OldPassword, out byte[] passwordHash, out byte[] passwordSalt);

            if (!userService.VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong password.");

            if (request.NewPassword != request.RepeatPassword)
                return BadRequest("Password doesn't match, please type correct password!");

            userService.CreatePasswordHash(request.NewPassword, out byte[] newPasswordHash, out byte[] newPasswordSalt);

            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            await context.SaveChangesAsync();

            return NoContent();
        }

        private Employee RestEmployeeRegister(RestEmployeeRequest request)
        {
            userService.CreatePasswordHash(request.Password!, out byte[] passwordHash, out byte[] passwordSalt);

            Guid userId = Guid.NewGuid();
            Guid roleId = Guid.NewGuid();
            var newEmployee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                WorkMoreThan10Year = request.WorkMoreThan10Year,
                AvailableNumberOfDays = request.AvailableNumberOfDays,
                UserLogin = new UserLogin()
                {
                    Id = userId,
                    Username = request.Username,
                    Role = new RolePerson() { Id = roleId, Role = Role.Employee },
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                },
                UserLoginId = userId
            };
            return newEmployee;
        }
    }
}
