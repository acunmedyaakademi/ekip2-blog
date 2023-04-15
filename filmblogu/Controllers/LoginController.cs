using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}
