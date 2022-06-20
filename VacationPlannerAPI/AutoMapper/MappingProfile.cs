using AutoMapper;
using VacationPlannerAPI.Models;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DayOffRequest, RestDayOffResponse>()
                .ForMember(x => x.FullName, x => x.MapFrom(
                    x => x.Employee.FirstName[0].ToString().ToUpper() +
                    x.Employee.FirstName.Substring(1, x.Employee.FirstName.Length) +
                    " " +
                    x.Employee.LastName[0].ToString().ToUpper() +
                    x.Employee.LastName.Substring(1, x.Employee.LastName.Length)))
                .ForMember(x => x.TypeOfLeave, x => x.MapFrom(x => x.TypeOfLeave.TypeOfLeave))
                .ForMember(x => x.DayOffRequestDate, x => x.MapFrom(x => x.DayOffRequestDate))
                .ForMember(x => x.Status, x => x.MapFrom(x => x.Status.ToString()));
        }
    }
}
