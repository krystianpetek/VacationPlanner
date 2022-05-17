using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class UserPassword
    {

        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; } = Role.Employee;
    }
}
