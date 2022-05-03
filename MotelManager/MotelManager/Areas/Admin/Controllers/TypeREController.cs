using MotelManager.Models.DAO;
using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MotelManager.Areas.Admin.Controllers
{
    public class TypeREController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Admin/TypeRE
        public ActionResult Index()
        {
            return View();
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
        public ActionResult ListType()
        {
            ViewBag.listType = db.TypeREs.ToList();
            return View();
        }
        public ActionResult DeleteType(int type_id)
        {
            var type = db.TypeREs.Find(type_id);
            db.TypeREs.Remove(type);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public ActionResult ChangeStatus(int type_id)
        {
            var type = db.TypeREs.Find(type_id);
            if(type.status == true)
            {
                type.status = false;
            }
            else
            {
                type.status = true;
            }
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        [HttpPost]
        public ActionResult AddType(string name, string slug)
        {
            var model = new TypeRE();
            model.name = name;
            model.slug = slug;
            model.status = true;
            db.TypeREs.Add(model);
            db.SaveChanges();
            return Json(new { result = "success" });
        }
        
        [HttpPost]
        public ActionResult CheckSlugType(string name)
        {
            var slug = convertSlug(name);
            var type = db.TypeREs.Where(x => x.slug == slug).FirstOrDefault();
            if (type != null)
            {
                int i = 0;
                do
                {
                    slug += "-" + i.ToString();
                    type = db.TypeREs.Where(x => x.slug == slug).FirstOrDefault();
                    if (type != null)
                        slug = slug.Remove(slug.Length - 2);
                    i += 1;
                } while (type != null);
            }
            return Json(new { result = slug });
        }
    }
}