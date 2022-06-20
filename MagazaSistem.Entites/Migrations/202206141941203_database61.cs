namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database61 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProduct", "ProductName", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProduct", "ProductName", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
