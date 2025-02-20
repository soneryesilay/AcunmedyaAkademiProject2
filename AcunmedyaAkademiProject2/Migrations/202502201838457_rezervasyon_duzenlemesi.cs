namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rezervasyon_duzenlemesi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Status");
        }
    }
}
