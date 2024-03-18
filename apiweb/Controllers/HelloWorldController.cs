using Microsoft.AspNetCore.Mvc;

namespace apiweb.Controllers;

[ApiController]
[Route("api/[controller]")]


public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;
    private readonly ILogger<WeatherForecastController> _logger;
    public HelloWorldController(ILogger<WeatherForecastController> logger, IHelloWorldService helloWorld, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("HI");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]

    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}