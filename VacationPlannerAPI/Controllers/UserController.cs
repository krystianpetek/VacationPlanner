using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserController : ControllerBase
    {
        private readonly VacationPlannerDbContext dbContext;

        public UserController(VacationPlannerDbContext context)
        {
            dbContext = context;
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
                if (!VerifyPasswordHash(request.Password, userPassword.PasswordHash, userPassword.PasswordSalt))
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RestUserLogin request)
        {
            if (request == null)
                return BadRequest("Wrong data from request.");

            if (await dbContext.UsersLogin.FirstOrDefaultAsync(q => q.Username == request.Username) != null)
                return BadRequest("User name already exist.");

            CreatePasswordHash(request.Password, out byte[] userHash, out byte[] userSalt);

            Guid guid = Guid.NewGuid();
            var userLogin = new UserLogin()
            {
                Id = guid,
                Username = request.Username.ToLower(),
                PasswordHash = userHash,
                PasswordSalt = userSalt,
                Role = 0,
                Employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = String.Empty,
                    LastName = String.Empty,
                    NumberOfDays = 0,
                    AvailableNumberOfDays = 0,
                    UserLoginId = guid
                }
            };

            await dbContext.UsersLogin.AddAsync(userLogin);
            await dbContext.SaveChangesAsync();

            return NoContent();
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