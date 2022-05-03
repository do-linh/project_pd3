namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        [Key]
        public int web_settings_id { get; set; }

        [Column("about")]
        public string about { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(10)]
        public string start_time { get; set; }

        [StringLength(10)]
        public string finish_time { get; set; }
        public string iframe { get; set; }
    }
}
