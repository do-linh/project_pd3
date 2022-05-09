using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MotelManager.Models.EF
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Motel> Motels { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SubDistrict> SubDistricts { get; set; }
        public virtual DbSet<TypeRE> TypeREs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.start_time)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.finish_time)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.iframe)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.identityID)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Code>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Motel>()
                .Property(e => e.iframe)
                .IsUnicode(false);

            modelBuilder.Entity<Motel>()
                .Property(e => e.code_motel)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Post>()
                .Property(e => e.image_post)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.code_post)
                .IsUnicode(false);

            modelBuilder.Entity<SubDistrict>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<TypeRE>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
               .Property(e => e.account_id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Status);

            modelBuilder.Entity<Order>()
                .Property(e => e.BookingDate);

            modelBuilder.Entity<Notification>()
              .Property(e => e.account_id);
        }
    }
}
