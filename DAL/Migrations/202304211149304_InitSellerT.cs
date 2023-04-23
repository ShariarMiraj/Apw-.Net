namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitSellerT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderType = c.String(),
                        OrderQuantity = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        SelleBy = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SelleBy)
                .Index(t => t.SelleBy)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 15),
                        ProductCategory = c.String(nullable: false, maxLength: 15),
                        ProductPrice = c.String(nullable: false, maxLength: 10),
                        ProdcutQuantity = c.String(nullable: false, maxLength: 15),
                        SelleingBy = c.String(maxLength: 128),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.SelleingBy)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.SelleingBy)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Sname = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 15),
                        PhoneNumber = c.String(nullable: false),
                        NidNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sname);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "SelleBy", "dbo.Sellers");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SelleingBy", "dbo.Sellers");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "SelleingBy" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "SelleBy" });
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
