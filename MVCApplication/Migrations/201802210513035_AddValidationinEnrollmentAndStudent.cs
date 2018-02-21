namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationinEnrollmentAndStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "ContactNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "ContactNo", c => c.String(maxLength: 10));
        }
    }
}
