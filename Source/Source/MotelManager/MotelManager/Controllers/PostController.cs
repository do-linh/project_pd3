using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Controllers
{
    public class PostController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string slug)
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            Post post = db.Posts.Where(x => x.slug.Contains(slug)).Include(k => k.Motel).FirstOrDefault();
           
            ViewBag.image = db.Images.Where(x => x.motel_id == post.motel_id).ToList();
            ViewBag.user = db.Accounts.Where(x => x.account_id == post.account_id).FirstOrDefault();
            if (session != null)
                ViewBag.favorite = db.Favorites.Where(x => x.post_id == post.post_id).Where(k => k.account_id == session.userID).FirstOrDefault();
            else
                ViewBag.favorite = null;
            ViewBag.listdistrict = db.Districts.Where(x => x.city_id == post.Motel.city_id).ToList();
            List<Post> postRelated = db.Posts.Include(k => k.Motel).Where(x => x.Motel.district_id == post.Motel.district_id).Where(a => a.status == 1).ToList();
            ViewBag.Related = postRelated;
            return View(post);
        }
        public ActionResult SavePost(int post_id, int user_id)
        {
            Favorite isCheck = db.Favorites.Where(x => x.post_id == post_id).Where(x => x.account_id == user_id).FirstOrDefault();
            if(isCheck == null)
            {
                Favorite favorite = new Favorite();
                favorite.post_id = post_id;
                favorite.account_id = user_id;
                favorite.date_save = DateTime.Now;
                db.Favorites.Add(favorite);
                db.SaveChanges();
                return Json(new { Message = "save", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            else
            {
                db.Favorites.Remove(isCheck);
                db.SaveChanges();
                return Json(new { Message = "remove", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult CreatePost()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            if (session == null) return View("~/Views/Shared/Error.cshtml");
            else
            {
                var user = db.Accounts.Find(session.userID);
                if (user.authority == 3) return RedirectToAction("Index","Sms", new { isChangePhone  = 0});
                else return View();
            }
        }
        [HttpPost]
        public ActionResult tessting(Account model)
        {
            return View();
        }
        [HttpPost]
        public JsonResult Report(int post_id, string title, string content)
        {
            try
            {
                var newReport = new Report();
                newReport.title = title;
                newReport.content_report = content;
                newReport.created_date = DateTime.Now;
                newReport.status = false;//Chua xu ly
                newReport.post_id = post_id;
                db.Reports.Add(newReport);
                db.SaveChanges();
                return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return Json(new { result = "error", JsonRequestBehavior = JsonRequestBehavior.DenyGet });
            }
        }
    }
}