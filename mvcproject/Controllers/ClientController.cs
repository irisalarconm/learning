using Microsoft.AspNetCore.Mvc;
using mvcproject.Controllers;

[Route("[controller]")]
public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
      
}