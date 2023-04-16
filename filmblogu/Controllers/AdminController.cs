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
            MovieDal movieDal = new();

            return View(movieDal.GetAll());
        }

        public IActionResult AcceptComment()
        {
            CommentDal commentDal = new();
            return View(commentDal.GetCommentsUnAccepted());
        }


        public IActionResult CommentAccepted(int a, bool delete)
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
        public IActionResult DeleteMovie()
        {
            return View();
        }

        public IActionResult MovieDelete(int a)
        {
            MovieDal movieDal = new();
            movieDal.DeletePostWithId(a);
            return RedirectToAction("DeleteMovie");
        }

        public IActionResult UpdateRole(int id, int roleid)
        {

            UserDal userDal = new();
            if (userDal.UpdateUserRole(id, roleid))
                return RedirectToAction("AllUsers");

            return RedirectToAction("","hata");
        }

        public IActionResult AllUsers()
        {
            UserDal userDal = new();
            return View(userDal.GetAll());
        }

        public IActionResult DeleteUser(int id)
        {
            UserDal userDal = new();
            if (userDal.DeleteUserWithId(id))
            return RedirectToAction("AllUsers");
            return RedirectToAction("", "hata");
        }

        public IActionResult UpdateMovie(int a)
        {
            MovieDal movieDal = new MovieDal();

            return View(movieDal.GetPostWithId(a));
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie Movie)
        {
            MovieDal movieDal = new MovieDal();

            Movie.Updated_On = DateTime.Now;
            Movie.Picture = "yok";
            movieDal.UpdatePost(Movie);

            return RedirectToAction("index","admin");
        }
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie Movie)
        {
            MovieDal movieDal = new();
            Movie.Updated_On= DateTime.Now;
            Movie.Create_On= DateTime.Now;
            Movie.Picture = "yok";
            Movie.Is_Active= true;
            movieDal.AddPost(Movie);
            return View();
        }


    }
}
