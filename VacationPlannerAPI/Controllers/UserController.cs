using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.Models.Authentication;

namespace VacationPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserController : ControllerBase
    {
        private readonly VP_DbContext dbContext;

        public UserController(VP_DbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            return await dbContext.login.Select(q => q.Username).ToListAsync();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(User request)
        {
            try
            {
                UserPassword? userPassword = await dbContext.login.FirstOrDefaultAsync(q => q.Username == request.Username);
                if (userPassword == null)
                {
                    return BadRequest("User not found.");
                }
                if (!VerifyPasswordHash(request.Password, userPassword.PasswordHash, userPassword.PasswordSalt))
                    return BadRequest("Wrong password.");
            }
            catch(Exception e)
            {
                return "Błąd";
            }

            List<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "")
            };

            return Ok("IsOK");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User request)
        { 
            if (await dbContext.login.SingleOrDefaultAsync(q => q.Username == request.Username) != null)
                return BadRequest("User name already exist.");

            CreatePasswordHash(request.Password, out byte[] userHash, out byte[] userSalt);

            await dbContext.login.AddAsync(new UserPassword() { Username = request.Username, PasswordHash = userHash, PasswordSalt = userSalt, Role = 0 });
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