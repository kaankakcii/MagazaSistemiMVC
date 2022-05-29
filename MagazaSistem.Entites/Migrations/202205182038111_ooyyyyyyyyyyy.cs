namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ooyyyyyyyyyyy : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Invoices", newName: "tblInvoice");
            AlterColumn("dbo.tblInvoice", "InvoiceNo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblInvoice", "InvoiceNo", c => c.Single(nullable: false));
            RenameTable(name: "dbo.tblInvoice", newName: "Invoices");
        }
    }
}
