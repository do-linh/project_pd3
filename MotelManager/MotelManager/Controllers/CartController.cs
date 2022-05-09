using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotelManager.Common;
using MotelManager.Models.EF;

namespace MotelManager.Controllers
{
    public class CartController : Controller
    {
        DBContext db = new DBContext();
        // GET: Cart
        public List<Cart> LayGioHang()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int imotel, string strURL)
        {
            Motel mt = db.Motels.SingleOrDefault(n => n.motel_id == imotel);
            if (mt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<Cart> lstCart = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            Cart motels = lstCart.Find(n => n.imotel == imotel);
            if (motels == null)
            {
                motels = new Cart(imotel);
                //Add sản phẩm mới thêm vào list
                lstCart.Add(motels);
                return Redirect(strURL);
            }
            else
            {
                motels.quantity++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int imotel, FormCollection f)
        {
            //Kiểm tra masp
            Motel mt = db.Motels.SingleOrDefault(n => n.motel_id == imotel);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (mt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<Cart> lstCart = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            Cart motels = lstCart.SingleOrDefault(n => n.imotel == imotel);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (motels != null)
            {
                motels.quantity = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("Cart");
        }
        

        //Xây dựng trang giỏ hàng
        public ActionResult Index()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = LayGioHang();
            return View(lstCart);
        }

        // Đặt hàng trong giỏ hàng
        public ActionResult OrderRoom()
        {
            List<Cart> lstCart = LayGioHang();
            UserLogin kh = (UserLogin)Session[Common.CommonConstants.USER_SESSION];

            Order order = new Order();
            OrderDetail orderDetail = new OrderDetail();


            Account account = db.Accounts.Where(x => x.account_id == kh.userID).FirstOrDefault();
            foreach (var item in lstCart)
            {
                order.Account = account;
                order.account_id = account.account_id;
                order.BookingDate = DateTime.Now;
                order.Status = "Đang kiểm tra phòng";
                db.Orders.Add(order);

                orderDetail.idOrder = order.idOrder;
                orderDetail.motel_id = item.imotel;
                orderDetail.price = (decimal?)item.dprice;
                orderDetail.quantity = item.quantity;
                db.OrderDetails.Add(orderDetail);

            }
            db.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }

        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int quantity = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                quantity = lstCart.Sum(n => n.quantity);
            }
            return quantity;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dprice = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                dprice = lstCart.Sum(n => n.money);
            }
            return dprice;
        }

        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int imotel)
        {
            //Kiểm tra masp
            Motel mt = db.Motels.SingleOrDefault(n => n.motel_id == imotel);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (mt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<Cart> lstCart = LayGioHang();
            Cart motels = lstCart.SingleOrDefault(n => n.imotel == imotel);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (motels != null)
            {
                lstCart.RemoveAll(n => n.imotel == imotel);

            }
            if (lstCart.Count == 0)
            {
                //return RedirectToAction("Index", "Home");
                return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            }
            //return RedirectToAction("Index");
            return Json(new { result = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet });

        }

    }
}