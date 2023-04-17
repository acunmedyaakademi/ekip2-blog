using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using filmblog.Models;
using BlogAppADO.DataAccess;
using filmblogu.Models;

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
        MovieDal movieDal = new();

        return View(movieDal.GetAll());
    }
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(User user)
    {
        ViewBag.Message = "Önerilerin bizim için çok değerli.";
        return View();
    }

    public IActionResult BlogArticle(int id)
    {
        BlogArticleVM blogArticle = new();
        MovieDal movieDal = new();
        CommentDal commentDal = new();
                
        bool IsIn = false;
        ViewBag.Comment = HttpContext.Session.GetString("Comment");

        if (HttpContext.Session.GetString("Login") == null)
        {
            IsIn= true;
        }

        ViewBag.IsIn = IsIn;

        blogArticle.Movie = movieDal.GetPostWithId(id);
        blogArticle.Comments = commentDal.GetComments(blogArticle.Movie.Id);
       
        return View(blogArticle);
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

