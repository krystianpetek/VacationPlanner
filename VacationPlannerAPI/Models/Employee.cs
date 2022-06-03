using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int NumberOfDays { get; set; }

    public int AvailableNumberOfDays { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public Guid UserLoginId { get; set; }

    public UserLogin? UserLogin { get; set; }
}
