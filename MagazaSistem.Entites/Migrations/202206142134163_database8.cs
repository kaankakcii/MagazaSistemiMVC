namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblPersonel", "PersonelName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.tblPersonel", "PersonelMail", c => c.String(nullable: false, maxLength: 100, unicode: false));
           
           
            
            
            AlterColumn("dbo.tblMoneyCase", "MoneyCaseName", c => c.String(nullable: false, maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblMoneyCase", "MoneyCaseName", c => c.String(maxLength: 500, unicode: false));
      
            
           
            
            AlterColumn("dbo.tblPersonel", "PersonelMail", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.tblPersonel", "PersonelName", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
