using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using filmblog.Models;

namespace filmblog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Blog()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult BlogArticle()
    {
        /*vakit kalırsa partial yap*/

        bool IsIn = false;
        ViewBag.Comment = HttpContext.Session.GetString("Comment");

        if (HttpContext.Session.GetString("Login") == null)
        {
            IsIn= true;
        }
       
        return View(IsIn);
    }

    public IActionResult Studio()
    {
        return View();
    }
    public IActionResult Team()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

