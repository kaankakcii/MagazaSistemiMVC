namespace MagazaSistem.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database6 : DbMigration
    {
        public override void Up()
        {
           
            
            AddColumn("dbo.tblInvoice", "MoneyCaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblInvoice", "MoneyCaseId");
            AddForeignKey("dbo.tblInvoice", "MoneyCaseId", "dbo.tblMoneyCase", "MoneyCaseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblInvoice", "MoneyCaseId", "dbo.tblMoneyCase");
            DropIndex("dbo.tblInvoice", new[] { "MoneyCaseId" });
            DropColumn("dbo.tblInvoice", "MoneyCaseId");
            DropTable("dbo.tblMoneyCase");
        }
    }
}
