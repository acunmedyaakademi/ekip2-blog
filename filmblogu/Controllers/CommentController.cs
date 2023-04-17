using AspNetCore.ReCaptcha;
using BlogAppADO.DataAccess;
using filmblog.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmblogu.Controllers
{
    public class CommentController : Controller
    {
        [ValidateReCaptcha]
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            CommentDal CommentDal = new CommentDal();
            if (CommentDal.AddComment(comment) && ModelState.IsValid)
            {
                HttpContext.Session.SetString("Comment", "Yorumunuz gönderildi");

                string url = "/home/blogarticle?id=" + comment.FilmId;
                return Redirect(url);
            }

            HttpContext.Session.SetString("Comment", "Yorumunuz gönderilemedi");
            return RedirectToAction("", "hata");
        }
    }
}
