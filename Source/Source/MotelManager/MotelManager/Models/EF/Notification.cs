namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public int notification_id { get; set; }

        [StringLength(100)]
        public string notification_title { get; set; }

        [StringLength(200)]
        public string notification_content { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_date { get; set; }

        public int? account_id { get; set; }

        public int? post_id { get; set; }

        public int? status { get; set; }
        public virtual Account Account { get; set; }
    }
}
