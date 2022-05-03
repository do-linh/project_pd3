using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManager.Models
{
    public class SavedPost
    {
        public int post_id { get; set; }

        public string title { get; set; }

        public string sub_title { get; set; }

        public string description { get; set; }

        public int favorite_id { get; set; }

        public int? account_id { get; set; }

        public string slug { get; set; }
        public string image_post { get; set; }

    }
}