namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oyyy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblProduct", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Sales_SaleId", "dbo.Sales");
            DropForeignKey("dbo.ProductAndSales", "ProductId", "dbo.tblProduct");
            DropForeignKey("dbo.ProductAndSales", "Sales_SaleId", "dbo.Sales");
            DropIndex("dbo.tblProduct", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "Sales_SaleId" });
            DropIndex("dbo.ProductAndSales", new[] { "ProductId" });
            DropIndex("dbo.ProductAndSales", new[] { "Sales_SaleId" });
            CreateTable(
                "dbo.InvoiceProducts",
                c => new
                    {
                        Invoice_InvoiceId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Invoice_InvoiceId, t.Product_ProductId })
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.tblProduct", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Invoice_InvoiceId)
                .Index(t => t.Product_ProductId);
            
            DropColumn("dbo.tblProduct", "Invoice_InvoiceId");
            DropColumn("dbo.Invoices", "salesId");
            DropColumn("dbo.Invoices", "Sales_SaleId");
            DropTable("dbo.Sales");
            DropTable("dbo.ProductAndSales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductAndSales",
                c => new
                    {
                        ProductAndSalesId = c.Int(nullable: false, identity: true),
                        SalesId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Sales_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductAndSalesId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        FaturaNo = c.Single(nullable: false),
                        AraToplam = c.Int(nullable: false),
                        Indirim = c.Int(nullable: false),
                        Kdv = c.Int(nullable: false),
                        ToplamTutar = c.Int(nullable: false),
                        DüzenlenmeTarihi = c.String(),
                        SorumluKisi = c.String(),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            AddColumn("dbo.Invoices", "Sales_SaleId", c => c.Int());
            AddColumn("dbo.Invoices", "salesId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProduct", "Invoice_InvoiceId", c => c.Int());
            DropForeignKey("dbo.InvoiceProducts", "Product_ProductId", "dbo.tblProduct");
            DropForeignKey("dbo.InvoiceProducts", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.InvoiceProducts", new[] { "Invoice_InvoiceId" });
            DropTable("dbo.InvoiceProducts");
            CreateIndex("dbo.ProductAndSales", "Sales_SaleId");
            CreateIndex("dbo.ProductAndSales", "ProductId");
            CreateIndex("dbo.Invoices", "Sales_SaleId");
            CreateIndex("dbo.tblProduct", "Invoice_InvoiceId");
            AddForeignKey("dbo.ProductAndSales", "Sales_SaleId", "dbo.Sales", "SaleId");
            AddForeignKey("dbo.ProductAndSales", "ProductId", "dbo.tblProduct", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "Sales_SaleId", "dbo.Sales", "SaleId");
            AddForeignKey("dbo.tblProduct", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
