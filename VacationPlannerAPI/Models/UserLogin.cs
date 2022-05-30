using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class UserLogin
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        public Role Role { get; set; } = Role.Employee;
        
        public Employee Employee { get; set; }
    }
}
