using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            ViewBag.countPost = db.Posts.ToList().Count();
            ViewBag.countPostNeedapprove = db.Posts.Where(x => x.status == 2).ToList().Count();
            ViewBag.countReport = db.Reports.Where(x => x.status == false).ToList().Count();
            ViewBag.countUser = db.Accounts.ToList().Count();
            if (session == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
        public ActionResult WebsiteInfo()
        {
            var about = db.Abouts.FirstOrDefault();
            ViewBag.about = about;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditInfo(About model)
        {
            try
            {
                var about = db.Abouts.Where(x => x.web_settings_id == model.web_settings_id).FirstOrDefault();
                about.about = model.about;
                about.phone = model.phone;
                about.email = model.email;
                about.address = model.address;
                about.start_time = model.start_time;
                about.finish_time = model.finish_time;
                about.iframe = model.iframe;
                db.SaveChanges();
                ViewBag.about = about;
                return View("WebsiteInfo", ViewBag.about);
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
        public ActionResult SetupPrice()
        {
            var setupPrice = db.Settings.ToList();
            ViewBag.setupPrice = setupPrice;
            return View();
        }
        [HttpPost]
        public ActionResult AddPrice(Setting model)
        {
            try
            {
                db.Settings.Add(model);
                model.status = true;
                db.SaveChanges();

                return RedirectToAction("SetupPrice","Dashboard");
            }
            catch
            {
                return RedirectToAction("SetupPrice", "Dashboard");
            }
        }
        [HttpPost]
        public JsonResult DeletePrice(int setting_id)
        {
            try
            {
                var model = db.Settings.Find(setting_id);
                db.Settings.Remove(model);
                db.SaveChanges();
                return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return Json(new { result = "error", JsonRequestBehavior = JsonRequestBehavior.DenyGet });
            }
        }
        [HttpGet]
        public ActionResult EditPrice(int setting_id)
        {
            var model = db.Settings.Find(setting_id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult EditPrice(Setting model)
        {
            var setting = db.Settings.Find(model.setting_id);
            setting.min = model.min;
            setting.max = model.max;
            setting.status = model.status;
            db.SaveChanges();
            return RedirectToAction("SetupPrice", "Dashboard");
        }
    }
}