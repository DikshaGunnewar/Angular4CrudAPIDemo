namespace NewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profile1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "Dob", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
