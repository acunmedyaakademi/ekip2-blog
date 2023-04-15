using BlogAppADO.DataAccess;
using filmblogu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class SignupController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserDal userDal = new UserDal();
            LoginUser user = userDal.Login(model);



            HttpContext.Session.SetString("Signup", user.RoleId.ToString());

            return Content("Üyelik Oluşturulmuştur.");
        }
    }
}