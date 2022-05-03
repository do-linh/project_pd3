namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeRE")]
    public partial class TypeRE
    {
        [Key]
        public int type_real_estate_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        public bool? status { get; set; }
    }
}
