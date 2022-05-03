using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListReport()
        {
            ViewBag.listreport = db.Reports.Include(x => x.Post).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ChangeStatus(int report_id)
        {
            var model = db.Reports.Find(report_id);
            if(model.status == true)
            {
                model.status = false;
            }
            else
            {
                model.status = true;
            }
            db.SaveChanges();
            return Json(new { result = "success" });
        }
    }
}