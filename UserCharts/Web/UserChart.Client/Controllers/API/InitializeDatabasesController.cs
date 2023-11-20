using Microsoft.AspNetCore.Mvc;
using UserChart.Business.InitializeDatabase;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace UserChart.Client.Controllers.API;

public class InitializeDatabasesController: BaseApiController
{
    private readonly IInitializeDatabaseService initializeDatabaseService;

    public InitializeDatabasesController(IInitializeDatabaseService initializeDatabaseService)
    {
        this.initializeDatabaseService = initializeDatabaseService;
    }
    
    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public async Task<IActionResult> ResetDatabase()
    {
        await initializeDatabaseService.InitializeDatabase();

        return Ok();
    }
}