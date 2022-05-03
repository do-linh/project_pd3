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

namespace MotelManager.Controllers
{
    public class UserManagerController : Controller
    {
        private DBContext db = new DBContext();
        // GET: UserManager
        
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
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditProfile(string username)
        {
            Account user;
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            if(session == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                user = db.Accounts.Where(x => x.username == session.UserName).FirstOrDefault();
            }
            return View(user);
        }
        public ActionResult EditProfileAfter(Account model)
        {
            try
            {
                var userDao = new UserDAO();
                if (model.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
                    filename = filename + extension;
                    model.avatar = "/Public/images/avatar/" + filename;
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/avatar/"), filename));
                }
                var res = userDao.Update(model);
                return View("EditProfile", res);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult RemovePostSave(int favorite_id)
        {
            try
            {
                Favorite fv = db.Favorites.Find(favorite_id);
                db.Favorites.Remove(fv);
                db.SaveChanges();
                return Json(new { Message = "remove", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return Json(new { Message = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult ChangePasswordAfter(string old_pass, string new_pass)
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            var userDao = new UserDAO();
            var res = userDao.CheckPass(old_pass, session.UserName);
            if (res)
            {
                userDao.ChangePass(new_pass, session.UserName);
                return RedirectToAction("EditProfile", "UserManager", new { username= session.UserName });
            }
            else
            {
                ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
                return View("ChangePassword");
            }
        }
        public ActionResult Favorite()
        {
            return View();
        }
        public ActionResult SavedPost()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            var listpost = db.Posts.ToList();
            var listsaved = db.Favorites.Where(x => x.account_id == session.userID).ToList();
            if (listsaved.Count == 0)
            {
                return View();
            }
            else
            {
                var list = listpost.Join(
                        listsaved,
                        a => a.post_id,
                        b => b.post_id,
                        (a, b) => new
                        {
                            post_id = a.post_id,
                            title = a.title,
                            sub_title = a.sub_title,
                            description = a.description,
                            favorite_id = b.favorite_id,
                            account_id = b.account_id,
                            slug = a.slug,
                            image_post = a.image_post
                        }
                    );
                List<MotelManager.Models.SavedPost> listtemp = new List< MotelManager.Models.SavedPost > ();
                foreach(var item in list)
                {
                    var temp = new Models.SavedPost();
                    temp.post_id = item.post_id;
                    temp.title = item.title;
                    temp.sub_title = item.sub_title;
                    temp.description = item.description;
                    temp.favorite_id = item.favorite_id;
                    temp.account_id = item.account_id;
                    temp.slug = item.slug;
                    temp.image_post = item.image_post;
                    listtemp.Add(temp);
                }
                ViewBag.listtemp = listtemp;
                return View();
            }
        }
        public ActionResult ListPostUser()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            var listpost = db.Posts.OrderByDescending(x => x.created_date).Where(x => x.account_id == session.userID).Include(k => k.Motel).ToList();
            ViewBag.list = listpost;
            return View();
        }
        public ActionResult CreatePost()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            if (session == null) return View("~/Views/Shared/Error.cshtml");
            var user = db.Accounts.Find(session.userID);
            if(user.authority == 3)
            {
                return RedirectToAction("EditProfile", "UserManager", new { username = session.UserName });
            }
            else if(user.authority == null)
            {
                return RedirectToAction("EditProfile", "UserManager", new { username = session.UserName });
            }
            else
            {
                ViewBag.User = db.Accounts.Find(session.userID);
                ViewBag.listDistrict = db.Districts.ToList();
                ViewBag.listSubDistrict = db.SubDistricts.ToList();
                ViewBag.listType = db.TypeREs.ToList();
                ViewBag.listCity = db.Cities.ToList();
                return View();
            }
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
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(model.ImageUpload.InputStream))
                {
                    bytes = br.ReadBytes(model.ImageUpload.ContentLength);
                }
                post.image_post_byte = bytes;
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
            return RedirectToAction("ListPostUser","UserManager");
        }
        public ActionResult DeletePost(int post_id)
        {
            try
            {
                var post = db.Posts.Find(post_id);
                var motel = db.Motels.Find(post.motel_id);

                db.Posts.Remove(post);
                db.Motels.Remove(motel);

                db.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, "Lỗi");
            }
        }
        public ActionResult EditPost(int post_id)
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            Post post = db.Posts.Where(x => x.post_id == post_id).Include(k => k.Motel).FirstOrDefault();
            ViewBag.User = db.Accounts.Find(session.userID);
            ViewBag.listDistrict = db.Districts.ToList();
            ViewBag.listSubDistrict = db.SubDistricts.ToList();
            ViewBag.listType = db.TypeREs.ToList();
            ViewBag.listCity = db.Cities.ToList();
            ViewBag.post = post;
            ViewBag.listImage = db.Images.Where(x => x.motel_id == post.motel_id).ToList();
            return View();
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
            if (model.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                filename = filename + extension;
                post.image_post = "/Public/images/motel/" + filename;
                model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/motel/"), filename));
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(model.ImageUpload.InputStream))
                {
                    bytes = br.ReadBytes(model.ImageUpload.ContentLength);
                }
                post.image_post_byte = bytes;
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
            if(model.files[0] != null)
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
            return RedirectToAction("ListPostUser","UserManager");
        }
        [HttpPost]
        public JsonResult ChangeStatusPost(int post_id)
        {
            try
            {
                var post = db.Posts.Where(x => x.post_id == post_id).FirstOrDefault();
                if (post.status == 3)
                    post.status = 2;
                else
                    post.status = 3;
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