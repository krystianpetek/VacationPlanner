using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;
using VacationPlannerAPI.Services;

namespace VacationPlannerAPI.Controllers;

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
    public async Task<ActionResult<IEnumerable<SpecialEmployeeResponse>>> GetEmployeeByCompany([FromRoute] Guid id)
    {
        var result = await context.Employees.Where(q => q.CompanyId == id).Select(q => new SpecialEmployeeResponse
        {
            FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays,
            NumberOfDays = q.NumberOfDays, Id = q.Id
        }).ToListAsync();
        if (result is null)
            return NotFound(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestEmployeeResponse>> GetEmployeeById([FromRoute] Guid id)
    {
        var result = await context.Employees.Where(q => q.Id == id).Select(q => new RestEmployeeResponse
        {
            FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays,
            NumberOfDays = q.NumberOfDays
        }).FirstOrDefaultAsync();
        if (result is null)
            return NotFound(id);
        return Ok(result);
    }

    [HttpGet("ByUser/{id}")]
    public async Task<ActionResult<RestEmployeeResponse>> GetEmployeeByUserId([FromRoute] Guid id)
    {
        var result = await context.Employees.Where(q => q.UserLoginId == id).Select(q => new RestEmployeeResponse
        {
            FirstName = q.FirstName, LastName = q.LastName, AvailableNumberOfDays = q.AvailableNumberOfDays,
            NumberOfDays = q.NumberOfDays
        }).FirstOrDefaultAsync();
        if (result is null)
            return NotFound(id);
        return Ok(result);
    }

    [HttpPost("{CompanyId}")]
    public async Task<ActionResult> Register(Guid CompanyId, [FromBody] RestEmployeeRequest request)
    {
        if (request is null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Wrong data from request.");

        if (await context.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username) != null)
            return BadRequest("User name already exist.");

        var newEmployee = RestEmployeeRegister(request);
        newEmployee.CompanyId = CompanyId;

        context.Employees.Add(newEmployee);
        await context.SaveChangesAsync();

        return Created("",$"Employee {newEmployee.UserLogin.Username} created");
    }

    [HttpPut("ChangePasswordByUser/{id}")]
    public async Task<ActionResult> ChangePasswordByUserId([FromRoute] Guid id, [FromBody] RestPasswordChange request)
    {
        if (request == null)
            return BadRequest();

        var user = await context.UsersLogin.SingleOrDefaultAsync(q => q.Id == id);
        if (user == null)
            return BadRequest("User doesn't exists");

        userService.CreatePasswordHash(request.OldPassword, out var passwordHash, out var passwordSalt);

        if (!userService.VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt))
            return BadRequest("Wrong password.");

        if (request.NewPassword != request.RepeatPassword)
            return BadRequest("Password doesn't match, please type correct password!");

        userService.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);

        user.PasswordHash = newPasswordHash;
        user.PasswordSalt = newPasswordSalt;

        await context.SaveChangesAsync();

        return NoContent();
    }

    private Employee RestEmployeeRegister(RestEmployeeRequest request)
    {
        userService.CreatePasswordHash(request.Password!, out var passwordHash, out var passwordSalt);

        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var newEmployee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            WorkMoreThan10Year = request.WorkMoreThan10Years,
            AvailableNumberOfDays = request.AvailableNumberOfDays,
            UserLogin = new UserLogin
            {
                Id = userId,
                Username = request.Username,
                Role = new RolePerson { Id = roleId, Role = Role.Employee },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            },
            UserLoginId = userId
        };
        return newEmployee;
    }
}