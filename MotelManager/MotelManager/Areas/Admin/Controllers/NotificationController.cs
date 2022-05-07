using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/Notification
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListNoitification()
        {
            ViewBag.noti = db.Notifications.Include(x => x.account_id).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DeleteNotification(int notification_id)
        {
            var model = db.Notifications.Find(notification_id);
            db.Notifications.Remove(model);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        public ActionResult AddNotification()
        {
            ViewBag.listUser = db.Accounts.ToList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddNotification(Notification model)
        {
            model.created_date = DateTime.Now;
            model.status = 1;
            db.Notifications.Add(model);
            db.SaveChanges();
            return RedirectToAction("ListNoitification", "Notification");
        }
        public ActionResult EditNotification(int notification_id)
        {
            var model = db.Notifications.Find(notification_id);
            ViewBag.listUser = db.Accounts.ToList();
            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditNotification(Notification model)
        {
            var item = db.Notifications.Find(model.notification_id);
            item.status = 1;
            item.notification_title = model.notification_title;
            item.notification_content = model.notification_content;
            item.created_date = DateTime.Now;
            item.account_id = model.account_id;
            db.SaveChanges();
            return RedirectToAction("ListNoitification","Notification");
        }
        [HttpPost]
        public ActionResult ChangeStatus(int notification_id)
        {
            var model = db.Notifications.Find(notification_id);
            if (model.status == 1)
            {
                model.status = 0;
            }
            else
            {
                model.status = 1;
            }
            db.SaveChanges();
            return Json(new { result = "success" });
        }
    }
}