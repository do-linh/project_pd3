using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MotelManager.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index(int? page)
        {
            int pageSize = 4;
            if (page == null)
                page = 1;
            int pageNumber = (page ?? 1);
            var listposts = db.Posts.Where(x => x.status == 1).Include(k => k.Motel).OrderBy(x => x.post_id).ToPagedList(pageNumber, pageSize);
            ViewBag.listfavorite = db.Favorites.ToList();
            ViewBag.listnew = db.Posts.Where(x => x.status == 1).OrderByDescending(x => x.post_id).Take(3).ToList();
            ViewBag.listcity = db.Cities.ToList();
            ViewBag.about = db.Abouts.FirstOrDefault();
            return View(listposts);
        }

        public ActionResult About() 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search(int? city_id, int? district_id, int? sub_district_id, int? price_min, int? price_max, int? type)
        {
            var listmotel = db.Motels.ToList();
            if (city_id != null)
            {
                listmotel = listmotel.Where(x => x.city_id == city_id).ToList();
                if(district_id != null)
                {
                    listmotel = listmotel.Where(x => x.district_id == district_id).ToList();
                    if (sub_district_id != null)
                    {
                        listmotel = listmotel.Where(x => x.sub_district_id == sub_district_id).ToList();
                        if(price_min != null && price_max != null)
                        {
                            listmotel = listmotel.Where(x => x.price >= price_min).Where(x => x.price <= price_max).ToList();
                        }
                        if (type != null)
                        {
                            listmotel = listmotel.Where(x => x.type_real_estate_id == type).ToList();
                        }
                    }
                }
                
            }
            List<Post> listSearch = new List<Post>();
            foreach(var item in listmotel)
            {
                foreach(var item2 in db.Posts.ToList())
                {
                    if(item.motel_id == item2.motel_id && item2.status == 1)
                    {
                        listSearch.Add(item2);
                    }
                }
            }
            ViewBag.listSearch = listSearch;
            ViewBag.listfavorite = db.Favorites.ToList();
            ViewBag.listnew = db.Posts.Where(x => x.status == 1).OrderByDescending(x => x.post_id).Take(3).ToList();
            return View();
        }
        public ActionResult _SearchLayout()
        {
            ViewBag.city = db.Cities.ToList();
            ViewBag.type = db.TypeREs.Where(x => x.status == true).ToList();
            ViewBag.setting = db.Settings.Where(x => x.status == true).ToList();
            return PartialView();
        }
        public ActionResult _HeaderLayout()
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            var settting = db.Abouts.FirstOrDefault();
            ViewBag.type = db.TypeREs.ToList();
            if (session != null)
            {
                ViewBag.noti = db.Notifications.Where(x => x.account_id == session.userID).ToList();
                ViewBag.allnoti = db.Notifications.Where(x => x.account_id == 0).ToList();
            }
            else
            {
                ViewBag.noti = new List<Notification>();
                ViewBag.allnoti = new List<Notification>();
            }
                
            return PartialView(settting);
        }
        public ActionResult _FooterLayout()
        {
            var settting = db.Abouts.FirstOrDefault();
            return PartialView(settting);
        }
        public JsonResult GetDistrictByIdCity(int city_id)
        {
            var listDistrict = db.Districts.Where(x => x.city_id == city_id).ToList();
            return Json(listDistrict, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubDistrictByIdD(int district_id)
        {
            var listSubDistrict = db.SubDistricts.Where(x => x.district_id == district_id).ToList();
            return Json(listSubDistrict, JsonRequestBehavior.AllowGet);
        }
    }
}