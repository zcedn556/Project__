using Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FilmsDbContext _ctx;

    public HomeController(ILogger<HomeController> logger, FilmsDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    public IActionResult Index()
    {
        var films = _ctx.Films.Include(f => f.Genre).ToList();
        return View(films);
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
}
