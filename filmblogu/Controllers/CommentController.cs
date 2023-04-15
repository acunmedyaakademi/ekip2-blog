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
            if (CommentDal.AddComment(comment))
            {
                ViewBag.Comment = "Yorumunuz Gönderildi";
                return Content("eklendi");
            }
            return Content("hata");
        }

        public IActionResult DeleteComment(int a)
        {
            CommentDal CommentDal = new CommentDal();
            if (CommentDal.DeleteComment(a))
               return Content("silindi");            

            return Content("hata");
        }

        public IActionResult AcceptComment(int a)
        {
            CommentDal CommentDal = new CommentDal();
            if (CommentDal.AcceptComment(a))
                return Content("kabul edildi");

            return Content("hata");                      
        }

        public IActionResult Comments(int a)
        {
            CommentDal CommentDal = new CommentDal();
            try
            {
                CommentDal.GetComments(a);
                return Content("listelendi");
            }
            catch (Exception)
            {
                return Content("hata");
            }
        }
    }
}
