namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        public int favorite_id { get; set; }

        public int? account_id { get; set; }

        public int? post_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_save { get; set; }
    }
}
