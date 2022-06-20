namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblCategory", "CategoryName", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblCategory", "CategoryName", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
