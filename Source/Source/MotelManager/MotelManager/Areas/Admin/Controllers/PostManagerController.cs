using MotelManager.Models;
using MotelManager.Models.DAO;
using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class PostManagerController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/PostManager
        public ActionResult Index()
        {
            return View();
        }
        public static string convertSlug(string s)
        {
            var createCode = new CreateUniqueCode();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            var ss = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            var slug = Regex.Replace(Regex.Replace(Regex.Replace(ss, @"\s+", "_"), @"\W", ""), "_+", "-");
            var res = slug.ToLower();
            res = createCode.CheckSlug(res);
            return res;
        }
        public ActionResult ListPost()
        {
            ViewBag.list = db.Posts.OrderByDescending(x => x.created_date).Include(x => x.Motel).ToList();
            return View();
        }
        public ActionResult CreatePost()
        {
            ViewBag.listCity = db.Cities.ToList();
            ViewBag.listType = db.TypeREs.ToList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreatePost(CreatePost model)
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            var createCode = new CreateUniqueCode();
            var motel = new Motel();
            var post = new Post();
            String code = createCode.CreateCode() + session.UserName;
            motel.acreage = model.acreage;
            motel.floor = model.floor;
            motel.bedroom = model.bedroom;
            motel.bathroom = model.bathroom;
            motel.price = model.price;
            motel.address = model.address;
            motel.district_id = model.district_id;
            motel.sub_district_id = model.sub_district_id;
            motel.type_real_estate_id = model.type_id;
            model.city_id = model.city_id;
            motel.code_motel = code;
            motel.iframe = model.iframe;
            db.Motels.Add(motel);
            db.SaveChanges();

            //motel = db.Motels.OrderByDescending(p => p.motel_id).FirstOrDefault();
            post.title = model.title;
            post.sub_title = model.sub_title;
            post.description = model.description;
            post.account_id = (int?)session.userID;
            post.code_post = code;
            //post.motel_id = motel.motel_id;
            post.status = 2;
            post.created_date = DateTime.Now;
            post.slug = convertSlug(model.title);
            if (model.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                filename = filename + extension;
                post.image_post = "/Public/images/motel/" + filename;
                model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/motel/"), filename));
            }
            db.Posts.Add(post);
            db.SaveChanges();
            var postCode = db.Posts.Where(x => x.code_post == code).FirstOrDefault();
            var motelCode = db.Motels.Where(x => x.code_motel == code).FirstOrDefault();
            postCode.motel_id = motelCode.motel_id;
            db.SaveChanges();
            //add image for motel
            foreach (HttpPostedFileBase file in model.files)
            {
                Image item = new Image();
                item.motel_id = motelCode.motel_id;
                if (file != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    filename = filename + extension;
                    item.url = "/Public/images/motel/" + filename;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Public/images/motel/"), filename));
                }
                db.Images.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("ListPost", "PostManager");
        }
        public static int account_id_temp;
        public static int post_id_temp;
        [HttpPost]
        public ActionResult CreateNofiction(Notification model)
        {
            model.created_date = DateTime.Now;
            model.status = 1;
            model.account_id = account_id_temp;
            db.Notifications.Add(model);
            db.SaveChanges();
            return RedirectToAction("ListPost","PostManager");
        }
        

        [HttpPost]
        public ActionResult DeletePost(int post_id)
        {
            var post = db.Posts.Find(post_id);
            var motel = db.Motels.Find(post.motel_id);
            var listimage = db.Images.Where(x => x.motel_id == motel.motel_id).ToList();
            account_id_temp = (int)post.account_id;
            post_id_temp = post.post_id;
            foreach(var item in listimage)
            {
                db.Images.Remove(item);
                db.SaveChanges();
            }
            db.Posts.Remove(post);
            db.SaveChanges();
            db.Motels.Remove(motel);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        public ActionResult EditPost(int post_id)
        {
            var model = db.Posts.Where(x => x.post_id == post_id).Include(x => x.Motel).FirstOrDefault();
            ViewBag.listCity = db.Cities.ToList();
            ViewBag.listType = db.TypeREs.ToList();
            ViewBag.listImage = db.Images.Where(x => x.motel_id == model.motel_id).ToList();
            ViewBag.listDistrict = db.Districts.ToList();
            ViewBag.User = db.Accounts.Find(model.account_id);
            ViewBag.listSubDistrict = db.SubDistricts.ToList();
            ViewBag.listuser = db.Accounts.ToList();
            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditPost(CreatePost model)
        {
            var createCode = new CreateUniqueCode();
            var post = db.Posts.Where(x => x.post_id == model.post_id).FirstOrDefault();
            post.title = model.title;
            post.sub_title = model.sub_title;
            post.description = model.description;
            post.status = 2;
            post.updated_date = DateTime.Now;
            post.slug = convertSlug(model.title);
            post.account_id = model.account_id;
            if (model.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                filename = filename + extension;
                post.image_post = "/Public/images/motel/" + filename;
                model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/motel/"), filename));
            }
            db.SaveChanges();
            var motel = db.Motels.Where(x => x.motel_id == post.motel_id).FirstOrDefault();
            motel.acreage = model.acreage;
            motel.floor = model.floor;
            motel.bedroom = model.bedroom;
            motel.bathroom = model.bathroom;
            motel.price = model.price;
            motel.iframe = model.iframe;
            motel.district_id = model.district_id;
            motel.sub_district_id = model.sub_district_id;
            motel.type_real_estate_id = model.type_id;
            motel.city_id = model.city_id;
            db.SaveChanges();
            var listimages = db.Images.Where(x => x.motel_id == post.motel_id).ToList();
            if (model.files[0] != null)
            {
                foreach (var item in listimages)
                {
                    db.Images.Remove(item);
                    db.SaveChanges();
                }
            }
            foreach (HttpPostedFileBase file in model.files)
            {
                if (file != null)
                {
                    Image item = new Image();
                    item.motel_id = motel.motel_id;
                    string filename = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    filename = filename + extension;
                    item.url = "/Public/images/motel/" + filename;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Public/images/motel/"), filename));
                    db.Images.Add(item);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("ListPost", "PostManager");
        }
        [HttpGet]
        public ActionResult ViewPost(int post_id)
        {
            ViewBag.listDistrict = db.Districts.ToList();
            ViewBag.listSubDistrict = db.SubDistricts.ToList();
            var model = db.Posts.Where(x => x.post_id == post_id).Include(x => x.Motel).FirstOrDefault();
            ViewBag.image = db.Images.Where(x => x.motel_id == model.motel_id).ToList();
            ViewBag.listImage = db.Images.Where(x => x.motel_id == model.motel_id).ToList();
            return PartialView(model);
        }
        public ActionResult ListUnActive()
        {
            ViewBag.list = db.Posts.Where(x => x.status == 2).OrderByDescending(x => x.created_date).Include(x => x.Motel).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Approve(int post_id)
        {
            var post = db.Posts.Find(post_id);
            post.status = 1;
            db.SaveChanges();
            return Json(new { result = "success" });
        }
    }
}