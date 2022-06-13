using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class UserLogin
{
    [Key] public Guid Id { get; set; }

    public string? Username { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public DateTime? PasswordLastChanged { get; set; }

    public DateTime RegisterDate { get; set; } = DateTime.Now;


    public Guid RoleId { get; set; }
    public virtual RolePerson? Role { get; set; }
}