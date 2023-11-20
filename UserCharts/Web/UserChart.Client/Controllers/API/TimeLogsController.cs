using Microsoft.AspNetCore.Mvc;
using UserChart.Business.TimeLogs;
using UserChart.UI.Models.TimeLogs;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace UserChart.Client.Controllers.API;

public class TimeLogsController : BaseApiController
{
    private readonly ITimeLogService timeLogsService;

    public TimeLogsController(ITimeLogService timeLogsService)
    {
        this.timeLogsService = timeLogsService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TimeLogsServiceModel>), Status200OK)]
    public async Task<IActionResult> GetTimeLog()
    {
        var timeLogs = await timeLogsService.GetUserTimeLogs();

        return Ok(timeLogs);
    }

}