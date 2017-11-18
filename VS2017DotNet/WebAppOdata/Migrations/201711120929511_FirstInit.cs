namespace WebAppOdata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Description", newName: "desc");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "desc", newName: "Description");
        }
    }
}
