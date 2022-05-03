namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Motel")]
    public partial class Motel
    {
        [Key]
        public int motel_id { get; set; }

        public int? acreage { get; set; }

        public int? floor { get; set; }

        public int? bedroom { get; set; }

        public int? bathroom { get; set; }

        public int? price { get; set; }

        [StringLength(255)]
        public string address { get; set; }
        public string iframe { get; set; }

        public int? district_id { get; set; }

        public int? sub_district_id { get; set; }

        public int? type_real_estate_id { get; set; }

        public int? city_id { get; set; }

        [StringLength(200)]
        public string code_motel { get; set; }
    }
}
