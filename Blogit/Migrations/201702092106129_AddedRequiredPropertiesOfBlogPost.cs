namespace Blogit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredPropertiesOfBlogPost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Teaser", c => c.String(nullable: false));
            AlterColumn("dbo.BlogPosts", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Body", c => c.String());
            AlterColumn("dbo.BlogPosts", "Teaser", c => c.String());
            AlterColumn("dbo.BlogPosts", "Author", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
        }
    }
}
