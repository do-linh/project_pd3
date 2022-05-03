namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        [Key]
        public int setting_id { get; set; }

        public int? min { get; set; }

        public int? max { get; set; }

        public bool? status { get; set; }
    }
}
