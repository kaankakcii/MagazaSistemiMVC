namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databsse5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblInvoice", "DüzenlenmeTarihi", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblInvoice", "DüzenlenmeTarihi", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
