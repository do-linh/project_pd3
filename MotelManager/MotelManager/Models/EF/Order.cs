namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order() 
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idOrder { get; set; }

        public DateTime? BookingDate { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public int? account_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Account Account { get; set; }
    }
}
