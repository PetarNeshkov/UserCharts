using AutoMapper;
using UserChart.Client.Models;
using UserChart.UI.Models.TimeLogs;
using UserChart.UI.Models.UserCharts;
using UsersChart.Data.Models;

namespace UserChart.Client;

public class MappingProfiler : Profile
{
    public MappingProfiler()
    {
        CreateMap<TimeLog, TimeLogsListingModel>()
            .ForMember(x => x.Username,
                opt => opt.MapFrom(
                    y => y.User.FirstName + y.User.LastName))
            .ForMember(x => x.Email,
                opt => opt.MapFrom(
                    y => y.User.Email))
            .ForMember(x => x.ProjectName,
                opt => opt.MapFrom(
                    y => y.Project.Name));
        
            CreateMap<TimeLogRequestModel, TimeLogServiceModel>();
            CreateMap<UsersChartRequestModel, UsersChartServiceModel>();
    }
}