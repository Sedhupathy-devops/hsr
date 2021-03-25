namespace AspNetMvcUnitTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUrlToVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Url");
        }
    }
}
