using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Authentication;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKey]
public class RequestDayOffController : ControllerBase
{
    private readonly VacationPlannerDbContext dbContext;
    private readonly IMapper _mapper;

    public RequestDayOffController(VacationPlannerDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        this.dbContext = dbContext;
    }

    [HttpGet("{companyId}/company")]
    public async Task<ActionResult<IEnumerable<RestDayOffResponse>>> GetRequestsByCompanyId([FromRoute] Guid companyId)
    {
        var query = dbContext.DayOffRequests.Where(q => q.CompanyId == companyId).Include(x=>x.Employee).Include(x=>x.TypeOfLeave);
        var result = _mapper.ProjectTo<RestDayOffResponse>(query).ToList();
        if (result.Count <= 0)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}/employee")]
    public async Task<ActionResult<IEnumerable<RestDayOffResponse>>> GetRequestsByEmployeeId([FromRoute] Guid id)
    {
        var query = dbContext.DayOffRequests.Where(x => x.EmployeeId == id).Include(x => x.Employee).Include(x => x.TypeOfLeave);
        
        var result = _mapper.ProjectTo<RestDayOffResponse>(query).ToList();
        if (result.Count <= 0)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("{employeeId}")]
    public async Task<IActionResult> RegisterRequestByEmployeeId([FromRoute] Guid employeeId,
        [FromBody] RestDayOffRequest request)
    {
        if (request is null)
            return BadRequest();

        var typeOfLeave = dbContext.TypeOfLeave.Where(x=>x.TypeOfLeave == request.TypeOfLeave).FirstOrDefault();
        var companyId = dbContext.Employees.Where(x=> x.Id == employeeId).FirstOrDefault().CompanyId;
        var dayOffRequest = new DayOffRequest
        {
            Status = Status.Pending,
            CompanyId = companyId,
            EmployeeId = employeeId,
            RequestDate = DateTime.Now,
            TypeOfLeave = typeOfLeave,
            DayOffRequestDate = request.DayOffRequestDate,
            Id = Guid.NewGuid()
        };

        await dbContext.AddAsync(dayOffRequest);
        await dbContext.SaveChangesAsync();

        return Created(dayOffRequest.Id.ToString(), dayOffRequest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] RestDayOffPut status)
    {
        var changeModel = dbContext.DayOffRequests.FirstOrDefault(x => x.Id == id);
        changeModel.Status = (Status)Enum.Parse(typeof(Status), status.Status);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("exist")]
    public bool Exists([FromBody] RestExistDayOff model)
    {
        var existRequest = dbContext.DayOffRequests.Where(x => x.EmployeeId == model.EmployeeId && x.DayOffRequestDate == model.DayOffRequestDate).Any();

        return existRequest;
    }

    [HttpGet("typeOfLeave")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllTypeOfLeave()
    {
        var result = dbContext.TypeOfLeave.Select(x => x.TypeOfLeave).ToList();
        if (result.Count <= 0)
            return NotFound();
        return Ok(result);
    }

}