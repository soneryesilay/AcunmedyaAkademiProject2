namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_del_contact : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
