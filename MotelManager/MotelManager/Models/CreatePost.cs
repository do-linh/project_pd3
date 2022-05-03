using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManager.Models
{
    public class CreatePost
    {
        public int city_id { get; set; }
        public int district_id { get; set; }
        public int sub_district_id { get; set; }
        public string address { get; set; }
        public int type_id { get; set; }
        public string title {get; set;}
        public string sub_title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int acreage { get; set; }
        public int bathroom { get; set; }
        public int bedroom { get; set; }
        public int floor { get; set; }
        public int account_id { get; set; }
        public string iframe { get; set; }
        public int post_id { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        [Required(ErrorMessage = "Please select image.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    }
}