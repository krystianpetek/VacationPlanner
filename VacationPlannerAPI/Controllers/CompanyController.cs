using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;
using VacationPlannerAPI.Services;

namespace VacationPlannerAPI.Controllers
{
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
        public async Task<ActionResult<IEnumerable<RestCompanyResponse>>> Get()
        {
            return await context.Companies.Select(q => new RestCompanyResponse() { CompanyName = q.CompanyName }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RestCompanyResponse>>> GetById([FromRoute] Guid id)
        {
            return await context.Companies.Where(q => q.Id == id).Select(q => new RestCompanyResponse() { CompanyName = q.CompanyName }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RestCompanyRequest request)
        {
            if (request == null)
                return BadRequest("Wrong data from request.");

            if (await context.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username) != null)
                return BadRequest("User name already exist.");

            var newCompany = RestCompanyRegister(request);

            await context.Companies.AddAsync(newCompany);
            await context.SaveChangesAsync();

            return Created(newCompany.Id.ToString(), null); // ToDo
        }

        private Company RestCompanyRegister(RestCompanyRequest request)
        {
            userService.CreatePasswordHash(request.Password!, out byte[] userHash, out byte[] userSalt);

            Guid guidLogin = Guid.NewGuid();
            var newCompany = new Company()
            {
                Id = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                Administrator = new UserLogin()
                {
                    Id = guidLogin,
                    Username = request.Username,
                    Role = new RolePerson() { Id = Guid.NewGuid(), Role = Role.Administrator},
                    PasswordSalt = userSalt,
                    PasswordHash = userHash,
                    PasswordLastChanged = DateTime.Now
                },
                AdministratorId = guidLogin
            };
            return newCompany;
        }
    }
}
