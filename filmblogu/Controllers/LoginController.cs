using BlogAppADO.DataAccess;
using filmblogu.Models;
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

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserDal userDal = new UserDal();
            LoginUser user = userDal.Login(model);

            if(user is null)
                return Content("Kullanıcı Adı veya Şifre Yanlış");

            if (!user.MailConfirmed || user.MailConfirmed)
                return Content("mailini onayla");


            HttpContext.Session.SetString("Login", user.RoleId.ToString());
            return Content("Giriş Başarılı");
        }
    }
}
