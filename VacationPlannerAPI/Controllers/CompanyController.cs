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
public class CompanyController : ControllerBase
{
    private readonly VacationPlannerDbContext context;
    private readonly IUserService userService;

    public CompanyController(VacationPlannerDbContext context, IUserService userService)
    {
        this.context = context;
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestCompanyResponse>>> GetCompanies()
    {
        var result = await context.Companies.Select(q => new RestCompanyResponse { CompanyName = q.CompanyName })
            .ToListAsync();
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestCompanyResponse>> GetCompanyById([FromRoute] Guid id)
    {
        var result = await context.Companies.Where(q => q.Id == id)
            .Select(q => new RestCompanyResponse { CompanyName = q.CompanyName }).FirstOrDefaultAsync();
        if (result is null)
            return NotFound(id);

        return Ok(result);
    }

    [HttpGet("ByAdmin/{id}")]
    public async Task<ActionResult<RestCompanyResponse>> GetCompanyByAdminId([FromRoute] Guid id)
    {
        var result = await context.Companies.Where(q => q.AdministratorId == id)
            .Select(q => new RestCompanyResponse { CompanyName = q.CompanyName }).FirstOrDefaultAsync();
        if (result is null)
            return NotFound(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RestCompanyRequest request)
    {
        if (request is null || string.IsNullOrEmpty(request.CompanyName) || string.IsNullOrEmpty(request.Username) ||
            string.IsNullOrEmpty(request.Password))
            return BadRequest("Wrong data from request.");

        if (await context.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username) != null)
            return BadRequest("User name already exist.");

        var newCompany = RestCompanyRegister(request);

        await context.Companies.AddAsync(newCompany);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompanyById), "Company", new { id = newCompany.Id },
            $"{newCompany.CompanyName} account created.");
    }

    private Company RestCompanyRegister(RestCompanyRequest request)
    {
        userService.CreatePasswordHash(request.Password!, out var userHash, out var userSalt);

        var loginId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var newCompany = new Company
        {
            Id = Guid.NewGuid(),
            CompanyName = request.CompanyName,
            Administrator = new UserLogin
            {
                Id = loginId,
                Username = request.Username,
                RoleId = roleId,
                Role = new RolePerson { Id = roleId, Role = Role.Administrator },
                PasswordSalt = userSalt,
                PasswordHash = userHash,
                PasswordLastChanged = DateTime.Now
            },
            AdministratorId = loginId
        };
        return newCompany;
    }
}