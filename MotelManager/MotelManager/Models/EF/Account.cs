namespace MotelManager.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Account()
        {
            Orders = new HashSet<Order>();
            Notifications = new HashSet<Notification>();
        }
        [Key]
        public int account_id { get; set; }

        [StringLength(10)]
        public string role { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(10)]
        public string sex { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        public bool? status { get; set; }

        [StringLength(12)]
        public string identityID { get; set; }

        public int? authority { get; set; }

        public string avatar { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public byte[] avatarImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

    }
}
