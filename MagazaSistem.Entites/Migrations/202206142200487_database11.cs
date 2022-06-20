namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblBrand", "BrandName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tblSubcategory", "SubcategoryName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tblColor", "ColorName", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblColor", "ColorName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tblSubcategory", "SubcategoryName", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tblBrand", "BrandName", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
