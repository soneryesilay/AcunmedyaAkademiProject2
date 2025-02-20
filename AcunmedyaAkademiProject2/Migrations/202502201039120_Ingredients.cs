namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ingredients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Ingredients", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Ingredients");
        }
    }
}
