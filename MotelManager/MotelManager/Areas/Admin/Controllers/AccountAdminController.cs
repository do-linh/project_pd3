using MotelManager.Common;
using MotelManager.Models.DAO;
using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.Login(model.username, Encryptor.MD5Hash(model.password));
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.userID = user.account_id;
                    userSession.avatar = user.avatar;
                    userSession.fullname = user.fullname;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                }
                else if(result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
        public ActionResult ListUser()
        {
            var list = db.Accounts.OrderByDescending(x => x.account_id).ToList();
            return View(list);
        }
        [HttpPost]
        public JsonResult DeleteUser(string username)
        {
            try
            {
                var model = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                if(model.role == "admin")
                {
                    var count = db.Accounts.Where(x => x.role == "admin").ToList().Count();
                    if(count == 1)
                    {
                        return Json(new { result = "admin", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        db.Accounts.Remove(model);
                        db.SaveChanges();
                        return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
                    }
                }
                db.Accounts.Remove(model);
                db.SaveChanges();
                return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return Json(new { result = "error", JsonRequestBehavior = JsonRequestBehavior.DenyGet });
            }
        }
        [HttpPost]
        public JsonResult CheckUsername(string username)
        {
            try
            {
                var isCheck = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                if(isCheck == null)
                {
                    return Json(new { result = "allow" });
                }
                else
                {
                    return Json(new { result = "deny"});
                }
            }
            catch
            {
                return Json(new { result = "error", JsonRequestBehavior = JsonRequestBehavior.DenyGet });
            }
        }
        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            try
            {
                var isCheck = db.Accounts.Where(x => x.email == email).FirstOrDefault();
                if (isCheck == null)
                {
                    return Json(new { result = "allow" });
                }
                else
                {
                    return Json(new { result = "deny" });
                }
            }
            catch
            {
                return Json(new { result = "error", JsonRequestBehavior = JsonRequestBehavior.DenyGet });
            }
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "AccountAdmin");
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Account model)
        {
            model.password = Encryptor.MD5Hash(model.password);
            if (model.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                filename = filename + extension;
                model.avatar = "/Public/images/avatar/" + filename;
                model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/avatar/"), filename));
            }
            db.Accounts.Add(model);
            db.SaveChanges();
            return RedirectToAction("ListUser", "AccountAdmin");
        }
        public ActionResult EditUser(int user_id)
        {
            var user = db.Accounts.Find(user_id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(Account model)
        {
            var user = db.Accounts.Find(model.account_id);
            user.role = model.role;
            user.password = model.password;
            user.email = model.email;
            user.phone = model.phone;
            user.sex = model.sex;
            user.fullname = model.fullname;
            user.status = model.status;
            user.authority = model.authority;
            if (model.ImageUpload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                filename = filename + extension;
                user.avatar = "/Public/images/avatar/" + filename;
                model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/avatar/"), filename));

            }
            db.SaveChanges();
            return RedirectToAction("EditUser", "AccountAdmin", new { user_id = user.account_id});
        }
    }
}