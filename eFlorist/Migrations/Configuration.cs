namespace CoffeeSoft.Migrations
{
    using CoffeeSoft.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeSoft.Models.CoffeeSoftDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CoffeeSoft.Models.CoffeeSoftDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var trucktype1 = new TruckType
            {
                TruckTypeName = "Samochód osobowy",
                Trucks = new List<Truck>()
            };
            context.TruckTypes.AddOrUpdate(i => i.TruckTypeName,
            trucktype1,
            new TruckType
            {
                TruckTypeName = "Ciężarówka",
                Trucks = new List<Truck>()
            },
            new TruckType
            {
                TruckTypeName = "TIR",
                Trucks = new List<Truck>()
            });

            context.StatusTypes.AddOrUpdate(i => i.StatusName,
            new StatusType
            {
                StatusName = "Do akceptacji",
                Orders = new List<Order>()
            },
            new StatusType
            {
                StatusName = "Zaakceptowane",
                Orders = new List<Order>()
            },
            new StatusType
            {
                StatusName = "Zrealizowane",
                Orders = new List<Order>()
            });

            context.ItemTypes.AddOrUpdate(i => i.ItemsName,
            new ItemType
            {
                ItemsName = "Kawa ziarnista",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Kawa zmielona",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Kubki ceramiczne",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Kubki termiczne",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Herbata liściasta",
                Items = new List<Item>()
            });

            context.PaymentTypes.AddOrUpdate(i => i.PaymentName,
            new PaymentType
            {
                PaymentName = "Płatność przy odbiorze",
                Orders = new List<Order>()
            },
            new PaymentType
            {
                PaymentName = "Przedpłata",
                Orders = new List<Order>()
            });

            var type1 = new WarehouseType()
            {
                WarehouseTypeName = "Magazyn otwarty",
                Warehouses = new List<Warehouse>()
            };

            context.WarehouseTypes.AddOrUpdate(i => i.WarehouseTypeName,
            type1,
            new WarehouseType
            {
                WarehouseTypeName = "Magazyn zamknięty",
                Warehouses = new List<Warehouse>()
            },
            new WarehouseType
            {
                WarehouseTypeName = "Magazyn półotwarty",
                Warehouses = new List<Warehouse>()
            });
            context.SaveChanges();

            if (!context.Warehouses.Any())
            {
                context.Warehouses.AddOrUpdate(i => i.WarehouseName,
                new Warehouse
                {
                    WarehouseName = "Koluszki",
                    WarehouseType = type1,
                    OrderList = new List<Order>(),
                    InvoiceList = new List<Invoice>(),
                    CoffeeShopList = new List<CoffeeShop>()
                });
            }
            if (!context.Trucks.Any())
            {
                context.Trucks.AddOrUpdate(i => i.TruckName,
                new Truck
                {
                    TruckName = "Yaris",
                    TruckType = trucktype1,
                    Orders = new List<Order>(),
                    Brand = "Toyota",
                    RegistrationNo = "SWA 1234",
                });
            }
            context.SaveChanges();
        }
    }
}
