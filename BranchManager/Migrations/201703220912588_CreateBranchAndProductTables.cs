namespace BranchManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBranchAndProductTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductBranches",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Branch_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Branch_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductBranches", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ProductBranches", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductBranches", new[] { "Branch_Id" });
            DropIndex("dbo.ProductBranches", new[] { "Product_Id" });
            DropTable("dbo.ProductBranches");
            DropTable("dbo.Products");
            DropTable("dbo.Branches");
        }
    }
}
