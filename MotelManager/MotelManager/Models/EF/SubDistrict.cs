namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubDistrict")]
    public partial class SubDistrict
    {
        [Key]
        public int sub_district_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        public int? district_id { get; set; }
        public virtual District District { get; set; }
    }
}
