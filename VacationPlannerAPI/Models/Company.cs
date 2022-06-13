using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Company
{
    [Key] public Guid Id { get; set; }

    public string CompanyName { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;

    public Guid AdministratorId { get; set; }

    public virtual UserLogin? Administrator { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; }
}