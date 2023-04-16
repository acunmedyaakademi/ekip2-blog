using BlogAppADO.DataAccess;
using BlogAppADO.Models.ModelContainers;
using filmblogu.Models;
using Microsoft.AspNetCore.Mvc;
using static BlogAppADO.Models.Dtos.UserDtos;

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

            if (user is null)
            {
                ViewBag.hata = "Kullanıcı Adı veya Şifre Yanlış";/**/
                return View();
            }

            if (!user.MailConfirmed)
            {
                ViewBag.hata = "mailini onayla";/**/
                return View();
            }

            HttpContext.Session.SetString("LoginId", user.Id.ToString());
            HttpContext.Session.SetString("Login", user.RoleId.ToString());
            return RedirectToAction("index", "home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(UpdateUserMailCode model)
        {
            UserDal userDal = new();
            if(userDal.UpdateUserMailCode(model))
                return RedirectToAction("resetpassword", "login");

            ViewBag.Forget = "Hata";
            return View();
        }



        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(UpdateUserPassword model)
        {
            UserDal userDal = new();
            if (userDal.UpdateUserPassword(model))
            {
                LoginModel LoginModel = new();
                LoginModel.Email = model.Email;
                LoginModel.Password = model.Password;
                LoginUser user = userDal.Login(LoginModel);
                HttpContext.Session.SetString("LoginId", user.Id.ToString());
                HttpContext.Session.SetString("Login", user.RoleId.ToString());
                return RedirectToAction("index", "home");
            }

            ViewBag.Forget = "Hata";
            return View();
        }

        public ActionResult MailConfirm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MailConfirm(ConfirmModel Model)
        {
            UserDal UserDal = new UserDal();

            if (UserDal.ControlMailCode(Model))
            {
                if (UserDal.MailConfirm(Model.Mail))
                {
                    return RedirectToAction("index", "home");
                }
            }

            ViewBag.NotConfirmed = "Mail Onaylanamadı";

            return View();
        }
    }
}
