namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oyyyyyyyyyyyyyyyyyyyyyyyy : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InvoiceAndProducts", newName: "tblInvoiceAndProduct");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tblInvoiceAndProduct", newName: "InvoiceAndProducts");
        }
    }
}
