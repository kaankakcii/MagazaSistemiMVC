namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oyyyy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "AraToplam", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Kdv", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Indirim", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Toplam", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Toplam");
            DropColumn("dbo.Invoices", "Indirim");
            DropColumn("dbo.Invoices", "Kdv");
            DropColumn("dbo.Invoices", "AraToplam");
        }
    }
}
