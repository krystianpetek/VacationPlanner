using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;
using VacationPlannerAPI.Services;

namespace VacationPlannerAPI.Controllers
{
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
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            return await dbContext.UsersLogin.Select(q => q.Username).ToListAsync();
        }

        [HttpPost("login")]
        public async Task<ActionResult<ClaimsToWPF>> Login(RestUserLogin request)
        {
            if (request is null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Wrong data from request.");

            UserLogin? userPassword = await dbContext.UsersLogin.Include(q=>q.Role).FirstOrDefaultAsync(q => q.Username == request.Username);
            if (userPassword == null)
            {
                return BadRequest("User not found.");
            }
            if (!userService.VerifyPasswordHash(request.Password, userPassword.PasswordHash, userPassword.PasswordSalt))
                return BadRequest("Wrong password.");

            List<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, userPassword.Username),
            new Claim(ClaimTypes.Role, userPassword.Role.Role.ToString())
            };

            return Ok(new ClaimsToWPF { Message = "Logged in", Id = userPassword.Id, Role = userPassword.Role.Role.ToString(), Username = userPassword.Username});
        }
    }
}