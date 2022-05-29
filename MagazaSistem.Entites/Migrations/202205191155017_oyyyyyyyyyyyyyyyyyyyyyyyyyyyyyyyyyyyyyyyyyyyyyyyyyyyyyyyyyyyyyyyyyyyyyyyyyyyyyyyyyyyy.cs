namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblInvoiceAndProduct", "ToplamFiyat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblInvoiceAndProduct", "ToplamFiyat");
        }
    }
}
