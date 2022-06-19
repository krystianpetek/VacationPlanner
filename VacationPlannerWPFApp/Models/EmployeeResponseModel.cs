namespace VacationPlannerWPFApp.Models;

public class EmployeeResponseModel
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int NumberOfDays { get; set; }

    public int AvailableNumberOfDays { get; set; }
}