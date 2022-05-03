namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        [Key]
        public int report_id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(200)]
        public string content_report { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_date { get; set; }

        public bool? status { get; set; }

        public int? post_id { get; set; }
        public virtual Post Post { get; set; }
    }
}
