using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManager.Models.DAO
{
    public class CreateUniqueCode
    {
        private DBContext db = new DBContext();
		public string CreateCode()
		{
			Guid g = Guid.NewGuid();
			string GuidString = Convert.ToBase64String(g.ToByteArray());
			GuidString = GuidString.Replace("=", "");
			GuidString = GuidString.Replace("+", "");
			return GuidString;
		}

        public string CheckSlug(string slug)
        {
            var createCode = new CreateUniqueCode();
            var post = db.Posts.Where(x => x.slug == slug).FirstOrDefault();
            if (post != null)
            {
                slug += createCode.CreateCode();
                return slug;
            }
            else
            {
                return slug;
            }
        }
    }
}