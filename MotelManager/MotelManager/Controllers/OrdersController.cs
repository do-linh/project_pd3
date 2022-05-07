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
           List<OrderDetail> showOrderList = new  List<OrderDetail>() ;

            UserLogin kh = (UserLogin)Session[Common.CommonConstants.USER_SESSION];
            if(kh == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int maND = (int)kh.userID;
            List<Order> orders = (List<Order>)db.Orders.Where(x=>x.account_id == maND ).ToList();
            foreach(Order order in orders)
            {
                OrderDetail orderDetail = (OrderDetail) db.OrderDetails.Where(x => x.idOrder == order.idOrder).FirstOrDefault();
                showOrderList.Add(orderDetail);
            }
            //ViewBag.showOrderList = showOrderList;
            return View(showOrderList);
        }
    }
}