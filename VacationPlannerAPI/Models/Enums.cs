namespace VacationPlannerAPI.Models
{
    public enum Role
    {
        Administrator = 100,
        Employee = 0
    };

    public enum TypeOfLeave
    {
        Annual_Leave,
        Leave_On_Demand,
        Ocassional_Leave,
        Unpaid_Leave,
        Parental_Leave,
        Sick_Leave,
        Time_Off_In_Lieu_For_Overtime
    };
}
