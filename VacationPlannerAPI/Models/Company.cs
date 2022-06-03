using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        public string? CompanyName { get; set; }

        public Guid AdministratorId { get; set; }

        public UserLogin? Administrator { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

    }
}
