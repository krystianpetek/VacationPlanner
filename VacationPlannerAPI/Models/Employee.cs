using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Employee
{
    [Key] public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    private bool workMoreThan10Year { get; set; }

    public bool WorkMoreThan10Year
    {
        get => workMoreThan10Year;
        set
        {
            workMoreThan10Year = value;

            if (value)
                numberOfDays = 26;
            else
                numberOfDays = 20;
        }
    }

    private int numberOfDays { get; set; }

    public int NumberOfDays
    {
        get => numberOfDays;
        set => numberOfDays = value;
    }

    private int availableNumberOfDays { get; set; }

    public int AvailableNumberOfDays
    {
        get => availableNumberOfDays;
        set
        {
            if (value <= 0)
                availableNumberOfDays = 0;
            if (value > NumberOfDays)
                availableNumberOfDays = NumberOfDays;
            else
                availableNumberOfDays = value;
        }
    }

    public DateTime RegisterDate { get; set; } = DateTime.Now;


    public Guid? UserLoginId { get; set; }

    public Guid CompanyId { get; set; }

    public virtual UserLogin? UserLogin { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<DayOffRequest>? DayOffRequests { get; set; }
}