namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Decsription", c => c.String());
            AddColumn("dbo.Testimonials", "NameSurname", c => c.String());
            AlterColumn("dbo.Products", "ImageUrl", c => c.String());
            DropColumn("dbo.Abouts", "Description");
            DropColumn("dbo.Testimonials", "Name");
            DropColumn("dbo.Testimonials", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testimonials", "Surname", c => c.String());
            AddColumn("dbo.Testimonials", "Name", c => c.String());
            AddColumn("dbo.Abouts", "Description", c => c.String());
            AlterColumn("dbo.Products", "ImageUrl", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Testimonials", "NameSurname");
            DropColumn("dbo.Abouts", "Decsription");
        }
    }
}
