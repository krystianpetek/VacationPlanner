using Microsoft.AspNetCore.Mvc;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Services;

namespace VacationPlannerAPI.Controllers
{
    [ApiController]
    [ApiKey]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly VacationPlannerDbContext dbContext;
        private readonly IUserService userService;

        public CompanyController(VacationPlannerDbContext context)
        {
            dbContext = context;
            userService = new UserService();
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
                PasswordLastChanged = null,
                Role = new RolePerson { Id = Guid.NewGuid(), Role = Role.Employee }
            };
        }

        
    }
}
