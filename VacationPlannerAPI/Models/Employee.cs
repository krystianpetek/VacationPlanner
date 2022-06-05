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


    public Guid? UserLoginId { get; set; }

    public Guid CompanyId { get; set; }

    public virtual UserLogin? UserLogin { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<DayOffRequest>? DayOffRequests { get; set; }
}
