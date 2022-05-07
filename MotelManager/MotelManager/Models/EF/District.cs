namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("District")]
    public partial class District
    {
        [Key]
        public int district_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? city_id { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        public virtual City Cities { get; set; }
    }
}
