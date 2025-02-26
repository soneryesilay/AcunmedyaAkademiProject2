namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ProfileImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ProfileImageUrl");
        }
    }
}
