using MotelManager.Models.DAO;
using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class LocationController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/Location
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListCity()
        {
            var cites = db.Cities.ToList();
            ViewBag.cites = cites;
            return View();
        }
        public ActionResult ListDistrict()
        {
            var district = db.Districts.Include(k => k.Cities).ToList();
            ViewBag.city = db.Cities.ToList();
            ViewBag.district = district;
            return View();
        }
        public ActionResult ListSubDistrict()
        {
            var sub = db.SubDistricts.Include(k => k.District).ToList();
            ViewBag.Subdistrict = sub;
            ViewBag.district = db.Districts.Include(x => x.Cities).ToList();
            return View();
        }
        [HttpPost]
        public JsonResult DelCity(int city_id)
        {
            var city = db.Cities.Find(city_id);
            var district = db.Districts.Where(x => x.city_id == city.city_id).ToList();
            var sub = db.SubDistricts.ToList();
            List<SubDistrict> subDistricts = new List<SubDistrict>();
            foreach(var item in district)
            {
                foreach(var item2 in sub)
                {
                    if (item.district_id == item2.district_id)
                        subDistricts.Add(item2);
                }
            }
            //xoa toan bo sub district theo id district
            foreach(var item in subDistricts)
            {
                db.SubDistricts.Remove(item);
                db.SaveChanges();
            }
            //
            foreach (var item in district)
            {
                db.Districts.Remove(item);
                db.SaveChanges();
            }
            db.Cities.Remove(city);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        public static string convertSlug(string s)
        {
            var createCode = new CreateUniqueCode();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            var ss = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            var slug = Regex.Replace(Regex.Replace(Regex.Replace(ss, @"\s+", "_"), @"\W", ""), "_+", "-");
            var res = slug.ToLower();
            return res;
        }
        public JsonResult AddCity(string name, string slug)
        {
            City model = new City();
            model.name = name;
            model.slug = slug;
            db.Cities.Add(model);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public ActionResult CheckSlugCity(string name)
        {
            var slug = convertSlug(name);
            var city = db.Cities.Where(x => x.slug == slug).FirstOrDefault();
            if(city != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    city = db.Cities.Where(x => x.slug == slug).FirstOrDefault();
                    if(city != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (city != null);
            }
            return Json(new { result = slug});
        }
        [HttpPost]
        public ActionResult CheckSlugDistrict(string name)
        {
            var slug = convertSlug(name);
            var city = db.Districts.Where(x => x.slug == slug).FirstOrDefault();
            if (city != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    city = db.Districts.Where(x => x.slug == slug).FirstOrDefault();
                    if (city != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (city != null);
            }
            return Json(new { result = slug });
        }
        [HttpPost]
        public ActionResult CheckSlugSubDistrict(string name)
        {
            var slug = convertSlug(name);
            var city = db.SubDistricts.Where(x => x.slug == slug).FirstOrDefault();
            if (city != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    city = db.SubDistricts.Where(x => x.slug == slug).FirstOrDefault();
                    if (city != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (city != null);
            }
            return Json(new { result = slug });
        }
        [HttpPost]
        public ActionResult EditCity(int city_id, string name, string slug)
        {
            var city = db.Cities.Find(city_id);
            city.name = name;
            city.slug = slug;
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpGet]
        public ActionResult EditDistrict(int district_id)
        {
            var district = db.Districts.Find(district_id);
            ViewBag.cities = db.Cities.ToList();
            return PartialView(district);
        }
        [HttpPost]
        public ActionResult EditDistrict(District model)
        {
            var district = db.Districts.Find(model.district_id);
            district.name = model.name;
            

            var slug = convertSlug(model.name);
            var city = db.Districts.Where(x => x.slug == slug).FirstOrDefault();
            if (city != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    city = db.Districts.Where(x => x.slug == slug).FirstOrDefault();
                    if (city != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (city != null);
            }
            district.slug = slug;
            district.city_id = model.city_id;
            db.SaveChanges();
            return RedirectToAction("ListDistrict", "Location");
        }
        [HttpGet]
        public ActionResult EditSub(int subDistrict_id)
        {
            var sub = db.SubDistricts.Find(subDistrict_id);
            ViewBag.districts = db.Districts.ToList();
            return PartialView(sub);
        }
        [HttpPost]
        public ActionResult EditSub(SubDistrict model)
        {
            var subdistrict = db.SubDistricts.Find(model.sub_district_id);
            subdistrict.name = model.name;


            var slug = convertSlug(model.name);
            var city = db.SubDistricts.Where(x => x.slug == slug).FirstOrDefault();
            if (city != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    city = db.SubDistricts.Where(x => x.slug == slug).FirstOrDefault();
                    if (city != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (city != null);
            }
            subdistrict.slug = slug;
            subdistrict.district_id = (int)model.district_id;
            db.SaveChanges();
            return RedirectToAction("ListSubDistrict", "Location");
        }
        [HttpPost]
        public ActionResult AddDistrict(int city_id, string name, string slug)
        {
            var model = new District();
            model.name = name;
            model.slug = slug;
            model.city_id = city_id;
            db.Districts.Add(model);
            db.SaveChanges();
            return Json(new { result = "success"});
        }
        [HttpPost]
        public ActionResult AddSubDistrict(int district_id, string name, string slug)
        {
            var model = new SubDistrict();
            model.name = name;
            model.slug = slug;
            model.district_id = district_id;
            db.SubDistricts.Add(model);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public ActionResult DeleteDistrict(int district_id)
        {
            var district = db.Districts.Find(district_id);
            var listsub = db.SubDistricts.Where(x => x.district_id == district.district_id).ToList();
            foreach(var item in listsub)
            {
                db.SubDistricts.Remove(item);
                db.SaveChanges();
            }
            db.Districts.Remove(district);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public ActionResult DeleteSubDistrict(int sub_district_id)
        {
            var subdistrict = db.SubDistricts.Find(sub_district_id);
            db.SubDistricts.Remove(subdistrict);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
    }
}