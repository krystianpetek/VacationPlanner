namespace VacationPlannerAPI.RestModels;

public class RestEmployeeResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int NumberOfDays { get; set; }
    public int AvailableNumberOfDays { get; set; }
}