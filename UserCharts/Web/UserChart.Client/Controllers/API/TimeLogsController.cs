using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserChart.Business.TimeLogs;
using UserChart.Client.Infrastructure;
using UserChart.Client.Models;
using UserChart.UI.Models.TimeLogs;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace UserChart.Client.Controllers.API;

public class TimeLogsController : BaseApiController
{
    private readonly IMapper mapper;
    private readonly ITimeLogService timeLogsService;

    public TimeLogsController(ITimeLogService timeLogsService, IMapper mapper)
    {
        this.timeLogsService = timeLogsService;
        this.mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TimeLogsListingModel>), Status200OK)]
    public async Task<IActionResult> GetTimeLog([FromQuery] TimeLogRequestModel timeLogRequestModel)
    {
        var timeLogs = await timeLogsService.GetUserTimeLogs(timeLogRequestModel.Map<TimeLogServiceModel>(mapper));

        return Ok(timeLogs);
    }

    
    [HttpGet]
    [ProducesResponseType(typeof(int), Status200OK)]
    public async Task<IActionResult> GetTimeLogCount()
    {
        var timeLogsCount = await timeLogsService.GetTimeLogsCount();

        return Ok(timeLogsCount);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(int), Status200OK)]
    public async Task<IActionResult> GetUserData([FromQuery] string userId)
    {
        var timeLogsCount = await timeLogsService.GetUserData(userId);

        return Ok(timeLogsCount);
    }
}