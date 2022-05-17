using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class ListOfRequest
    {
        public int ListOfRequestId { get; set; }
        public Employee Employee { get; set; }
        public TypeOfLeave TypeOfRequest { get; set; }
        public DateTime DateOfRequest { get; set; }
    }
}
