namespace BranchManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFluentAPI : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductBranches", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.ProductBranches", name: "Branch_Id", newName: "BranchId");
            RenameIndex(table: "dbo.ProductBranches", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameIndex(table: "dbo.ProductBranches", name: "IX_Branch_Id", newName: "IX_BranchId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductBranches", name: "IX_BranchId", newName: "IX_Branch_Id");
            RenameIndex(table: "dbo.ProductBranches", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.ProductBranches", name: "BranchId", newName: "Branch_Id");
            RenameColumn(table: "dbo.ProductBranches", name: "ProductId", newName: "Product_Id");
        }
    }
}
