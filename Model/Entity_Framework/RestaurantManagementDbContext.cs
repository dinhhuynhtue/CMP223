namespace Model.Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantManagementDbContext : DbContext
    {
        public RestaurantManagementDbContext()
            : base("name=RestaurantManagement")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<FoodType> FoodTypes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TB_Detail> TB_Detail { get; set; }
        public virtual DbSet<TB_Information> TB_Information { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Discount_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.TB_Information)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Discount_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.TB_Detail)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodType>()
                .HasMany(e => e.Dishes)
                .WithRequired(e => e.FoodType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Information>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.TB_Information)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_Information>()
                .HasMany(e => e.TB_Detail)
                .WithRequired(e => e.TB_Information)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TB_Information)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
