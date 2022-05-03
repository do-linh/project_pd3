using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = LayGioHang();
            return View(lstCart);
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
    }
}