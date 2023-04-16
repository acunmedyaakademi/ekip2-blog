using BlogAppADO.DataAccess;
using filmblog.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmblogu.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User Model)
        {
            UserDal userDal = new();
            Model.RolId = 1;
            Model.Is_Active = true;
            Model.Mail_Confirmed = false;
            Model.Mail_Sended_Time = DateTime.Now;
            if(userDal.AddUser(Model))
                return RedirectToAction("mailconfirm", "login");

            ViewBag.Signup = "Kullanıcı Oluşturulamadı";
            return View();

        }
    }
}
