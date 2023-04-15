using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
