using System;

namespace VacationPlannerWPFApp.Models;

public class AccountModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Message { get; set; }
}