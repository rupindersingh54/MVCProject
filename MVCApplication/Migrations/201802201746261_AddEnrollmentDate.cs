namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollment", "EnrollmentDate");
        }
    }
}
