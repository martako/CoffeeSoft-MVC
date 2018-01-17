namespace CoffeeSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newbaseforcoffee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoffeeShops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoffeeShopName = c.String(maxLength: 4000),
                        CoffeeShopAddress = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(maxLength: 4000),
                        WarehouseId = c.Int(nullable: false),
                        CoffeeShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoffeeShops", t => t.CoffeeShopId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.CoffeeShopId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OrderNo = c.String(maxLength: 4000),
                        OrderCreatedDate = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        IsRejected = c.Boolean(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        OrderTruckId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        OrderPaymentId = c.Int(nullable: false),
                        CoffeeShopId = c.Int(nullable: false),
                        InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoffeeShops", t => t.CoffeeShopId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentTypes", t => t.OrderPaymentId, cascadeDelete: true)
                .ForeignKey("dbo.StatusTypes", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Trucks", t => t.OrderTruckId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.OrderStatusId)
                .Index(t => t.OrderTruckId)
                .Index(t => t.WarehouseId)
                .Index(t => t.OrderPaymentId)
                .Index(t => t.CoffeeShopId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemQuantity = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 4000),
                        ItemTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemTypes", t => t.ItemTypeId, cascadeDelete: true)
                .Index(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemsName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TruckName = c.String(maxLength: 4000),
                        Brand = c.String(maxLength: 4000),
                        RegistrationNo = c.String(maxLength: 4000),
                        TruckTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId, cascadeDelete: true)
                .Index(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.TruckTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TruckTypeName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(maxLength: 4000),
                        WarehouseAddress = c.String(maxLength: 4000),
                        WarehouseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WarehouseTypes", t => t.WarehouseTypeId, cascadeDelete: true)
                .Index(t => t.WarehouseTypeId);
            
            CreateTable(
                "dbo.WarehouseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseTypeName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCoffeeShop",
                c => new
                    {
                        ItemRefId = c.Int(nullable: false),
                        CoffeeShopRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemRefId, t.CoffeeShopRefId })
                .ForeignKey("dbo.Items", t => t.ItemRefId, cascadeDelete: true)
                .ForeignKey("dbo.CoffeeShops", t => t.CoffeeShopRefId, cascadeDelete: true)
                .Index(t => t.ItemRefId)
                .Index(t => t.CoffeeShopRefId);
            
            CreateTable(
                "dbo.CoffeeShopWarehouse",
                c => new
                    {
                        CoffeeShopRefId = c.Int(nullable: false),
                        WarehouseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CoffeeShopRefId, t.WarehouseRefId })
                .ForeignKey("dbo.CoffeeShops", t => t.CoffeeShopRefId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseRefId, cascadeDelete: true)
                .Index(t => t.CoffeeShopRefId)
                .Index(t => t.WarehouseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoffeeShopWarehouse", "WarehouseRefId", "dbo.Warehouses");
            DropForeignKey("dbo.CoffeeShopWarehouse", "CoffeeShopRefId", "dbo.CoffeeShops");
            DropForeignKey("dbo.Invoices", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Orders", "Id", "dbo.Invoices");
            DropForeignKey("dbo.Orders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "WarehouseTypeId", "dbo.WarehouseTypes");
            DropForeignKey("dbo.Orders", "OrderTruckId", "dbo.Trucks");
            DropForeignKey("dbo.Trucks", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.StatusTypes");
            DropForeignKey("dbo.Orders", "OrderPaymentId", "dbo.PaymentTypes");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes");
            DropForeignKey("dbo.ItemCoffeeShop", "CoffeeShopRefId", "dbo.CoffeeShops");
            DropForeignKey("dbo.ItemCoffeeShop", "ItemRefId", "dbo.Items");
            DropForeignKey("dbo.Orders", "CoffeeShopId", "dbo.CoffeeShops");
            DropForeignKey("dbo.Invoices", "CoffeeShopId", "dbo.CoffeeShops");
            DropIndex("dbo.CoffeeShopWarehouse", new[] { "WarehouseRefId" });
            DropIndex("dbo.CoffeeShopWarehouse", new[] { "CoffeeShopRefId" });
            DropIndex("dbo.ItemCoffeeShop", new[] { "CoffeeShopRefId" });
            DropIndex("dbo.ItemCoffeeShop", new[] { "ItemRefId" });
            DropIndex("dbo.Warehouses", new[] { "WarehouseTypeId" });
            DropIndex("dbo.Trucks", new[] { "TruckTypeId" });
            DropIndex("dbo.Items", new[] { "ItemTypeId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropIndex("dbo.Orders", new[] { "CoffeeShopId" });
            DropIndex("dbo.Orders", new[] { "OrderPaymentId" });
            DropIndex("dbo.Orders", new[] { "WarehouseId" });
            DropIndex("dbo.Orders", new[] { "OrderTruckId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.Invoices", new[] { "CoffeeShopId" });
            DropIndex("dbo.Invoices", new[] { "WarehouseId" });
            DropTable("dbo.CoffeeShopWarehouse");
            DropTable("dbo.ItemCoffeeShop");
            DropTable("dbo.WarehouseTypes");
            DropTable("dbo.Warehouses");
            DropTable("dbo.TruckTypes");
            DropTable("dbo.Trucks");
            DropTable("dbo.StatusTypes");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.Items");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.CoffeeShops");
        }
    }
}
