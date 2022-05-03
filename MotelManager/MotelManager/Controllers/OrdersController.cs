using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotelManager.Models.EF;

namespace MotelManager.Controllers
{
    public class OrdersController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Order
        //Hien thi ds don hang
        public ActionResult Index()
        {
            return View();
        }
    }
}