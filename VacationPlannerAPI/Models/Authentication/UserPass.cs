using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models.Authentication
{
    public class UserPass
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
