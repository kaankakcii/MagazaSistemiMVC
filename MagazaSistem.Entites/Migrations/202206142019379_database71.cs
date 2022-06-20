namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database71 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProduct", "ProductStockCode", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.tblProduct", "ProductImage", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProduct", "ProductImage", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.tblProduct", "ProductStockCode", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
