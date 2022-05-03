namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int comment_id { get; set; }

        public string content_post { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_date { get; set; }

        public int? account_id { get; set; }

        public int? post_id { get; set; }
    }
}
