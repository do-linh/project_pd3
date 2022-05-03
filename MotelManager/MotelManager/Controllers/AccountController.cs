using MotelManager.Common;
using MotelManager.Models.DAO;
using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var dao = new UserDAO();
                var resuft = dao.Login(username, Encryptor.MD5Hash(password));
                if (resuft == 1)
                {
                    var user = dao.GetByName(username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.FullName = user.fullname;
                    userSession.userID = user.account_id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //ViewBag.ErrorMessage = "Đăng Nhập Thành Công !"; 
                    return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
                }

                else if (resuft == 0)
                {
                    return Json(new { Success = 2 }, JsonRequestBehavior.AllowGet);
                }
                else if (resuft == 3)
                {
                    return Json(new { Success = 3 }, JsonRequestBehavior.AllowGet);
                }
                else if (resuft == -2)
                {
                    return Json(new { Success = 4 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = 5 }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { Success = 5 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Register(string username, string phone, string email, string password)
        {
            try
            {
                Account newUser = new Account();
                newUser.username = username;
                newUser.phone = phone;
                newUser.email = email;
                newUser.role = "user";
                newUser.status = true;
                newUser.password = Encryptor.MD5Hash(password);
                newUser.authority = 3;
                var userDao = new UserDAO();
                var res = userDao.Register(newUser);
                if(res == 1)
                {
                    return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
                }
                else if(res == 2)
                {
                    return Json(new { Success = 2 }, JsonRequestBehavior.AllowGet);
                }
                else if(res == 3)
                {
                    return Json(new { Success = 3 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = 4 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { Success = 5 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EditProfile(int id, Account model)
        {
            return View();
        }
    }
}