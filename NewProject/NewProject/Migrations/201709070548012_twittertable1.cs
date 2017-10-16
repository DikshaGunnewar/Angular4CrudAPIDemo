namespace NewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twittertable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.twitters", "userId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.twitters", "userId");
        }
    }
}
