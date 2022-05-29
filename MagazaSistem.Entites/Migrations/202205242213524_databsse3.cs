namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databsse3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblInvoice", "DüzenlenmeTarihi", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.tblInvoice", "Sorumlu", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblInvoice", "Sorumlu");
            DropColumn("dbo.tblInvoice", "DüzenlenmeTarihi");
        }
    }
}
