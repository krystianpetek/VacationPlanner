using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class RolePerson
    {
        [Key]
        public Guid Id { get; set; }

        public Role Role { get; set; }

        public virtual UserLogin? UserLogin { get; set; }

    }
}
