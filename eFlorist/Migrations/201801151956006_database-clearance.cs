namespace eCoffeeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseclearance : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 60),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
