namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Post")]
    public partial class Post
    {
        [Key]
        public int post_id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string sub_title { get; set; }

        public string description { get; set; }

        public int? account_id { get; set; }

        public int? motel_id { get; set; }

        public int? status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? updated_date { get; set; }

        [StringLength(255)]
        public string slug { get; set; }

        public string image_post { get; set; }
        public virtual Motel Motel { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        [StringLength(200)]
        public string code_post { get; set; }
        public byte[] image_post_byte { get; set; }
    }
}
