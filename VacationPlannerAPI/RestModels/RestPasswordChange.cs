namespace VacationPlannerAPI.RestModels
{
    public class RestPasswordChange
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatPassword { get; set; }
    }
}
