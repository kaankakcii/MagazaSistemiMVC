namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databsse4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblInvoice", "DüzenlenmeTarihi", c => c.DateTime(nullable: true, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblInvoice", "DüzenlenmeTarihi", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
