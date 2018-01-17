using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CoffeeSoft.Models
{
    public class CoffeeSoftDbContext : DbContext
    { 
        public DbSet<Florist> Florists { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckType> TruckTypes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }

        public CoffeeSoftDbContext() : base("name=CoffeeSoftDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("nvarchar"));
            // configures one-to-many relationship
            modelBuilder.Entity<Order>()
                .HasRequired<StatusType>(s => s.OrderStatus)
                .WithMany(g => g.Orders)
                .HasForeignKey<int?>(s => s.OrderStatusId);

            modelBuilder.Entity<Order>()
                .HasRequired<Truck>(s => s.OrderTruck)
                .WithMany(g => g.Orders)
                .HasForeignKey<int?>(s => s.OrderTruckId);

            modelBuilder.Entity<Order>()
                .HasRequired<Warehouse>(s => s.Warehouse)
                .WithMany(g => g.OrderList)
                .HasForeignKey<int?>(s => s.WarehouseId);

            modelBuilder.Entity<Order>()
               .HasRequired<Florist>(s => s.Florist)
               .WithMany(g => g.OrderList)
               .HasForeignKey<int?>(s => s.FloristId);

            modelBuilder.Entity<Order>()
                .HasRequired<PaymentType>(s => s.OrderPayment)
                .WithMany(g => g.Orders)
                .HasForeignKey<int?>(s => s.OrderPaymentId);

            modelBuilder.Entity<Truck>()
               .HasRequired<TruckType>(s => s.TruckType)
               .WithMany(g => g.Trucks)
               .HasForeignKey<int?>(s => s.TruckTypeId);

            modelBuilder.Entity<Warehouse>()
               .HasRequired<WarehouseType>(s => s.WarehouseType)
               .WithMany(g => g.Warehouses)
               .HasForeignKey<int?>(s => s.WarehouseTypeId);

            modelBuilder.Entity<Invoice>()
               .HasRequired<Warehouse>(s => s.Warehouse)
               .WithMany(g => g.InvoiceList)
               .HasForeignKey<int?>(s => s.WarehouseId);

            modelBuilder.Entity<Invoice>()
              .HasRequired<Florist>(s => s.Florist)
              .WithMany(g => g.InvoiceList)
              .HasForeignKey<int?>(s => s.FloristId);

            modelBuilder.Entity<Item>()
              .HasRequired<ItemType>(s => s.ItemType)
              .WithMany(g => g.Items)
              .HasForeignKey<int?>(s => s.ItemTypeId);

            modelBuilder.Entity<OrderItem>()
              .HasRequired<Item>(s => s.Item)
              .WithMany(g => g.OrderItems)
              .HasForeignKey<int?>(s => s.ItemId);

            modelBuilder.Entity<OrderItem>()
              .HasRequired<Order>(s => s.Order)
              .WithMany(g => g.OrderItems)
              .HasForeignKey<int?>(s => s.OrderId);

            // configures many-to-many relationship
            modelBuilder.Entity<Florist>()
                .HasMany<Warehouse>(s => s.WarehouseList)
                .WithMany(c => c.FloristList)
                .Map(cs =>
                {
                    cs.MapLeftKey("FloristRefId");
                    cs.MapRightKey("WarehouseRefId");
                    cs.ToTable("FloristWarehouse");
                });

            modelBuilder.Entity<Item>()
                .HasMany<Florist>(s => s.Florists)
                .WithMany(c => c.ItemsList)
                .Map(cs =>
                {
                    cs.MapLeftKey("ItemRefId");
                    cs.MapRightKey("FloristRefId");
                    cs.ToTable("ItemFlorist");
                });

            // configures one-to-one relationship

            // Configure InvoiceId as PK for Order
            /*modelBuilder.Entity<Order>()
                .HasKey(e => e.InvoiceId);*/

            // Configure InvoiceId as FK for Order
            modelBuilder.Entity<Invoice>()
                        .HasRequired(s => s.Order)
                        .WithRequiredPrincipal(ad => ad.Invoice);


        }
    }
}