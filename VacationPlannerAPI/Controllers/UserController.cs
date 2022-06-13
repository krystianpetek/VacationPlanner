using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;
using VacationPlannerAPI.Services;

namespace VacationPlannerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class UserController : ControllerBase
{
    private readonly VacationPlannerDbContext dbContext;
    private readonly IUserService userService;

    public UserController(VacationPlannerDbContext context)
    {
        dbContext = context;
        userService = new UserService();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetUsers()
    {
        return await dbContext.UsersLogin.Select(q => q.Username).ToListAsync();
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ClaimsToWPF>> Login([FromBody] RestUserLogin request)
    {
        if (request is null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Wrong data from request.");

        var userPassword = await dbContext.UsersLogin.Include(q => q.Role)
            .FirstOrDefaultAsync(q => q.Username == request.Username);
        if (userPassword == null) return BadRequest("User not found.");
        if (!userService.VerifyPasswordHash(request.Password, userPassword.PasswordHash, userPassword.PasswordSalt))
            return BadRequest("Wrong password.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, userPassword.Username),
            new(ClaimTypes.Role, userPassword.Role.Role.ToString())
        };

        return Ok(new ClaimsToWPF
        {
            Message = "Logged in", Id = userPassword.Id, Role = userPassword.Role.Role.ToString(),
            Username = userPassword.Username
        });
    }
}