namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int image_id { get; set; }

        public string url { get; set; }

        public int? motel_id { get; set; }
        
    }
}
