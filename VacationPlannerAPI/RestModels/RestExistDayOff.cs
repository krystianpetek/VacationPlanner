namespace VacationPlannerAPI.RestModels
{
    public class RestExistDayOff
    {
        public DateTime DayOffRequestDate { get; set; }
        public Guid EmployeeId { get; set; }
        public string TypeOfLeave { get; set; }
    }
}
