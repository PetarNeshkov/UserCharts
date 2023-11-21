using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserChart.Business.TimeLogs;
using UserChart.Client.Infrastructure;
using UserChart.Client.Models;
using UserChart.UI.Models.TimeLogs;
using UserChart.UI.Models.UserCharts;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace UserChart.Client.Controllers.API;

public class ChartsController : BaseApiController
{
    private readonly ITimeLogService timeLogsService;
    private readonly IMapper mapper;

    public ChartsController(ITimeLogService timeLogsService, IMapper mapper)
    {
        this.timeLogsService = timeLogsService;
        this.mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TimeLogsListingModel>), Status200OK)]
    public async Task<IActionResult> GetTimeLog([FromQuery] UsersChartRequestModel usersChartRequestModel)
    {
        var timeLogs = await timeLogsService
                                                        .GetTopUsers(usersChartRequestModel
                                                        .Map<UsersChartServiceModel>(mapper));

        return Ok(timeLogs);
    }
}