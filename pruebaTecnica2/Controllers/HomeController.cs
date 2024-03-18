using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnica.Models;

namespace pruebaTecnica.Controllers;

public class HomeController : Controller
{
    
    ProductClientContext dbcontext;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ProductClientContext db)
    {
        _logger = logger;
        dbcontext = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}
