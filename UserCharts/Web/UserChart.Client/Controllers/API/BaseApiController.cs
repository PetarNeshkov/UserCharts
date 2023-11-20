using Microsoft.AspNetCore.Mvc;

namespace UserChart.Client.Controllers.API;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class BaseApiController : ControllerBase
{
}