namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idOrder { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int motel_id { get; set; }

        public int? quantity { get; set; }

        public decimal? price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Motel Motel { get; set; }
    }
}
