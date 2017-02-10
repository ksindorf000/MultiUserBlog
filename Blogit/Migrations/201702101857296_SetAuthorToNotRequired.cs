namespace Blogit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAuthorToNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Author", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Author", c => c.String(nullable: false));
        }
    }
}
