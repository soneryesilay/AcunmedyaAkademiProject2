namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_end : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "ProfileImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "ProfileImageUrl", c => c.String());
        }
    }
}
