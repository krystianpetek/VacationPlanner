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
        public async Task<ActionResult<string>> Login(RestUserLogin request)
        {
            try
            {
                UserLogin? userPassword = await dbContext.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username);
                if (userPassword == null)
                {
                    return BadRequest("User not found.");
                }
                if (!userService.VerifyPasswordHash(request.Password, userPassword.PasswordHash, userPassword.PasswordSalt))
                    return BadRequest("Wrong password.");
            }
            catch (Exception e)
            {
                return $"Error + {e.Message}";
            }

            List<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "")
            };

            return Ok("Logged in");
        }
    }
}