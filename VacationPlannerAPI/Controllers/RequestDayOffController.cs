using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class RequestDayOffController : ControllerBase
    {
        private VacationPlannerDbContext dbContext;
        public RequestDayOffController(VacationPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] RestDayOffRequest request)
        {
            if (request == null)
                return BadRequest();

            DayOffRequest dayOffRequest = new DayOffRequest()
            {
                EmployeeId = id,
                RequestDate = DateTime.Now,
                TypeOfRequest = request.TypeOfRequest,
                DayOffRequestDate = request.DayOffRequestDate,
                Id = Guid.NewGuid()
            };

            await dbContext.AddAsync(dayOffRequest);
            await dbContext.SaveChangesAsync();

            return Created(dayOffRequest.Id.ToString(), dayOffRequest);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RestDayOffRequest>>> GetById(Guid id)
        {
            var dayOffRequest = await dbContext.DayOffRequests.Where(x=> x.EmployeeId == id).ToListAsync();
            if(dayOffRequest.Count <= 0)
                return NotFound();

            return Ok(dayOffRequest);
        }

        [HttpGet]
        public async Task<ActionResult<List<DayOffRequest>>> GetAll()
        {
            var allRequests = await dbContext.DayOffRequests.ToListAsync();

            if (allRequests.Count <= 0)
                return NotFound();

            return Ok(allRequests);
        }

    }
}
