namespace VacationPlannerAPI.Models
{
    public class ListOfRequest
    {
        public int ListOfRequestId { get; set; }
        public TypeOfLeave TypeOfRequest { get; set; }
        public DateTime DateOfRequest { get; set; }
        public Employee Employee { get; set; }
    }
}
