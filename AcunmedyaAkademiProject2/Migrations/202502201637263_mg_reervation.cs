namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_reervation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhone = c.String(),
                        NumberOfPerson = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
