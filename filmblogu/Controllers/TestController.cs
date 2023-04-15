using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
