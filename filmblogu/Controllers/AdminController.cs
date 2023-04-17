using BlogAppADO.DataAccess;
using filmblog.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmblogu.Controllers
{
    public class AdminController : Controller
    {
        /*yarın yetkinelndrime yap*/
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                MovieDal movieDal = new();

                return View(movieDal.GetAll());
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        public IActionResult AcceptComment()
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                CommentDal commentDal = new();
                return View(commentDal.GetCommentsUnAccepted());
            }
            return RedirectToAction("", "YetkisizErişim");

        }


        public IActionResult CommentAccepted(int a, bool delete)
        {
            if (HttpContext.Session.GetString("Login") == "3")
            {
                CommentDal commentDal = new();
                if (delete)
                {
                    commentDal.DeleteComment(a);
                    return Content("silindi");

                }
                commentDal.AcceptComment(a);

                return RedirectToAction("AcceptComment");
            }
            return RedirectToAction("", "YetkisizErişim");

        }
        public IActionResult DeleteMovie()
        {
            if (HttpContext.Session.GetString("Login") == "3")
            {
                return View();
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        public IActionResult MovieDelete(int a)
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                MovieDal movieDal = new();
                movieDal.DeletePostWithId(a);
                return RedirectToAction("DeleteMovie");
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        public IActionResult UpdateRole(int id, int roleid)
        {
            
            if (HttpContext.Session.GetString("Login") == "3")
            {
                UserDal userDal = new();
                if (userDal.UpdateUserRole(id, roleid))
                    return RedirectToAction("AllUsers");

                return RedirectToAction("", "hata");
            }
            return RedirectToAction("", "YetkisizErişim");
        }

        public IActionResult AllUsers()
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                UserDal userDal = new();
                return View(userDal.GetAll());
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        public IActionResult DeleteUser(int id)
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                UserDal userDal = new();
                if (userDal.DeleteUserWithId(id))
                    return RedirectToAction("AllUsers");

                return RedirectToAction("", "hata");
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        public IActionResult UpdateMovie(int a)
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                MovieDal movieDal = new MovieDal();

                return View(movieDal.GetPostWithId(a));
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie Movie)
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                MovieDal movieDal = new MovieDal();

                Movie.Updated_On = DateTime.Now;
                Movie.Picture = "yok";
                movieDal.UpdatePost(Movie);

                return RedirectToAction("index", "admin");
            }
            return RedirectToAction("", "YetkisizErişim");

        }
        public IActionResult AddMovie()
        {
            if (HttpContext.Session.GetString("Login") == "3")
            {
                return View();
            }
            return RedirectToAction("", "YetkisizErişim");

        }

        [HttpPost]
        public IActionResult AddMovie(Movie Movie)
        {

            if (HttpContext.Session.GetString("Login") == "3")
            {
                MovieDal movieDal = new();
                Movie.Updated_On = DateTime.Now;
                Movie.Create_On = DateTime.Now;
                Movie.Picture = "yok";
                Movie.Is_Active = true;
                movieDal.AddPost(Movie);
                return View();
            }
            return RedirectToAction("", "YetkisizErişim");

        }


    }
}
