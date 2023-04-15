using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
