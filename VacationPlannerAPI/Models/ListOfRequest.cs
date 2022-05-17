using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class ListOfRequest
    {
        [Required, Key]
        public int ListOfRequestId { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public DateTime DateOfRequest { get; set; }
        [Required]
        public TypeOfLeave TypeOfRequest { get; set; }
    }
}
