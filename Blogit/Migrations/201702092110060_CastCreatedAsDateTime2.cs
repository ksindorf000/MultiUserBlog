namespace Blogit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastCreatedAsDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Created", c => c.DateTime(nullable: false));
        }
    }
}
