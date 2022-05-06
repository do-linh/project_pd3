using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotelManager.Models.EF;
using MotelManager.Common;


namespace MotelManager.Controllers
{
    public class OrdersController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Order
        //Hien thi ds don hang
        public ActionResult Index()
        {
            UserLogin kh = (UserLogin)Session[Common.CommonConstants.USER_SESSION];
            int maND = (int)kh.userID;
            var orders = db.Orders.Where(d => d.account_id == maND);
            return View(orders);
        }
    }
}